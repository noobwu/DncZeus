// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="ObjectExtensionPropertyInfoEfCoreMappingOptions.cs" company="Noob.Core">
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
    /// Class ObjectExtensionPropertyInfoEfCoreMappingOptions.
    /// </summary>
    public class ObjectExtensionPropertyInfoEfCoreMappingOptions
    {
        /// <summary>
        /// Gets the extension property.
        /// </summary>
        /// <value>The extension property.</value>
        [NotNull]
        public ObjectExtensionPropertyInfo ExtensionProperty { get; }

        /// <summary>
        /// Gets the object extension.
        /// </summary>
        /// <value>The object extension.</value>
        [NotNull]
        public ObjectExtensionInfo ObjectExtension => ExtensionProperty.ObjectExtension;

        /// <summary>
        /// Gets or sets the property build action.
        /// </summary>
        /// <value>The property build action.</value>
        [CanBeNull]
        public Action<PropertyBuilder> PropertyBuildAction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExtensionPropertyInfoEfCoreMappingOptions"/> class.
        /// </summary>
        /// <param name="extensionProperty">The extension property.</param>
        /// <param name="propertyBuildAction">The property build action.</param>
        public ObjectExtensionPropertyInfoEfCoreMappingOptions(
            [NotNull] ObjectExtensionPropertyInfo extensionProperty,
            [CanBeNull] Action<PropertyBuilder> propertyBuildAction = null)
        {
            ExtensionProperty = Check.NotNull(extensionProperty, nameof(extensionProperty));
            
            PropertyBuildAction = propertyBuildAction;
        }
    }
}