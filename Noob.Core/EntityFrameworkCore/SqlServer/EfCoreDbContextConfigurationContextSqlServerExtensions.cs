// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EfCoreDbContextConfigurationContextSqlServerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Noob.EntityFrameworkCore.DependencyInjection;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContextConfigurationContextSqlServerExtensions.
    /// </summary>
    public static class EfCoreDbContextConfigurationContextSqlServerExtensions
    {
        /// <summary>
        /// Uses the SQL server.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="sqlServerOptionsAction">The SQL server options action.</param>
        /// <returns>DbContextOptionsBuilder.</returns>
        public static DbContextOptionsBuilder UseSqlServer(
            [NotNull] this EfCoreDbContextConfigurationContext context,
            [CanBeNull] Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            if (context.ExistingConnection != null)
            {
                return context.DbContextOptions.UseSqlServer(context.ExistingConnection, sqlServerOptionsAction);
            }
            else
            {
                return context.DbContextOptions.UseSqlServer(context.ConnectionString, sqlServerOptionsAction);
            }
        }
    }
}
