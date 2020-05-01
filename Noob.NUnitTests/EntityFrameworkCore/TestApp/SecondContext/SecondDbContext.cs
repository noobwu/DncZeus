// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="SecondDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.TestApp.SecondContext
{
    /// <summary>
    /// Class SecondDbContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.EntityFrameworkCore.TestApp.SecondContext.SecondDbContext}" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.EntityFrameworkCore.TestApp.SecondContext.SecondDbContext}" />
    public class SecondDbContext : EfCoreDbContext<SecondDbContext>
    {
        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>The books.</value>
        public DbSet<BookInSecondDbContext> Books { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        /// <value>The phones.</value>
        public DbSet<PhoneInSecondDbContext> Phones { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SecondDbContext(DbContextOptions<SecondDbContext> options) 
            : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhoneInSecondDbContext>(b =>
            {
                b.HasKey(p => new { p.PersonId, p.Number });
            });
        }
    }
}