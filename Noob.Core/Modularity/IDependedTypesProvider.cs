// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IDependedTypesProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IDependedTypesProvider
    /// </summary>
    public interface IDependedTypesProvider
    {
        /// <summary>
        /// Gets the depended types.
        /// </summary>
        /// <returns>Type[].</returns>
        [NotNull]
        Type[] GetDependedTypes();
    }
}