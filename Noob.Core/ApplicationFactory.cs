// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationFactory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;

namespace Noob
{
    /// <summary>
    /// Class ApplicationFactory.
    /// </summary>
    public static class ApplicationFactory
    {
        /// <summary>
        /// Creates the specified options action.
        /// </summary>
        /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithInternalServiceProvider.</returns>
        public static IApplicationWithInternalServiceProvider Create<TStartupModule>(
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IModule
        {
            return Create(typeof(TStartupModule), optionsAction);
        }

        /// <summary>
        /// Creates the specified startup module type.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithInternalServiceProvider.</returns>
        public static IApplicationWithInternalServiceProvider Create(
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
        {
            return new ApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
        }

        /// <summary>
        /// Creates the specified services.
        /// </summary>
        /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithExternalServiceProvider.</returns>
        public static IApplicationWithExternalServiceProvider Create<TStartupModule>(
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IModule
        {
            return Create(typeof(TStartupModule), services, optionsAction);
        }

        /// <summary>
        /// Creates the specified startup module type.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IApplicationWithExternalServiceProvider.</returns>
        public static IApplicationWithExternalServiceProvider Create(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<ApplicationCreationOptions> optionsAction = null)
        {
            return new ApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
        }
    }
}