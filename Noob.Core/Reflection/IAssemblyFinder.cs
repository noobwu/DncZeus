// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IAssemblyFinder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Reflection;

namespace Noob.Reflection
{
    /// <summary>
    /// Used to get assemblies in the application.
    /// It may not return all assemblies, but those are related with modules.
    /// </summary>
    public interface IAssemblyFinder
    {
        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <value>The assemblies.</value>
        IReadOnlyList<Assembly> Assemblies { get; }
    }
}