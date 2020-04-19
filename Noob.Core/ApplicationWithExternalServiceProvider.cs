// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationWithExternalServiceProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Noob
{
    /// <summary>
    /// Class ApplicationWithExternalServiceProvider.
    /// Implements the <see cref="Noob.ApplicationBase" />
    /// Implements the <see cref="Noob.IApplicationWithExternalServiceProvider" />
    /// </summary>
    /// <seealso cref="Noob.ApplicationBase" />
    /// <seealso cref="Noob.IApplicationWithExternalServiceProvider" />
    internal class ApplicationWithExternalServiceProvider : ApplicationBase, IApplicationWithExternalServiceProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationWithExternalServiceProvider"/> class.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        public ApplicationWithExternalServiceProvider(
            [NotNull] Type startupModuleType, 
            [NotNull] IServiceCollection services, 
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction
            ) : base(
                startupModuleType, 
                services, 
                optionsAction)
        {
            services.AddSingleton<IApplicationWithExternalServiceProvider>(this);
        }

        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public void Initialize(IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            SetServiceProvider(serviceProvider);

            InitializeModules();
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();

            if (ServiceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }
        }
    }
}
