// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IModuleLifecycleContributor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Noob.DependencyInjection;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleLifecycleContributor
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public interface IModuleLifecycleContributor : ITransientDependency
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        void Initialize([NotNull] ApplicationInitializationContext context, [NotNull] IModule module);

        /// <summary>
        /// Shutdowns the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        void Shutdown([NotNull] ApplicationShutdownContext context, [NotNull] IModule module);
    }
}
