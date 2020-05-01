// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Modularity;
using Noob.Internal;
namespace Noob
{
    /// <summary>
    /// Class ApplicationBase.
    /// Implements the <see cref="Noob.IApplication" />
    /// </summary>
    /// <seealso cref="Noob.IApplication" />
    public abstract class ApplicationBase : IApplication
    {
        /// <summary>
        /// Type of the startup (entrance) module of the application.
        /// </summary>
        /// <value>The type of the startup module.</value>
        [NotNull]
        public Type StartupModuleType { get; }

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// List of services registered to this application.
        /// Can not add new services to this collection after application initialize.
        /// </summary>
        /// <value>The services.</value>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets the modules.
        /// </summary>
        /// <value>The modules.</value>
        public IReadOnlyList<IModuleDescriptor> Modules { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBase"/> class.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        internal ApplicationBase(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction)
        {
            Check.NotNull(startupModuleType, nameof(startupModuleType));
            Check.NotNull(services, nameof(services));

            StartupModuleType = startupModuleType;
            Services = services;

            //ObjectAccessor采用头插法，放入其中的查找较快。 AddObjectAccessor一注册注册一对儿：ObjectAccessor；IObjectAccessor
            services.TryAddObjectAccessor<IServiceProvider>();

            var options = new ApplicationCreationOptions(services);
            optionsAction?.Invoke(options);

            // 当前的 Application 就是一个模块容器。
            services.AddSingleton<IApplication>(this);
            services.AddSingleton<IModuleContainer>(this);

            //核心基本服务  Options  Logging Localization
            services.AddCoreServices();
            // 注入模块加载类，以及模块的四个应用程序生命周期。
            services.AddAppCoreServices(this, options);

            //遍历所有模块，并按照预加载、初始化、初始化完成的顺序执行其生命周期方法。
            Modules = LoadModules(services, options);
        }

        /// <summary>
        /// Used to gracefully shutdown the application and all modules.
        /// </summary>
        public virtual void Shutdown()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModules(new ApplicationShutdownContext(scope.ServiceProvider));
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            //TODO: Shutdown if not done before?
        }

        /// <summary>
        /// Sets the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }

        /// <summary>
        /// Initializes the modules.
        /// </summary>
        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitializeModules(new ApplicationInitializationContext(scope.ServiceProvider));
            }
        }

        /// <summary>
        /// Loads the modules.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="options">The options.</param>
        /// <returns>IReadOnlyList&lt;IModuleDescriptor&gt;.</returns>
        private IReadOnlyList<IModuleDescriptor> LoadModules(IServiceCollection services, ApplicationCreationOptions options)
        {
            return services
                .GetSingletonInstance<IModuleLoader>()
                .LoadModules(
                    services,
                    StartupModuleType,
                    options.PlugInSources
                );
        }
    }
}