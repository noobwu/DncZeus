// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleLifecycleContributerBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleLifecycleContributorBase.
    /// Implements the <see cref="Noob.Modularity.IModuleLifecycleContributor" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.IModuleLifecycleContributor" />
    public abstract class ModuleLifecycleContributorBase : IModuleLifecycleContributor
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public virtual void Initialize(ApplicationInitializationContext context, IModule module)
        {
        }

        /// <summary>
        /// Shutdowns the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public virtual void Shutdown(ApplicationShutdownContext context, IModule module)
        {
        }
    }
}