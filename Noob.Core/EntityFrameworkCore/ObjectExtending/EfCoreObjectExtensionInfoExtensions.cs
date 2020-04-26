// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="EfCoreObjectExtensionInfoExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class EfCoreObjectExtensionInfoExtensions.
    /// </summary>
    public static class EfCoreObjectExtensionInfoExtensions
    {
        /// <summary>
        /// Maps the ef core property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="objectExtensionInfo">The object extension information.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        /// <returns>ObjectExtensionInfo.</returns>
        public static ObjectExtensionInfo MapEfCoreProperty<TProperty>(
            [NotNull] this ObjectExtensionInfo objectExtensionInfo,
            [NotNull] string propertyName,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction)
        {
            return objectExtensionInfo.MapEfCoreProperty(
                typeof(TProperty),
                propertyName,
                propertyBuildAction
            );
        }

        /// <summary>
        /// Maps the ef core property.
        /// </summary>
        /// <param name="objectExtensionInfo">The object extension information.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        /// <returns>ObjectExtensionInfo.</returns>
        public static ObjectExtensionInfo MapEfCoreProperty(
            [NotNull] this ObjectExtensionInfo objectExtensionInfo,
            [NotNull] Type propertyType,
            [NotNull] string propertyName,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction)
        {
            Check.NotNull(objectExtensionInfo, nameof(objectExtensionInfo));

            return objectExtensionInfo.AddOrUpdateProperty(
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
    }
}