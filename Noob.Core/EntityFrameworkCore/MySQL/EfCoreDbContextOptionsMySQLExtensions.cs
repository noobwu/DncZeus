// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EfCoreDbContextOptionsMySQLExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContextOptionsMySQLExtensions.
    /// </summary>
    public static class EfCoreDbContextOptionsMySQLExtensions
    {
        /// <summary>
        /// Uses my SQL.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mySQLOptionsAction">My SQL options action.</param>
        public static void UseMySQL([NotNull] this EfCoreDbContextOptions options)
        {
            options.Configure(context =>
            {
                context.UseMySQL();
            });
        }

        /// <summary>
        /// Uses my SQL.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="options">The options.</param>
        /// <param name="optionsAction">My SQL options action.</param>
        public static void UseMySQL<TDbContext>([NotNull] this EfCoreDbContextOptions options)
            where TDbContext : EfCoreDbContext<TDbContext>
        {
            options.Configure<TDbContext>(context =>
            {
                context.UseMySQL();
            });
        }
    }
}
