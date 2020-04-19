// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ServiceCollectionApplicationExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob;
using Noob.Modularity;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionApplicationExtensions.
    /// </summary>
    public static class ServiceCollectionApplicationExtensions
    {
        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithExternalServiceProvider.</returns>
        public static IApplicationWithExternalServiceProvider AddApplication<TStartupModule>(
            [NotNull] this IServiceCollection services, 
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IModule
        {
            return ApplicationFactory.Create<TStartupModule>(services, optionsAction);
        }

        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithExternalServiceProvider.</returns>
        public static IApplicationWithExternalServiceProvider AddApplication(
            [NotNull] this IServiceCollection services,
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
        {
            return ApplicationFactory.Create(startupModuleType, services, optionsAction);
        }
    }
}