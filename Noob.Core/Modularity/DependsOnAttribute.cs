// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DependsOnAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Used to define dependencies of a type.
    /// Implements the <see cref="System.Attribute" />
    /// Implements the <see cref="Noob.Modularity.IDependedTypesProvider" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Noob.Modularity.IDependedTypesProvider" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute, IDependedTypesProvider
    {
        /// <summary>
        /// Gets the depended types.
        /// </summary>
        /// <value>The depended types.</value>
        [NotNull]
        public Type[] DependedTypes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependsOnAttribute"/> class.
        /// </summary>
        /// <param name="dependedTypes">The depended types.</param>
        public DependsOnAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes ?? new Type[0];
        }

        /// <summary>
        /// Gets the depended types.
        /// </summary>
        /// <returns>Type[].</returns>
        public virtual Type[] GetDependedTypes()
        {
            return DependedTypes;
        }
    }
}