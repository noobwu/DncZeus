// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DependencyAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class DependencyAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class DependencyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the lifetime.
        /// </summary>
        /// <value>The lifetime.</value>
        public virtual ServiceLifetime? Lifetime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [try register].
        /// </summary>
        /// <value><c>true</c> if [try register]; otherwise, <c>false</c>.</value>
        public virtual bool TryRegister { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [replace services].
        /// </summary>
        /// <value><c>true</c> if [replace services]; otherwise, <c>false</c>.</value>
        public virtual bool ReplaceServices { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyAttribute"/> class.
        /// </summary>
        public DependencyAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyAttribute"/> class.
        /// </summary>
        /// <param name="lifetime">The lifetime.</param>
        public DependencyAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }
    }
}