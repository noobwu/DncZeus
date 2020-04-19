// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleDescriptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleDescriptor.
    /// Implements the <see cref="Noob.Modularity.IModuleDescriptor" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.IModuleDescriptor" />
    public class ModuleDescriptor : IModuleDescriptor
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; }

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        public Assembly Assembly { get; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public IModule Instance { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is loaded as plug in.
        /// </summary>
        /// <value><c>true</c> if this instance is loaded as plug in; otherwise, <c>false</c>.</value>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// Gets the dependencies.
        /// </summary>
        /// <value>The dependencies.</value>
        public IReadOnlyList<IModuleDescriptor> Dependencies => _dependencies.ToImmutableList();
        /// <summary>
        /// The dependencies
        /// </summary>
        private readonly List<IModuleDescriptor> _dependencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDescriptor"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="isLoadedAsPlugIn">if set to <c>true</c> [is loaded as plug in].</param>
        /// <exception cref="ArgumentException">Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}</exception>
        public ModuleDescriptor(
            [NotNull] Type type, 
            [NotNull] IModule instance, 
            bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentException($"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
            }

            Type = type;
            Assembly = type.Assembly;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;

            _dependencies = new List<IModuleDescriptor>();
        }

        /// <summary>
        /// Adds the dependency.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        public void AddDependency(IModuleDescriptor descriptor)
        {
            _dependencies.AddIfNotContains(descriptor);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"[ModuleDescriptor {Type.FullName}]";
        }
    }
}
