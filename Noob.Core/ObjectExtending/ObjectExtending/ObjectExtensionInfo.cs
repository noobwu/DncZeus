// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ObjectExtensionInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JetBrains.Annotations;
using Noob.Data;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class ObjectExtensionInfo.
    /// </summary>
    public class ObjectExtensionInfo
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [NotNull]
        public Type Type { get; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        [NotNull]
        protected Dictionary<string, ObjectExtensionPropertyInfo> Properties { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        [NotNull]
        public Dictionary<object, object> Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExtensionInfo"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ObjectExtensionInfo([NotNull] Type type)
        {
            Type = Check.AssignableTo<IHasExtraProperties>(type, nameof(type));
            Properties = new Dictionary<string, ObjectExtensionPropertyInfo>();
            Configuration = new Dictionary<object, object>();
        }

        /// <summary>
        /// Determines whether the specified property name has property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns><c>true</c> if the specified property name has property; otherwise, <c>false</c>.</returns>
        public virtual bool HasProperty(string propertyName)
        {
            return Properties.ContainsKey(propertyName);
        }

        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionInfo.</returns>
        [NotNull]
        public virtual ObjectExtensionInfo AddOrUpdateProperty<TProperty>(
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
        {
            return AddOrUpdateProperty(
                typeof(TProperty),
                propertyName,
                configureAction
            );
        }

        /// <summary>
        /// Adds the or update property.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionInfo.</returns>
        [NotNull]
        public virtual ObjectExtensionInfo AddOrUpdateProperty(
            [NotNull] Type propertyType,
            [NotNull] string propertyName,
            [CanBeNull] Action<ObjectExtensionPropertyInfo> configureAction = null)
        {
            Check.NotNull(propertyType, nameof(propertyType));
            Check.NotNull(propertyName, nameof(propertyName));

            var propertyInfo = Properties.GetOrAdd(
                propertyName,
                () => new ObjectExtensionPropertyInfo(this, propertyType, propertyName)
            );

            configureAction?.Invoke(propertyInfo);

            return this;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns>ImmutableList&lt;ObjectExtensionPropertyInfo&gt;.</returns>
        [NotNull]
        public virtual ImmutableList<ObjectExtensionPropertyInfo> GetProperties()
        {
            return Properties.Values.ToImmutableList();
        }

        /// <summary>
        /// Gets the property or null.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>ObjectExtensionPropertyInfo.</returns>
        [CanBeNull]
        public virtual ObjectExtensionPropertyInfo GetPropertyOrNull(
            [NotNull] string propertyName)
        {
            Check.NotNullOrEmpty(propertyName, nameof(propertyName));

            return Properties.GetOrDefault(propertyName);
        }
    }
}