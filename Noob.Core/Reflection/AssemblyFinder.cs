// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AssemblyFinder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading;
using Noob.Modularity;

namespace Noob.Reflection
{
    /// <summary>
    /// Class AssemblyFinder.
    /// Implements the <see cref="Noob.Reflection.IAssemblyFinder" />
    /// </summary>
    /// <seealso cref="Noob.Reflection.IAssemblyFinder" />
    public class AssemblyFinder : IAssemblyFinder
    {
        /// <summary>
        /// The module container
        /// </summary>
        private readonly IModuleContainer _moduleContainer;

        /// <summary>
        /// The assemblies
        /// </summary>
        private readonly Lazy<IReadOnlyList<Assembly>> _assemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyFinder"/> class.
        /// </summary>
        /// <param name="moduleContainer">The module container.</param>
        public AssemblyFinder(IModuleContainer moduleContainer)
        {
            _moduleContainer = moduleContainer;

            _assemblies = new Lazy<IReadOnlyList<Assembly>>(FindAll, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <value>The assemblies.</value>
        public IReadOnlyList<Assembly> Assemblies => _assemblies.Value;

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>IReadOnlyList&lt;Assembly&gt;.</returns>
        public IReadOnlyList<Assembly> FindAll()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleContainer.Modules)
            {
                assemblies.Add(module.Type.Assembly);
            }

            return assemblies.Distinct().ToImmutableList();
        }
    }
}