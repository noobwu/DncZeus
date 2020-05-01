// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IntegratedTest.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;

namespace Noob.Testing
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
        where TStartupModule : IModule
    {
        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
        protected IApplication Application { get; }

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        protected override IServiceProvider ServiceProvider => Application.ServiceProvider;

        /// <summary>
        /// Gets the root service provider.
        /// </summary>
        /// <value>The root service provider.</value>
        protected IServiceProvider RootServiceProvider { get; }

        /// <summary>
        /// Gets the test service scope.
        /// </summary>
        /// <value>The test service scope.</value>
        protected IServiceScope TestServiceScope { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbpIntegratedTest{TStartupModule}" /> class.
        /// </summary>
        protected IntegratedTest()
        {
            var services = CreateServiceCollection();

            BeforeAddApplication(services);

            var application = services.AddApplication<TStartupModule>(SetApplicationCreationOptions);
            Application = application;

            AfterAddApplication(services);

            RootServiceProvider = CreateServiceProvider(services);
            TestServiceScope = RootServiceProvider.CreateScope();

            application.Initialize(TestServiceScope.ServiceProvider);
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
        /// Befores the add application.
        /// </summary>
        /// <param name="services">The services.</param>
        protected virtual void BeforeAddApplication(IServiceCollection services)
        {

        }


        /// <summary>
        /// Sets the application creation options.
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
            return services.BuildServiceProviderFromFactory();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            Application.Shutdown();
            TestServiceScope.Dispose();
            Application.Dispose();
        }
    }
}
