﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleLoader.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity.PlugIns;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleLoader.
    /// Implements the <see cref="Noob.Modularity.IModuleLoader" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.IModuleLoader" />
    public class ModuleLoader : IModuleLoader
    {
        /// <summary>
        /// Loads the modules.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="plugInSources">The plug in sources.</param>
        /// <returns>IModuleDescriptor[].</returns>
        public IModuleDescriptor[] LoadModules(
            IServiceCollection services,
            Type startupModuleType,
            PlugInSourceList plugInSources)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(startupModuleType, nameof(startupModuleType));
            Check.NotNull(plugInSources, nameof(plugInSources));

            // 扫描模块类型，并构建模块描述对象集合。
            var modules = GetDescriptors(services, startupModuleType, plugInSources);

            // 按照模块的依赖性重新排序。
            modules = SortByDependency(modules, startupModuleType);

            // 调用模块的三个生命周期方法。
            ConfigureServices(modules, services);

            return modules.ToArray();
        }

        /// <summary>
        /// Gets the descriptors.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="plugInSources">The plug in sources.</param>
        /// <returns>List&lt;IModuleDescriptor&gt;.</returns>
        private List<IModuleDescriptor> GetDescriptors(
            IServiceCollection services, 
            Type startupModuleType,
            PlugInSourceList plugInSources)
        {
            var modules = new List<ModuleDescriptor>();

            FillModules(modules, services, startupModuleType, plugInSources);
            SetDependencies(modules);

            return modules.Cast<IModuleDescriptor>().ToList();
        }

        /// <summary>
        /// Fills the modules.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="services">The services.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <param name="plugInSources">The plug in sources.</param>
        protected virtual void FillModules(
            List<ModuleDescriptor> modules,
            IServiceCollection services,
            Type startupModuleType,
            PlugInSourceList plugInSources)
        {
            //All modules starting from the startup module
            foreach (var moduleType in ModuleHelper.FindAllModuleTypes(startupModuleType))
            {
                modules.Add(CreateModuleDescriptor(services, moduleType));
            }

            //Plugin modules
            foreach (var moduleType in plugInSources.GetAllModules())
            {
                if (modules.Any(m => m.Type == moduleType))
                {
                    continue;
                }

                modules.Add(CreateModuleDescriptor(services, moduleType, isLoadedAsPlugIn: true));
            }
        }

        /// <summary>
        /// Sets the dependencies.
        /// </summary>
        /// <param name="modules">The modules.</param>
        protected virtual void SetDependencies(List<ModuleDescriptor> modules)
        {
            //遍历整个模块描述对象集合。
            foreach (var module in modules)
            {
                SetDependencies(modules, module);
            }
        }

        /// <summary>
        /// Sorts the by dependency.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <returns>List&lt;IModuleDescriptor&gt;.</returns>
        protected virtual List<IModuleDescriptor> SortByDependency(List<IModuleDescriptor> modules, Type startupModuleType)
        {
            var sortedModules = modules.SortByDependencies(m => m.Dependencies);
            sortedModules.MoveItem(m => m.Type == startupModuleType, modules.Count - 1);
            return sortedModules;
        }

        /// <summary>
        /// Creates the module descriptor.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="moduleType">Type of the module.</param>
        /// <param name="isLoadedAsPlugIn">if set to <c>true</c> [is loaded as plug in].</param>
        /// <returns>ModuleDescriptor.</returns>
        protected virtual ModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType, bool isLoadedAsPlugIn = false)
        {
            return new ModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType), isLoadedAsPlugIn);
        }

        /// <summary>
        /// Creates the and register module.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="moduleType">Type of the module.</param>
        /// <returns>IModule.</returns>
        protected virtual IModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var module = (IModule)Activator.CreateInstance(moduleType);
            services.AddSingleton(moduleType, module);
            return module;
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="services">The services.</param>
        protected virtual void ConfigureServices(List<IModuleDescriptor> modules, IServiceCollection services)
        {
            //构造一个服务上下文，并将其添加到 IoC 容器当中。
            var context = new ServiceConfigurationContext(services);
            services.AddSingleton(context);

            foreach (var module in modules)
            {
                if (module.Instance is Module Module)
                {
                    Module.ServiceConfigurationContext = context;
                }
            }
            //执行预加载方法 PreConfigureServices。
            //PreConfigureServices
            foreach (var module in modules.Where(m => m.Instance is IPreConfigureServices))
            {
                ((IPreConfigureServices)module.Instance).PreConfigureServices(context);
            }
            //执行初始化方法 ConfigureServices。
            //ConfigureServices
            foreach (var module in modules)
            {
                if (module.Instance is Module Module)
                {
                    //是否跳过服务的自动注册，默认为 false。
                    if (!Module.SkipAutoServiceRegistration)
                    {
                        services.AddAssembly(module.Type.Assembly);
                    }
                }

                module.Instance.ConfigureServices(context);
            }
            //执行初始化完成方法 PostConfigureServices。
            //PostConfigureServices
            foreach (var module in modules.Where(m => m.Instance is IPostConfigureServices))
            {
                ((IPostConfigureServices)module.Instance).PostConfigureServices(context);
            }

            //将服务上下文置为 NULL。
            foreach (var module in modules)
            {
                if (module.Instance is Module Module)
                {
                    Module.ServiceConfigurationContext = null;
                }
            }
        }

        /// <summary>
        /// Sets the dependencies.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="module">The module.</param>
        /// <exception cref="Exception">Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName</exception>
        protected virtual void SetDependencies(List<ModuleDescriptor> modules, ModuleDescriptor module)
        {
            // 根据当前模块描述对象存储的 Type 类型，获得 DependsOn 标签依赖的类型。
            foreach (var dependedModuleType in ModuleHelper.FindDependedModuleTypes(module.Type))
            {
                // 在模块描述对象中，按照 Type 类型搜索。
                var dependedModule = modules.FirstOrDefault(m => m.Type == dependedModuleType);
                if (dependedModule == null)
                {
                    throw new Exception("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName);
                }
                //搜索到结果，则添加到当前模块描述对象的 Dependencies 属性。
                module.AddDependency(dependedModule);
            }
        }
    }
}