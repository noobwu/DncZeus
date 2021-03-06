﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DefaultConventionalRegistrar.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Noob.DependencyInjection
{
    //TODO: Make DefaultConventionalRegistrar extensible, so we can only define GetLifeTimeOrNull to contribute to the convention. This can be more performant!
    /// <summary>
    /// Class DefaultConventionalRegistrar.
    /// Implements the <see cref="Noob.DependencyInjection.ConventionalRegistrarBase" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ConventionalRegistrarBase" />
    public class DefaultConventionalRegistrar : ConventionalRegistrarBase
    {
        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        public override void AddType(IServiceCollection services, Type type)
        {
            // 判断类型是否标注了 DisableConventionalRegistration 特性，如果有标注，则跳过。
            if (IsConventionalRegistrationDisabled(type))
            {
                return;
            }
            // 获得 Dependency 特性，如果没有则返回 null。
            var dependencyAttribute = GetDependencyAttributeOrNull(type);
            var lifeTime = GetLifeTimeOrNull(type, dependencyAttribute);

            if (lifeTime == null)
            {
                return;
            }

            var serviceTypes = ExposedServiceExplorer.GetExposedServices(type);

            TriggerServiceExposing(services, type, serviceTypes);
            // 获得等待注册的类型定义，类型的定义优先使用 ExposeServices 特性指定的类型，如果没有则使用
            // 类型当中接口以 I 开始，后面为实现类型名称的接口。
            foreach (var serviceType in serviceTypes)
            {
                var serviceDescriptor = ServiceDescriptor.Describe(serviceType, type, lifeTime.Value);

                if (dependencyAttribute?.ReplaceServices == true)
                {
                    // 替换服务。
                    services.Replace(serviceDescriptor);
                }
                else if (dependencyAttribute?.TryRegister == true)
                {
                    // 注册服务。
                    services.TryAdd(serviceDescriptor);
                }
                else
                {
                    // 注册服务。
                    services.Add(serviceDescriptor);
                }
            }
        }

        /// <summary>
        /// Gets the dependency attribute or null.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>DependencyAttribute.</returns>
        protected virtual DependencyAttribute GetDependencyAttributeOrNull(Type type)
        {
            return type.GetCustomAttribute<DependencyAttribute>(true);
        }

        /// <summary>
        /// Gets the life time or null.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="dependencyAttribute">The dependency attribute.</param>
        /// <returns>System.Nullable&lt;ServiceLifetime&gt;.</returns>
        protected virtual ServiceLifetime? GetLifeTimeOrNull(Type type, [CanBeNull] DependencyAttribute dependencyAttribute)
        {
            return dependencyAttribute?.Lifetime ?? GetServiceLifetimeFromClassHierarcy(type);
        }

        /// <summary>
        /// Gets the service lifetime from class hierarcy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Nullable&lt;ServiceLifetime&gt;.</returns>
        protected virtual ServiceLifetime? GetServiceLifetimeFromClassHierarcy(Type type)
        {
            if (typeof(ITransientDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Transient;
            }

            if (typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Singleton;
            }

            if (typeof(IScopedDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Scoped;
            }

            return null;
        }
    }
}