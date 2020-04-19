// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationInitializationContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob.DependencyInjection;

namespace Noob
{
    /// <summary>
    /// Class ApplicationInitializationContext.
    /// Implements the <see cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    public class ApplicationInitializationContext : IServiceProviderAccessor
    {
        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInitializationContext"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ApplicationInitializationContext([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}