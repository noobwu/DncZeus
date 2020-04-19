// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ThirdDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.TestApp.ThirdDbContext
{
    /* This dbcontext is just for testing to replace dbcontext from the application using AbpDbContextRegistrationOptions.ReplaceDbContext
     */
    /// <summary>
    /// Class ThirdDbContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.EntityFrameworkCore.TestApp.ThirdDbContext.ThirdDbContext}" />
    /// Implements the <see cref="Noob.EntityFrameworkCore.TestApp.ThirdDbContext.IThirdDbContext" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.EntityFrameworkCore.TestApp.ThirdDbContext.ThirdDbContext}" />
    /// <seealso cref="Noob.EntityFrameworkCore.TestApp.ThirdDbContext.IThirdDbContext" />
    public class ThirdDbContext : EfCoreDbContext<ThirdDbContext>, IThirdDbContext
    {
        /// <summary>
        /// Gets or sets the dummy entities.
        /// </summary>
        /// <value>The dummy entities.</value>
        public DbSet<ThirdDbContextDummyEntity> DummyEntities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ThirdDbContext(DbContextOptions<ThirdDbContext> options) 
            : base(options)
        {
        }
    }
}
