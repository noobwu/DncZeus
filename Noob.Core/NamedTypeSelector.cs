// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="NamedTypeSelector.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob
{
    /// <summary>
    /// Used to represent a named type selector.
    /// </summary>
    public class NamedTypeSelector
    {
        /// <summary>
        /// Name of the selector.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Func<Type, bool> Predicate { get; set; }

        /// <summary>
        /// Creates new <see cref="NamedTypeSelector" /> object.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="predicate">Predicate</param>
        public NamedTypeSelector(string name, Func<Type, bool> predicate)
        {
            Name = name;
            Predicate = predicate;
        }
    }
}