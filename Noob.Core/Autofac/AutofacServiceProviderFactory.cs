// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AutofacServiceProviderFactory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Noob.Autofac
{
    /// <summary>
    /// A factory for creating a <see cref="T:Autofac.ContainerBuilder" /> and an <see cref="T:System.IServiceProvider" />.
    /// Implements the <see cref="Microsoft.Extensions.DependencyInjection.IServiceProviderFactory{Autofac.ContainerBuilder}" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.DependencyInjection.IServiceProviderFactory{Autofac.ContainerBuilder}" />
    public class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        /// <summary>
        /// The builder
        /// </summary>
        private readonly ContainerBuilder _builder;
        /// <summary>
        /// The services
        /// </summary>
        private IServiceCollection _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public AutofacServiceProviderFactory(ContainerBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Creates a container builder from an <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <returns>A container builder that can be used to create an <see cref="T:System.IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            _services = services;

            _builder.Populate(services);

            return _builder;
        }

        /// <summary>
        /// Creates an <see cref="T:System.IServiceProvider" /> from the container builder.
        /// </summary>
        /// <param name="containerBuilder">The container builder</param>
        /// <returns>An <see cref="T:System.IServiceProvider" /></returns>
        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            Check.NotNull(containerBuilder, nameof(containerBuilder));

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}