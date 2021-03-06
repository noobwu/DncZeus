// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IModuleContainer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleContainer
    /// </summary>
    public interface IModuleContainer
    {
        /// <summary>
        /// Gets the modules.
        /// </summary>
        /// <value>The modules.</value>
        [NotNull]
        IReadOnlyList<IModuleDescriptor> Modules { get; }
    }
}