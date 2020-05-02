// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditingTestModule.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Noob.Auditing.App.Entities;
using Noob.Auditing.App.EntityFrameworkCore;
using Noob.Autofac;
using Noob.EntityFrameworkCore;
using Noob.Modularity;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingTestModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(
        typeof(TestBaseModule),
        typeof(AutofacModule),
        typeof(EntityFrameworkCoreModule)
    )]
    public class AuditingTestModule : Module
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var sqliteConnection = CreateDatabaseAndGetConnection();
            context.Services.AddEfCoreDbContext<AuditingTestDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });
            Configure<EfCoreDbContextOptions>(options =>
            {
                options.Configure(dbContextConfigurationContext =>
                {
                    dbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
                });
            });

            Configure<AuditingOptions>(options =>
            {
                options.EntityHistorySelectors.Add(
                    new NamedTypeSelector(
                        "AppEntityWithSelector",
                        type => type == typeof(AppEntityWithSelector))
                );
            });
            context.Services.AddType<Auditing_Tests.MyAuditedObject1>();
        }

        /// <summary>
        /// Creates the database and get connection.
        /// </summary>
        /// <returns>SqliteConnection.</returns>
        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            using (var context = new AuditingTestDbContext(new DbContextOptionsBuilder<AuditingTestDbContext>()
                .UseSqlite(connection).Options))
            {
                context.GetService<IRelationalDatabaseCreator>().CreateTables();
            }

            return connection;
        }
    }
}