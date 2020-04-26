// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="EfCoreObjectExtensionPropertyInfoExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class EfCoreObjectExtensionPropertyInfoExtensions.
    /// </summary>
    public static class EfCoreObjectExtensionPropertyInfoExtensions
    {
        /// <summary>
        /// The ef core property configuration name
        /// </summary>
        public const string EfCorePropertyConfigurationName = "EfCoreMapping";

        /// <summary>
        /// Maps the ef core.
        /// </summary>
        /// <param name="propertyExtension">The property extension.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        /// <returns>ObjectExtensionPropertyInfo.</returns>
        [NotNull]
        public static ObjectExtensionPropertyInfo MapEfCore(
            [NotNull] this ObjectExtensionPropertyInfo propertyExtension,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction = null)
        {
            Check.NotNull(propertyExtension, nameof(propertyExtension));

            propertyExtension.Configuration[EfCorePropertyConfigurationName] =
                new ObjectExtensionPropertyInfoEfCoreMappingOptions(
                    propertyExtension,
                    propertyBuildAction
                );

            return propertyExtension;
        }

        /// <summary>
        /// Gets the ef core mapping or null.
        /// </summary>
        /// <param name="propertyExtension">The property extension.</param>
        /// <returns>ObjectExtensionPropertyInfoEfCoreMappingOptions.</returns>
        [CanBeNull]
        public static ObjectExtensionPropertyInfoEfCoreMappingOptions GetEfCoreMappingOrNull(
            [NotNull] this ObjectExtensionPropertyInfo propertyExtension)
        {
            Check.NotNull(propertyExtension, nameof(propertyExtension));

            return propertyExtension
                    .Configuration
                    .GetOrDefault(EfCorePropertyConfigurationName)
                as ObjectExtensionPropertyInfoEfCoreMappingOptions;
        }

        /// <summary>
        /// Determines whether [is mapped to field for ef core] [the specified property extension].
        /// </summary>
        /// <param name="propertyExtension">The property extension.</param>
        /// <returns><c>true</c> if [is mapped to field for ef core] [the specified property extension]; otherwise, <c>false</c>.</returns>
        public static bool IsMappedToFieldForEfCore(
            [NotNull] this ObjectExtensionPropertyInfo propertyExtension)
        {
            Check.NotNull(propertyExtension, nameof(propertyExtension));

            return propertyExtension
                .Configuration
                .ContainsKey(EfCorePropertyConfigurationName);
        }
    }
}
