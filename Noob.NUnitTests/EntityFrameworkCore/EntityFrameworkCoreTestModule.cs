// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EntityFrameworkCoreTestModule.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.Castle.DynamicProxy;
using Noob.Data;
using Noob.DependencyInjection;
using Noob.EntityFrameworkCore.DependencyInjection;
using Noob.Modularity;
using Noob.TestApp;
using Noob.TestApp.Domain;
using Noob.TestApp.EntityFrameworkCore;
using Noob.TestApp.Testing;
using Noob.Uow;
using Noob.Uow.EntityFrameworkCore;
using Noob.Modularity.PlugIns;
using Noob.Threading;
using Noob.Linq;
using Noob.EntityFrameworkCore.TestApp.SecondContext;
using Noob.EntityFrameworkCore.TestApp.ThirdDbContext;
using Microsoft.Data.SqlClient;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EntityFrameworkCoreTestModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    public class EntityFrameworkCoreTestModule : Module
    {
        /// <summary>
        /// Called when [pre application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            //context.ServiceProvider.GetRequiredService<SecondDbContext>().Database.Migrate();
        }
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddEfCoreDbContext<SecondDbContext>(options =>
            {
                options.AddDefaultRepositories();

            });
            context.Services.AddEfCoreDbContext<ThirdDbContext>(options =>
            {
                options.AddDefaultRepositories<IThirdDbContext>();
            });
            context.Services.AddEfCoreDbContext<TestAppDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
                //options.ReplaceDbContext<IThirdDbContext>();
                options.Entity<Person>(opt =>
                {
                    opt.DefaultWithDetailsFunc = q => q.Include(p => p.Phones);
                });
            });
            var sqlConnection = CreateDatabaseAndGetConnection();
            Configure<EfCoreDbContextOptions>(options =>
            {
                options.Configure(dbContextConfigurationContext =>
                {
                    dbContextConfigurationContext.DbContextOptions.UseSqlServer(sqlConnection);
                });
            });
            context.Services.AddDbContext<TestAppDbContext>(options =>
            {
                options.UseSqlServer(sqlConnection);
            });
            //context.Services.AddEfCoreDbContext<TestAppDbContext>(options =>
            //{
            //    options.AddDefaultRepositories(true);
            //    options.ReplaceDbContext<IThirdDbContext>();

            //    options.Entity<Person>(opt =>
            //    {
            //        opt.DefaultWithDetailsFunc = q => q.Include(p => p.Phones);
            //    });
            //});

            context.Services.TryAddTransient<IConnectionStringResolver, DefaultConnectionStringResolver>();
            context.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            context.Services.AddSingleton<IAmbientUnitOfWork, AmbientUnitOfWork>();
            context.Services.AddTransient<IHybridServiceScopeFactory, DefaultServiceScopeFactory>();
            context.Services.AddSingleton<IUnitOfWorkManager, UnitOfWorkManager>();
            context.Services.TryAddTransient(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));

            //context.Services.TryAddTransient<ICityRepository, CityRepository>();
            //context.Services.TryAddTransient<IPersonRepository, PersonRepository>();
            //context.Services.TryAddTransient<IEntityWithIntPkRepository, EntityWithIntPkRepository>();
            context.Services.TryAddTransient<TestDataBuilder>();
            #region Interceptor
            //CastleCoreModule
            context.Services.AddTransient(typeof(AsyncDeterminationInterceptor<>));

            context.Services.AddSingleton<IAsyncQueryableExecuter>(DefaultAsyncQueryableExecuter.Instance);
            context.Services.AddSingleton<ICancellationTokenProvider>(NullCancellationTokenProvider.Instance);
            context.Services.AddSingleton(typeof(IAmbientScopeProvider<>), typeof(AmbientDataContextAmbientScopeProvider<>));

            context.Services.AddAssembly(typeof(DefaultServiceScopeFactory).Assembly);
            context.Services.AddAssembly(typeof(TestDataBuilder).Assembly);
            context.Services.OnRegistred(UnitOfWorkInterceptorRegistrar.RegisterIfNeeded);
            #endregion

        }


        ///// <summary>
        ///// Creates the database and get connection.
        ///// </summary>
        ///// <returns>SqliteConnection.</returns>
        //private static SqliteConnection CreateDatabaseAndGetConnection()
        //{
        //    var connection = new SqliteConnection("Data Source=:memory:");
        //    connection.Open();

        //    using (var context = new TestMigrationsDbContext(new DbContextOptionsBuilder<TestMigrationsDbContext>().UseSqlite(connection).Options))
        //    {
        //        context.GetService<IRelationalDatabaseCreator>().CreateTables();
        //        context.Database.ExecuteSqlRaw(
        //            @"CREATE VIEW View_PersonView AS 
        //              SELECT Name, CreationTime, Birthday, LastActive FROM People");
        //    }
        //    return connection;
        //}
        private static SqlConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqlConnection("Server=.;Database=EfCoreTest2;User=sa;Password=123456;");
            connection.Open();

            using (var context = new TestMigrationsDbContext(new DbContextOptionsBuilder<TestMigrationsDbContext>().UseSqlServer(connection).Options))
            {
                context.GetService<IRelationalDatabaseCreator>().CreateTables();
                context.Database.ExecuteSqlRaw(
                    @"CREATE VIEW View_PersonView AS 
                      SELECT Name, CreationTime, Birthday, LastActive FROM People");
            }

            return connection;
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }
        /// <summary>
        /// Seeds the test data.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void SeedTestData(ApplicationInitializationContext context)
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(() => scope.ServiceProvider
                    .GetRequiredService<TestDataBuilder>()
                    .BuildAsync());
            }
        }
    }
}
