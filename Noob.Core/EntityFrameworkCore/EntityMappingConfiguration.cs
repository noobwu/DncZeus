// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 04-05-2020
//https://stackoverflow.com/questions/26957519/ef-core-mapping-entitytypeconfiguration
// Last Modified By : Administrator
// Last Modified On : 04-05-2020
// ***********************************************************************
// <copyright file="EntityMappingConfiguration.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Interface IEntityMappingConfiguration
    /// </summary>
    public interface IEntityMappingConfiguration
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void Map(ModelBuilder builder);
    }

    /// <summary>
    /// Interface IEntityMappingConfiguration
    /// Implements the <see cref="Noob.EntityFrameworkCore.IEntityMappingConfiguration" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Noob.EntityFrameworkCore.IEntityMappingConfiguration" />
    public interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : class
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void Map(EntityTypeBuilder<T> builder);
    }

    /// <summary>
    /// Class EntityMappingConfiguration.
    /// Implements the <see cref="Noob.EntityFrameworkCore.IEntityMappingConfiguration{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Noob.EntityFrameworkCore.IEntityMappingConfiguration{T}" />
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public abstract void Map(EntityTypeBuilder<T> builder);

        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Map(ModelBuilder builder)
        {
            Map(builder.Entity<T>());
        }
    }
}
