// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2019-10-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-19
// ***********************************************************************
// <copyright file="IntegratedTest.cs" company="Noob.NUnitTests">
//     Copyright (c) Noob.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Modularity;

/// <summary>
/// The TestApp namespace.
/// </summary>
namespace Noob
{

    /// <summary>
    /// Class IntegratedTest.
    /// Implements the <see cref="Noob.TestApp.TestBaseWithServiceProvider" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
    /// <seealso cref="Noob.TestApp.TestBaseWithServiceProvider" />
    /// <seealso cref="System.IDisposable" />isposable" /&gt;
    /// <seealso cref="where" />
    public abstract class IntegratedTest<TStartupModule> : TestBaseWithServiceProvider, IDisposable
        where TStartupModule : IModule
    {
        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
        protected IApplication Application { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegratedTest" /> class.
        /// </summary>
        protected IntegratedTest()
        {
            var services = CreateServiceCollection();

            BeforeAddApplication(services);

            services.TryAddObjectAccessor<IServiceProvider>();
            ServiceConfigurationContext = new ServiceConfigurationContext(services);

            var application = services.AddApplication<TStartupModule>(SetApplicationCreationOptions);
            Application = application;

            AfterAddApplication(services);

            var options = new ApplicationCreationOptions(ServiceConfigurationContext.Services);
            SetApplicationCreationOptions(options);

            ConfigureServices(ServiceConfigurationContext);

            ServiceProvider = CreateServiceProvider(services);
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;

            ApplicationInitializationContext appInitContext = new ApplicationInitializationContext(ServiceProvider);
            OnApplicationInitialization(appInitContext);
        }
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }
        /// <summary>
        /// Creates the service collection.
        /// </summary>
        /// <returns>IServiceCollection.</returns>
        protected virtual IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        /// <summary>
        /// Called when [application initialization].
        /// </summary>
        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        /// <summary>
        /// Befores the add application.
        /// </summary>
        /// <param name="services">The services.</param>
        protected virtual void BeforeAddApplication(IServiceCollection services)
        {

        }
        /// <summary>
        /// Sets the abp application creation options.
        /// </summary>
        /// <param name="options">The options.</param>
        protected virtual void SetApplicationCreationOptions(ApplicationCreationOptions options)
        {

        }
        /// <summary>
        /// Afters the add application.
        /// </summary>
        /// <param name="services">The services.</param>
        protected virtual void AfterAddApplication(IServiceCollection services)
        {

        }
        /// <summary>
        /// Creates the service provider.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceProvider.</returns>
        protected virtual IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            // 接管自带的 IoC Container。
            return services.BuildServiceProviderFromFactory();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {

        }

        #region Module

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
                    throw new Exception($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)} methods.");
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
        /// Configures the specified configure options.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="configureOptions">The configure options.</param>
        protected void Configure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }
        #endregion        

    }
}
