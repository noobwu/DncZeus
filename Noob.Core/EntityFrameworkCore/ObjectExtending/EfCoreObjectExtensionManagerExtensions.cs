// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="EfCoreObjectExtensionManagerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.Data;
using Noob.Domain.Entities;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class EfCoreObjectExtensionManagerExtensions.
    /// </summary>
    public static class EfCoreObjectExtensionManagerExtensions
    {
        /// <summary>
        /// Maps the ef core property.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        public static ObjectExtensionManager MapEfCoreProperty<TEntity, TProperty>(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] string propertyName,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction = null)
            where TEntity : IHasExtraProperties, IEntity
        {
            return objectExtensionManager.MapEfCoreProperty(
                typeof(TEntity),
                typeof(TProperty),
                propertyName,
                propertyBuildAction
            );
        }

        /// <summary>
        /// Maps the ef core property.
        /// </summary>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        public static ObjectExtensionManager MapEfCoreProperty(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] Type entityType,
            [NotNull] Type propertyType,
            [NotNull] string propertyName,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction = null)
        {
            Check.NotNull(objectExtensionManager, nameof(objectExtensionManager));

            return objectExtensionManager.AddOrUpdateProperty(
                entityType,
                propertyType,
                propertyName,
                options =>
                {
                    options.MapEfCore(
                        propertyBuildAction
                    );
                }
            );
        }

        /// <summary>
        /// Configures the ef core entity.
        /// </summary>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="typeBuilder">The type builder.</param>
        public static void ConfigureEfCoreEntity(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] EntityTypeBuilder typeBuilder)
        {
            Check.NotNull(objectExtensionManager, nameof(objectExtensionManager));
            Check.NotNull(typeBuilder, nameof(typeBuilder));

            var objectExtension = objectExtensionManager.GetOrNull(typeBuilder.Metadata.ClrType);
            if (objectExtension == null)
            {
                return;
            }

            foreach (var property in objectExtension.GetProperties())
            {
                var efCoreMapping = property.GetEfCoreMappingOrNull();
                if (efCoreMapping == null)
                {
                    continue;
                }

                /* Prevent multiple calls to the entityTypeBuilder.Property(...) method */
                if (typeBuilder.Metadata.FindProperty(property.Name) != null)
                {
                    continue;
                }

                var propertyBuilder = typeBuilder.Property(property.Type, property.Name);

                efCoreMapping.PropertyBuildAction?.Invoke(propertyBuilder);
            }
        }
    }
}
