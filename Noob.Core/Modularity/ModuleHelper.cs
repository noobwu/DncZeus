// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleHelper.
    /// </summary>
    internal static class ModuleHelper
    {
        /// <summary>
        /// Finds all module types.
        /// </summary>
        /// <param name="startupModuleType">Type of the startup module.</param>
        /// <returns>List&lt;Type&gt;.</returns>
        public static List<Type> FindAllModuleTypes(Type startupModuleType)
        {
            var moduleTypes = new List<Type>();
            //递归构建模块类型集合。
            AddModuleAndDependenciesResursively(moduleTypes, startupModuleType);
            return moduleTypes;
        }

        /// <summary>
        /// Finds the depended module types.
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        /// <returns>List&lt;Type&gt;.</returns>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            Module.CheckModuleType(moduleType);

            var dependencies = new List<Type>();

            //从传入的类型当中，获得 DependsOn 特性。
            var dependencyDescriptors = moduleType
                .GetCustomAttributes()
                .OfType<IDependedTypesProvider>();

            //可能有多个特性标签，遍历。
            foreach (var descriptor in dependencyDescriptors)
            {
                //根据特性存储的类型，将其添加到返回结果当中。
                foreach (var dependedModuleType in descriptor.GetDependedTypes())
                {
                    dependencies.AddIfNotContains(dependedModuleType);
                }
            }

            return dependencies;
        }

        /// <summary>
        /// Adds the module and dependencies resursively.
        /// </summary>
        /// <param name="moduleTypes">The module types.</param>
        /// <param name="moduleType">Type of the module.</param>
        private static void AddModuleAndDependenciesResursively(List<Type> moduleTypes, Type moduleType)
        {
            //检测传入的类型是否是模块类。
            Module.CheckModuleType(moduleType);

            //集合已经包含了类型定义，则返回。
            if (moduleTypes.Contains(moduleType))
            {
                return;
            }

            moduleTypes.Add(moduleType);

            //遍历其 DependsOn 特性定义的类型，递归将其类型添加到集合当中。
            foreach (var dependedModuleType in FindDependedModuleTypes(moduleType))
            {
                AddModuleAndDependenciesResursively(moduleTypes, dependedModuleType);
            }
        }
    }
}
