// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="PlugInSourceExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using JetBrains.Annotations;

namespace Noob.Modularity.PlugIns
{
    /// <summary>
    /// Class PlugInSourceExtensions.
    /// </summary>
    public static class PlugInSourceExtensions
    {
        /// <summary>
        /// Gets the modules with all dependencies.
        /// </summary>
        /// <param name="plugInSource">The plug in source.</param>
        /// <returns>Type[].</returns>
        [NotNull]
        public static Type[] GetModulesWithAllDependencies([NotNull] this IPlugInSource plugInSource)
        {
            Check.NotNull(plugInSource, nameof(plugInSource));

            return plugInSource
                .GetModules()
                .SelectMany(ModuleHelper.FindAllModuleTypes)
                .Distinct()
                .ToArray();
        }
    }
}