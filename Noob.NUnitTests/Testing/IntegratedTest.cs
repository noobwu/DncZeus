// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IntegratedTest.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;
namespace Noob
{
    /// <summary>
    /// Class IntegratedTest.
    /// Implements the <see cref="Noob.TestBaseWithServiceProvider" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
    /// <seealso cref="Noob.TestBaseWithServiceProvider" />
    /// <seealso cref="System.IDisposable" />
    public abstract class IntegratedTest<TStartupModule> : TestBaseWithServiceProvider, IDisposable
       where TStartupModule : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegratedTest{TStartupModule}" /> class.
        /// </summary>
        protected IntegratedTest()
        {
            var services = CreateServiceCollection();

            ServiceConfigurationContext = new ServiceConfigurationContext(services);

            ServiceProvider = CreateServiceProvider(services);
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
