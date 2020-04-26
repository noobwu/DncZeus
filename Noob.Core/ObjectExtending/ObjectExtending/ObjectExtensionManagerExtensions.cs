// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="ObjectExtensionManagerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob.Data;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class ObjectExtensionManagerExtensions.
    /// </summary>
    public static class ObjectExtensionManagerExtensions
    {
        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="objectTypes">The object types.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public static ObjectExtensionManager AddOrUpdateProperty<TProperty>(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] Type[] objectTypes,
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
        {
            return objectExtensionManager.AddOrUpdateProperty(
                objectTypes,
                typeof(TProperty),
                propertyName, configureAction
            );
        }

        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <typeparam name="TObject">The type of the t object.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public static ObjectExtensionManager AddOrUpdateProperty<TObject, TProperty>(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
            where TObject : IHasExtraProperties
        {
            return objectExtensionManager.AddOrUpdateProperty(
                typeof(TObject),
                typeof(TProperty),
                propertyName,
                configureAction
            );
        }

        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="objectTypes">The object types.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public static ObjectExtensionManager AddOrUpdateProperty(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] Type[] objectTypes,
            [NotNull] Type propertyType,
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
        {
            Check.NotNull(objectTypes, nameof(objectTypes));

            foreach (var objectType in objectTypes)
            {
                objectExtensionManager.AddOrUpdateProperty(
                    objectType,
                    propertyType,
                    propertyName,
                    configureAction
                );
            }

            return objectExtensionManager;
        }

        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <param name="objectExtensionManager">The object extension manager.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public static ObjectExtensionManager AddOrUpdateProperty(
            [NotNull] this ObjectExtensionManager objectExtensionManager,
            [NotNull] Type objectType,
            [NotNull] Type propertyType,
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
        {
            Check.NotNull(objectExtensionManager, nameof(objectExtensionManager));

            return objectExtensionManager.AddOrUpdate(
                objectType,
                options =>
                {
                    options.AddOrUpdateProperty(
                        propertyType,
                        propertyName,
                        configureAction
                    );
                });
        }
    }
}