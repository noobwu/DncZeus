// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="TypeFinder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Noob.Reflection
{
    /// <summary>
    /// Class TypeFinder.
    /// Implements the <see cref="ITypeFinder" />
    /// </summary>
    /// <seealso cref="ITypeFinder" />
    public class TypeFinder : ITypeFinder
    {
        /// <summary>
        /// The assembly finder
        /// </summary>
        private readonly IAssemblyFinder _assemblyFinder;

        /// <summary>
        /// The types
        /// </summary>
        private readonly Lazy<IReadOnlyList<Type>> _types;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeFinder"/> class.
        /// </summary>
        /// <param name="assemblyFinder">The assembly finder.</param>
        public TypeFinder(IAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;

            _types = new Lazy<IReadOnlyList<Type>>(FindAll, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <value>The types.</value>
        public IReadOnlyList<Type> Types => _types.Value;

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>IReadOnlyList&lt;Type&gt;.</returns>
        private IReadOnlyList<Type> FindAll()
        {
            var allTypes = new List<Type>();

            foreach (var assembly in _assemblyFinder.Assemblies)
            {
                try
                {
                    var typesInThisAssembly = AssemblyHelper.GetAllTypes(assembly);

                    if (!typesInThisAssembly.Any())
                    {
                        continue;
                    }

                    allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
                catch (Exception)
                {
                    //TODO: Trigger a global event?
                }
            }

            return allTypes;
        }
    }
}