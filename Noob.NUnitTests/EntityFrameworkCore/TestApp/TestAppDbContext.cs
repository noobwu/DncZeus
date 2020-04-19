// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="TestAppDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Noob.EntityFrameworkCore;
using Noob.TestApp.Domain;
using Noob.EntityFrameworkCore.TestApp.ThirdDbContext;

namespace Noob.TestApp.EntityFrameworkCore
{
    /// <summary>
    /// Class TestAppDbContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.TestApp.EntityFrameworkCore.TestAppDbContext}" />
    /// Implements the <see cref="Noob.EntityFrameworkCore.TestApp.ThirdDbContext.IThirdDbContext" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.TestApp.EntityFrameworkCore.TestAppDbContext}" />
    /// <seealso cref="Noob.EntityFrameworkCore.TestApp.ThirdDbContext.IThirdDbContext" />
    public class TestAppDbContext : EfCoreDbContext<TestAppDbContext>, IThirdDbContext
    {
        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        /// <value>The people.</value>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        /// <value>The cities.</value>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets the person view.
        /// </summary>
        /// <value>The person view.</value>
        public DbSet<PersonView> PersonView { get; set; }

        /// <summary>
        /// Gets or sets the dummy entities.
        /// </summary>
        /// <value>The dummy entities.</value>
        public DbSet<ThirdDbContextDummyEntity> DummyEntities { get; set; }

        /// <summary>
        /// Gets or sets the entity with int PKS.
        /// </summary>
        /// <value>The entity with int PKS.</value>
        public DbSet<EntityWithIntPk> EntityWithIntPks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) 
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
            modelBuilder.Owned<District>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Phone>(b =>
            {
                b.HasKey(p => new {p.PersonId, p.Number});
            });

            modelBuilder
                .Entity<PersonView>(p =>
                {
                    p.HasNoKey();
                    p.ToView("View_PersonView");
                });

            modelBuilder.Entity<City>(b =>
            {
                b.OwnsMany(c => c.Districts, d =>
                {
                    d.WithOwner().HasForeignKey(x => x.CityId);
                    d.HasKey(x => new {x.CityId, x.Name});
                });
            });
        }
    }
}
