// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Repository_Basic_Tests.cs" company="Noob.NUnitTests">
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
using Noob.Modularity;
using Noob.TestApp;
using Noob.TestApp.Domain;
using Noob.TestApp.EntityFrameworkCore;
using Noob.TestApp.Testing;
using Noob.Uow.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Class Repository_Basic_Tests.
    /// Implements the <see cref="Noob.TestApp.Testing.Repository_Basic_Tests{Noob.EntityFrameworkCore.Repositories.Repository_Basic_Tests}" />
    /// </summary>
    /// <seealso cref="Noob.TestApp.Testing.Repository_Basic_Tests{Noob.EntityFrameworkCore.Repositories.Repository_Basic_Tests}" />
    public class Repository_Basic_Tests : Repository_Basic_Tests<Repository_Basic_Tests>
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var sqliteConnection = CreateDatabaseAndGetConnection();
            Configure<EfCoreDbContextOptions>(options =>
            {
                options.Configure(dbContextConfigurationContext =>
                {
                    dbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
                });
            });
            context.Services.AddDbContext<TestAppDbContext>(options => {
                options.UseSqlite(sqliteConnection);
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
            context.Services.TryAddTransient(typeof(IDbContextProvider<>), typeof(EfCoreDatabaseApi<>));
            context.Services.TryAddTransient<ICityRepository, CityRepository>();
            context.Services.TryAddTransient<IPersonRepository, PersonRepository>();
            context.Services.TryAddTransient<IEntityWithIntPkRepository, EntityWithIntPkRepository>();
            context.Services.TryAddTransient<TestDataBuilder>();

        }
        /// <summary>
        /// Creates the database and get connection.
        /// </summary>
        /// <returns>SqliteConnection.</returns>
        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            using (var context = new TestMigrationsDbContext(new DbContextOptionsBuilder<TestMigrationsDbContext>().UseSqlite(connection).Options))
            {
                context.GetService<IRelationalDatabaseCreator>().CreateTables();
                context.Database.ExecuteSqlRaw(
                    @"CREATE VIEW View_PersonView AS 
                      SELECT Name, CreationTime, Birthday, LastActive FROM People");
            }
            return connection;
        }
    }
}
