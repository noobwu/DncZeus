// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="EfCoreDbContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class EfCoreDbContext : DbContext
    {
        /// <summary>
        /// The configuration assemblies
        /// </summary>
        Assembly[] configAssemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="configAssemblies">The configuration assemblies.</param>
        public EfCoreDbContext(DbContextOptions options, params Assembly[] configAssemblies) : base(options)
        {
            this.configAssemblies = configAssemblies;
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
            if (configAssemblies != null && configAssemblies.Length > 0)
            {
                foreach (var assembly in configAssemblies)
                {
                    modelBuilder.AddEntityConfigurationsFromAssembly(assembly);
                }
                
            }
            base.OnModelCreating(modelBuilder);
        }

    }
}
