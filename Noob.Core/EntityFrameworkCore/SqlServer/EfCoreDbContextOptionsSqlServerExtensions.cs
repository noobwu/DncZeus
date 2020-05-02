// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EfCoreDbContextOptionsSqlServerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContextOptionsSqlServerExtensions.
    /// </summary>
    public static class EfCoreDbContextOptionsSqlServerExtensions
    {
        /// <summary>
        /// Uses the SQL server.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="sqlServerOptionsAction">The SQL server options action.</param>
        public static void UseSqlServer(
            [NotNull] this EfCoreDbContextOptions options,
            [CanBeNull] Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            options.Configure(context =>
            {
                context.UseSqlServer(sqlServerOptionsAction);
            });
        }

        /// <summary>
        /// Uses the SQL server.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="options">The options.</param>
        /// <param name="sqlServerOptionsAction">The SQL server options action.</param>
        public static void UseSqlServer<TDbContext>(
            [NotNull] this EfCoreDbContextOptions options,
            [CanBeNull] Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
            where TDbContext : EfCoreDbContext<TDbContext>
        {
            options.Configure<TDbContext>(context =>
            {
                context.UseSqlServer(sqlServerOptionsAction);
            });
        }
    }
}