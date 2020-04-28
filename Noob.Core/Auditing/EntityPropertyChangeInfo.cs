// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="EntityPropertyChangeInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// Class EntityPropertyChangeInfo.
    /// </summary>
    [Serializable]
    public class EntityPropertyChangeInfo
    {
        /// <summary>
        /// Maximum length of <see cref="PropertyName" /> property.
        /// Value: 96.
        /// </summary>
        public const int MaxPropertyNameLength = 96;

        /// <summary>
        /// Maximum length of <see cref="NewValue" /> and <see cref="OriginalValue" /> properties.
        /// Value: 512.
        /// </summary>
        public const int MaxValueLength = 512;

        /// <summary>
        /// Maximum length of <see cref="PropertyTypeFullName" /> property.
        /// Value: 512.
        /// </summary>
        public const int MaxPropertyTypeFullNameLength = 192;

        /// <summary>
        /// Creates new value.
        /// </summary>
        /// <value>The new value.</value>
        public virtual string NewValue { get; set; }

        /// <summary>
        /// Gets or sets the original value.
        /// </summary>
        /// <value>The original value.</value>
        public virtual string OriginalValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public virtual string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the property type.
        /// </summary>
        /// <value>The full name of the property type.</value>
        public virtual string PropertyTypeFullName { get; set; }
    }
}
