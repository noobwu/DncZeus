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
        /// <param name="aplication">The  application.</param>
        /// <param name="applicationCreationOptions">The application creation options.</param>
        internal static void AddAppCoreServices(this IServiceCollection services,
            IApplication aplication, 
            ApplicationCreationOptions applicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();

            //StartupModules=>Modules=>Assemblies
            var assemblyFinder = new AssemblyFinder(aplication);

            //封装了所有程序集中所有的Types
            var typeFinder = new TypeFinder(assemblyFinder);

            if (!services.IsAdded<IConfiguration>())
            {
                //生成Configuration对象并注册（默认规则appsetting.json环境变量,命令行参数等）
                services.ReplaceConfiguration(
                    ConfigurationHelper.BuildConfiguration(
                        applicationCreationOptions.Configuration
                    )
                );
            }

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            //添加Noob.Core程序集（基于约定方式的，注册程序集中services）IMPORTANT
            services.AddAssemblyOf<IApplication>();

            //配置模块声明周期的HOOKS
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