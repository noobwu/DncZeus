// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IModuleLoader.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity.PlugIns;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleLoader
    /// </summary>
    public interface IModuleLoader
    {
        /// <summary>
        /// Loads the modules.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="plugInSources">The plug in sources.</param>
        /// <returns>IModuleDescriptor[].</returns>
        [NotNull]
        IModuleDescriptor[] LoadModules(
            [NotNull] IServiceCollection services,
            [NotNull] Type startupModuleType,
            [NotNull] PlugInSourceList plugInSources
        );
    }
}
