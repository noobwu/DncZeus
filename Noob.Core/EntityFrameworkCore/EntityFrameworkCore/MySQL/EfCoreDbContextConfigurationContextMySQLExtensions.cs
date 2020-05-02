// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EfCoreDbContextConfigurationContextMySQLExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using Noob.EntityFrameworkCore.DependencyInjection;
namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContextConfigurationContextMySQLExtensions.
    /// </summary>
    public static class EfCoreDbContextConfigurationContextMySQLExtensions
    {
        /// <summary>
        /// Uses my SQL.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>DbContextOptionsBuilder.</returns>
        public static DbContextOptionsBuilder UseMySQL(
           [NotNull] this EfCoreDbContextConfigurationContext context)
        {
            if (context.ExistingConnection != null)
            {
                return context.DbContextOptions.UseMySQL(context.ExistingConnection);
            }
            else
            {
                return context.DbContextOptions.UseMySQL(context.ConnectionString);
            }
        }
    }
}
