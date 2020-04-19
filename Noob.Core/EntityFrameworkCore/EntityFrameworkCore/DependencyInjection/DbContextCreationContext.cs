// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DbContextCreationContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Common;
using System.Threading;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    /// <summary>
    /// Class DbContextCreationContext.
    /// </summary>
    public class DbContextCreationContext
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public static DbContextCreationContext Current => _current.Value;
        /// <summary>
        /// The current
        /// </summary>
        private static readonly AsyncLocal<DbContextCreationContext> _current = new AsyncLocal<DbContextCreationContext>();

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <value>The name of the connection string.</value>
        public string ConnectionStringName { get; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; }

        /// <summary>
        /// Gets or sets the existing connection.
        /// </summary>
        /// <value>The existing connection.</value>
        public DbConnection ExistingConnection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextCreationContext"/> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="connectionString">The connection string.</param>
        public DbContextCreationContext(string connectionStringName, string connectionString)
        {
            ConnectionStringName = connectionStringName;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Uses the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>IDisposable.</returns>
        public static IDisposable Use(DbContextCreationContext context)
        {
            var previousValue = Current;
            _current.Value = context;
            return new DisposeAction(() => _current.Value = previousValue);
        }
    }
}