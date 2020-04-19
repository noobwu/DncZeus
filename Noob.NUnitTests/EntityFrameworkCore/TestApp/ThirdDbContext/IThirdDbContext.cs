// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IThirdDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.TestApp.ThirdDbContext
{
    /// <summary>
    /// Interface IThirdDbContext
    /// Implements the <see cref="Noob.EntityFrameworkCore.IEfCoreDbContext" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.IEfCoreDbContext" />
    public interface IThirdDbContext : IEfCoreDbContext
    {
        /// <summary>
        /// Gets or sets the dummy entities.
        /// </summary>
        /// <value>The dummy entities.</value>
        DbSet<ThirdDbContextDummyEntity> DummyEntities { get; set; }
    }
}