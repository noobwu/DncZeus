// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DbContextExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class DbContextExtensions.
    /// </summary>
    internal static class DbContextExtensions
    {
        /// <summary>
        /// Determines whether [has relational transaction manager] [the specified database context].
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <returns><c>true</c> if [has relational transaction manager] [the specified database context]; otherwise, <c>false</c>.</returns>
        public static bool HasRelationalTransactionManager(this DbContext dbContext)
        {
            return dbContext.Database.GetService<IDbContextTransactionManager>() is IRelationalTransactionManager;
        }
    }
}