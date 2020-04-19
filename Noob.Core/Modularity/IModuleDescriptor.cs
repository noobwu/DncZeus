// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="IModuleDescriptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleDescriptor
    /// </summary>
    public interface IModuleDescriptor
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; }

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        Assembly Assembly { get; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        IModule Instance { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is loaded as plug in.
        /// </summary>
        /// <value><c>true</c> if this instance is loaded as plug in; otherwise, <c>false</c>.</value>
        bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// Gets the dependencies.
        /// </summary>
        /// <value>The dependencies.</value>
        IReadOnlyList<IModuleDescriptor> Dependencies { get; }
    }
}