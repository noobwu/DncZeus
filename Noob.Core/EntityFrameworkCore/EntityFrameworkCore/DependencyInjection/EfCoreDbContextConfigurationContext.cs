// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="DbContextConfigurationContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Noob.DependencyInjection;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    /// <summary>
    /// Class DbContextConfigurationContext.
    /// Implements the <see cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    public class EfCoreDbContextConfigurationContext : IServiceProviderAccessor
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; }

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <value>The name of the connection string.</value>
        public string ConnectionStringName { get; }

        /// <summary>
        /// Gets the existing connection.
        /// </summary>
        /// <value>The existing connection.</value>
        public DbConnection ExistingConnection { get; }

        /// <summary>
        /// Gets or sets the database context options.
        /// </summary>
        /// <value>The database context options.</value>
        public DbContextOptionsBuilder DbContextOptions { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreDbContextConfigurationContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="existingConnection">The existing connection.</param>
        public EfCoreDbContextConfigurationContext(
            [NotNull] string connectionString,
            [NotNull] IServiceProvider serviceProvider,
            [CanBeNull] string connectionStringName,
            [CanBeNull]DbConnection existingConnection)
        {
            ConnectionString = connectionString;
            ServiceProvider = serviceProvider;
            ConnectionStringName = connectionStringName;
            ExistingConnection = existingConnection;

            DbContextOptions = new DbContextOptionsBuilder()
                .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
        }
    }

    /// <summary>
    /// Class DbContextConfigurationContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.DependencyInjection.EfCoreDbContextConfigurationContext" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <seealso cref="Noob.EntityFrameworkCore.DependencyInjection.EfCoreDbContextConfigurationContext" />
    public class DbContextConfigurationContext<TDbContext> : EfCoreDbContextConfigurationContext
        where TDbContext : EfCoreDbContext<TDbContext>
    {
        /// <summary>
        /// Gets the database context options.
        /// </summary>
        /// <value>The database context options.</value>
        public new DbContextOptionsBuilder<TDbContext> DbContextOptions => (DbContextOptionsBuilder<TDbContext>)base.DbContextOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextConfigurationContext{TDbContext}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="existingConnection">The existing connection.</param>
        public DbContextConfigurationContext(
            string connectionString,
            [NotNull] IServiceProvider serviceProvider,
            [CanBeNull] string connectionStringName,
            [CanBeNull] DbConnection existingConnection)
            : base(
                  connectionString, 
                  serviceProvider, 
                  connectionStringName, 
                  existingConnection)
        {
            base.DbContextOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
        }
    }
}