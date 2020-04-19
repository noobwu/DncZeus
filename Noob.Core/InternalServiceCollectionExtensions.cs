// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="InternalServiceCollectionExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.Modularity;
using Noob.Reflection;

namespace Noob.Internal
{
    /// <summary>
    /// Class InternalServiceCollectionExtensions.
    /// </summary>
    internal static class InternalServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the core services.
        /// </summary>
        /// <param name="services">The services.</param>
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();
        }

        /// <summary>
        /// Adds the core abp services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="abpApplication">The abp application.</param>
        /// <param name="applicationCreationOptions">The application creation options.</param>
        internal static void AddCoreAbpServices(this IServiceCollection services,
            IApplication abpApplication, 
            ApplicationCreationOptions applicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(abpApplication);
            var typeFinder = new TypeFinder(assemblyFinder);

            if (!services.IsAdded<IConfiguration>())
            {
                services.ReplaceConfiguration(
                    ConfigurationHelper.BuildConfiguration(
                        applicationCreationOptions.Configuration
                    )
                );
            }

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            services.AddAssemblyOf<IApplication>();

            services.Configure<ModuleLifecycleOptions>(options =>
            {
                options.Contributors.Add<OnPreApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnPostApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationShutdownModuleLifecycleContributor>();
            });
        }
    }
}