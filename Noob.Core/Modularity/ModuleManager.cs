// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleManager.
    /// Implements the <see cref="Noob.Modularity.IModuleManager" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.IModuleManager" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class ModuleManager : IModuleManager, ISingletonDependency
    {
        /// <summary>
        /// The module container
        /// </summary>
        private readonly IModuleContainer _moduleContainer;
        /// <summary>
        /// The lifecycle contributors
        /// </summary>
        private readonly IEnumerable<IModuleLifecycleContributor> _lifecycleContributors;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ModuleManager> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleManager"/> class.
        /// </summary>
        /// <param name="moduleContainer">The module container.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public ModuleManager(
            IModuleContainer moduleContainer,
            ILogger<ModuleManager> logger,
            IOptions<ModuleLifecycleOptions> options,
            IServiceProvider serviceProvider)
        {
            _moduleContainer = moduleContainer;
            _logger = logger;

            _lifecycleContributors = options.Value
                .Contributors
                .Select(serviceProvider.GetRequiredService)
                .Cast<IModuleLifecycleContributor>()
                .ToArray();
        }

        /// <summary>
        /// Initializes the modules.
        /// </summary>
        /// <param name="context">The context.</param>
        public void InitializeModules(ApplicationInitializationContext context)
        {
            LogListOfModules();
            // 遍历应用程序的几个生命周期。
            foreach (var Contributor in _lifecycleContributors)
            {
                //遍历所有的模块，将模块实例传入具体的 Contributor，方便在其内部调用具体的生命周期方法。
                foreach (var module in _moduleContainer.Modules)
                {
                    Contributor.Initialize(context, module.Instance);
                }
            }

            _logger.LogInformation("Initialized all ABP modules.");
        }

        /// <summary>
        /// Logs the list of modules.
        /// </summary>
        private void LogListOfModules()
        {
            _logger.LogInformation("Loaded ABP modules:");

            foreach (var module in _moduleContainer.Modules)
            {
                _logger.LogInformation("- " + module.Type.FullName);
            }
        }

        /// <summary>
        /// Shutdowns the modules.
        /// </summary>
        /// <param name="context">The context.</param>
        public void ShutdownModules(ApplicationShutdownContext context)
        {
            var modules = _moduleContainer.Modules.Reverse().ToList();

            foreach (var Contributor in _lifecycleContributors)
            {
                foreach (var module in modules)
                {
                    Contributor.Shutdown(context, module.Instance);
                }
            }
        }
    }
}