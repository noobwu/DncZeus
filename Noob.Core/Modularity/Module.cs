// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Module.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Noob.Modularity
{
    /// <summary>
    /// Class Module.
    /// Implements the <see cref="Noob.Modularity.IModule" />
    /// Implements the <see cref="Noob.Modularity.IOnPreApplicationInitialization" />
    /// Implements the <see cref="Noob.IOnApplicationInitialization" />
    /// Implements the <see cref="Noob.Modularity.IOnPostApplicationInitialization" />
    /// Implements the <see cref="Noob.IOnApplicationShutdown" />
    /// Implements the <see cref="Noob.Modularity.IPreConfigureServices" />
    /// Implements the <see cref="Noob.Modularity.IPostConfigureServices" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.IModule" />
    /// <seealso cref="Noob.Modularity.IOnPreApplicationInitialization" />
    /// <seealso cref="Noob.IOnApplicationInitialization" />
    /// <seealso cref="Noob.Modularity.IOnPostApplicationInitialization" />
    /// <seealso cref="Noob.IOnApplicationShutdown" />
    /// <seealso cref="Noob.Modularity.IPreConfigureServices" />
    /// <seealso cref="Noob.Modularity.IPostConfigureServices" />
    public abstract class Module : 
        IModule,
        IOnPreApplicationInitialization,
        IOnApplicationInitialization,
        IOnPostApplicationInitialization,
        IOnApplicationShutdown, 
        IPreConfigureServices, 
        IPostConfigureServices
    {
        /// <summary>
        /// Gets or sets a value indicating whether [skip automatic service registration].
        /// </summary>
        /// <value><c>true</c> if [skip automatic service registration]; otherwise, <c>false</c>.</value>
        protected internal bool SkipAutoServiceRegistration { get; protected set; }

        /// <summary>
        /// Gets the service configuration context.
        /// </summary>
        /// <value>The service configuration context.</value>
        /// <exception cref="Exception"></exception>
        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new Exception($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }

        /// <summary>
        /// The service configuration context
        /// </summary>
        private ServiceConfigurationContext _serviceConfigurationContext;

        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        /// <summary>
        /// Posts the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        /// <summary>
        /// Called when [pre application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            
        }

        /// <summary>
        /// Called when [application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            
        }

        /// <summary>
        /// Called when [post application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        /// <summary>
        /// Called when [application shutdown].
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }

        /// <summary>
        /// Determines whether the specified type is module.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is module; otherwise, <c>false</c>.</returns>
        public static bool IsModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IModule).GetTypeInfo().IsAssignableFrom(type);
        }

        /// <summary>
        /// Checks the type of the module.
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        /// <exception cref="ArgumentException">Given type is not an ABP module: " + moduleType.AssemblyQualifiedName</exception>
        internal static void CheckModuleType(Type moduleType)
        {
            if (!IsModule(moduleType))
            {
                throw new ArgumentException("Given type is not an ABP module: " + moduleType.AssemblyQualifiedName);
            }
        }

        /// <summary>
        /// Configures the specified configure options.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configureOptions">The configure options.</param>
        protected void Configure<TOptions>(Action<TOptions> configureOptions) 
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }

        /// <summary>
        /// Configures the specified name.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        protected void Configure<TOptions>(string name, Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(name, configureOptions);
        }

        /// <summary>
        /// Configures the specified configuration.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configuration">The configuration.</param>
        protected void Configure<TOptions>(IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration);
        }

        /// <summary>
        /// Configures the specified configuration.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configureBinder">The configure binder.</param>
        protected void Configure<TOptions>(IConfiguration configuration, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
        }

        /// <summary>
        /// Configures the specified name.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="configuration">The configuration.</param>
        protected void Configure<TOptions>(string name, IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
        }

        /// <summary>
        /// Pres the configure.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configureOptions">The configure options.</param>
        protected void PreConfigure<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PreConfigure(configureOptions);
        }

        /// <summary>
        /// Posts the configure.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configureOptions">The configure options.</param>
        protected void PostConfigure<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PostConfigure(configureOptions);
        }

        /// <summary>
        /// Posts the configure all.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configureOptions">The configure options.</param>
        protected void PostConfigureAll<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PostConfigureAll(configureOptions);
        }
    }
}