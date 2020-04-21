// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ObjectExtensionPropertyInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.ObjectExtending
{
    /// <summary>
    /// Class ObjectExtensionPropertyInfo.
    /// </summary>
    public class ObjectExtensionPropertyInfo
    {
        /// <summary>
        /// Gets the object extension.
        /// </summary>
        /// <value>The object extension.</value>
        [NotNull]
        public ObjectExtensionInfo ObjectExtension { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public string Name { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [NotNull]
        public Type Type { get; }

        /// <summary>
        /// Indicates whether to check the other side of the object mapping
        /// if it explicitly defines the property. This property is used in;
        /// * .MapExtraPropertiesTo() extension method.
        /// * .MapExtraProperties() configuration for the AutoMapper.
        /// It this is true, these methods check if the mapping object
        /// has defined the property using the <see cref="ObjectExtensionManager" />.
        /// Default: null (unspecified, uses the default logic).
        /// </summary>
        /// <value><c>null</c> if [check pair definition on mapping] contains no value, <c>true</c> if [check pair definition on mapping]; otherwise, <c>false</c>.</value>
        public bool? CheckPairDefinitionOnMapping { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        [NotNull]
        public Dictionary<object, object> Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExtensionPropertyInfo"/> class.
        /// </summary>
        /// <param name="objectExtension">The object extension.</param>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        public ObjectExtensionPropertyInfo(
            [NotNull] ObjectExtensionInfo objectExtension, 
            [NotNull] Type type, 
            [NotNull] string name)
        {
            ObjectExtension = Check.NotNull(objectExtension, nameof(objectExtension));
            Type = Check.NotNull(type, nameof(type));
            Name = Check.NotNull(name, nameof(name));

            Configuration = new Dictionary<object, object>();
        }
    }
}
