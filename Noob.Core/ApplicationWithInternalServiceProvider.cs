// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationWithInternalServiceProvider.cs" company="Noob.Core">
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
    /// Class ApplicationWithInternalServiceProvider.
    /// Implements the <see cref="Noob.ApplicationBase" />
    /// Implements the <see cref="Noob.IApplicationWithInternalServiceProvider" />
    /// </summary>
    /// <seealso cref="Noob.ApplicationBase" />
    /// <seealso cref="Noob.IApplicationWithInternalServiceProvider" />
    internal class ApplicationWithInternalServiceProvider : ApplicationBase, IApplicationWithInternalServiceProvider
    {
        /// <summary>
        /// Gets the service scope.
        /// </summary>
        /// <value>The service scope.</value>
        public IServiceScope ServiceScope { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationWithInternalServiceProvider"/> class.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="optionsAction">The options action.</param>
        public ApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction
            ) : this(
            startupModuleType,
            new ServiceCollection(),
            optionsAction)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationWithInternalServiceProvider"/> class.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        private ApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType, 
            [NotNull] IServiceCollection services, 
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction
            ) : base(
                startupModuleType, 
                services, 
                optionsAction)
        {
            Services.AddSingleton<IApplicationWithInternalServiceProvider>(this);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            ServiceScope = Services.BuildServiceProviderFromFactory().CreateScope();
            SetServiceProvider(ServiceScope.ServiceProvider);
            
            InitializeModules();
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            ServiceScope.Dispose();
        }
    }
}