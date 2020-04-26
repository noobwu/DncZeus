// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="ObjectExtensionManager.cs" company="Noob.Core">
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
    /// Class ObjectExtensionManager.
    /// </summary>
    public class ObjectExtensionManager
    {
        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ObjectExtensionManager Instance { get; set; } = new ObjectExtensionManager();

        /// <summary>
        /// Gets the objects extensions.
        /// </summary>
        /// <value>The objects extensions.</value>
        protected Dictionary<Type, ObjectExtensionInfo> ObjectsExtensions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExtensionManager"/> class.
        /// </summary>
        protected internal ObjectExtensionManager()
        {
            ObjectsExtensions = new Dictionary<Type, ObjectExtensionInfo>();
        }

        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <typeparam name="TObject">The type of the t object.</typeparam>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public virtual ObjectExtensionManager AddOrUpdate<TObject>(
            [CanBeNull] Action<ObjectExtensionInfo> configureAction = null)
            where TObject : IHasExtraProperties
        {
            return AddOrUpdate(typeof(TObject), configureAction);
        }

        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public virtual ObjectExtensionManager AddOrUpdate(
            [NotNull] Type[] types,
            [CanBeNull] Action<ObjectExtensionInfo> configureAction = null)
        {
            Check.NotNull(types, nameof(types));

            foreach (var type in types)
            {
                AddOrUpdate(type, configureAction);
            }

            return this;
        }

        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="configureAction">The configure action.</param>
        /// <returns>ObjectExtensionManager.</returns>
        [NotNull]
        public virtual ObjectExtensionManager AddOrUpdate(
            [NotNull] Type type,
            [CanBeNull] Action<ObjectExtensionInfo> configureAction = null)
        {
            Check.AssignableTo<IHasExtraProperties>(type, nameof(type));
            
            var extensionInfo = ObjectsExtensions.GetOrAdd(
                type,
                () => new ObjectExtensionInfo(type)
            );

            configureAction?.Invoke(extensionInfo);

            return this;
        }

        /// <summary>
        /// Gets the or null.
        /// </summary>
        /// <typeparam name="TObject">The type of the t object.</typeparam>
        /// <returns>ObjectExtensionInfo.</returns>
        [CanBeNull]
        public virtual ObjectExtensionInfo GetOrNull<TObject>()
            where TObject : IHasExtraProperties
        {
            return GetOrNull(typeof(TObject));
        }

        /// <summary>
        /// Gets the or null.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ObjectExtensionInfo.</returns>
        [CanBeNull]
        public virtual ObjectExtensionInfo GetOrNull([NotNull] Type type)
        {
            Check.AssignableTo<IHasExtraProperties>(type, nameof(type));

            return ObjectsExtensions.GetOrDefault(type);
        }

        /// <summary>
        /// Gets the extended objects.
        /// </summary>
        /// <returns>ImmutableList&lt;ObjectExtensionInfo&gt;.</returns>
        [NotNull]
        public virtual ImmutableList<ObjectExtensionInfo> GetExtendedObjects()
        {
            return ObjectsExtensions.Values.ToImmutableList();
        }
    }
}