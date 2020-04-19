// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DefaultModuleLifecycleContributor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Modularity
{
    /// <summary>
    /// Class OnApplicationInitializationModuleLifecycleContributor.
    /// Implements the <see cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    public class OnApplicationInitializationModuleLifecycleContributor : ModuleLifecycleContributorBase
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public override void Initialize(ApplicationInitializationContext context, IModule module)
        {
            (module as IOnApplicationInitialization)?.OnApplicationInitialization(context);
        }
    }

    /// <summary>
    /// Class OnApplicationShutdownModuleLifecycleContributor.
    /// Implements the <see cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    public class OnApplicationShutdownModuleLifecycleContributor : ModuleLifecycleContributorBase
    {
        /// <summary>
        /// Shutdowns the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public override void Shutdown(ApplicationShutdownContext context, IModule module)
        {
            (module as IOnApplicationShutdown)?.OnApplicationShutdown(context);
        }
    }

    /// <summary>
    /// Class OnPreApplicationInitializationModuleLifecycleContributor.
    /// Implements the <see cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    public class OnPreApplicationInitializationModuleLifecycleContributor : ModuleLifecycleContributorBase
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public override void Initialize(ApplicationInitializationContext context, IModule module)
        {
            (module as IOnPreApplicationInitialization)?.OnPreApplicationInitialization(context);
        }
    }

    /// <summary>
    /// Class OnPostApplicationInitializationModuleLifecycleContributor.
    /// Implements the <see cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.ModuleLifecycleContributorBase" />
    public class OnPostApplicationInitializationModuleLifecycleContributor : ModuleLifecycleContributorBase
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="module">The module.</param>
        public override void Initialize(ApplicationInitializationContext context, IModule module)
        {
            (module as IOnPostApplicationInitialization)?.OnPostApplicationInitialization(context);
        }
    }
}