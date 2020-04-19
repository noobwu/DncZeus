// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IDbContextProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Interface IDbContextProvider
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    public interface IDbContextProvider<out TDbContext>
        where TDbContext : EfCoreDbContext
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns>TDbContext.</returns>
        TDbContext GetDbContext();
    }
}