// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="RegistrationBuilderExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Noob.Castle.DynamicProxy;
using Noob.DependencyInjection;
using Noob.Modularity;

namespace Autofac.Builder
{
    /// <summary>
    /// Class AbpRegistrationBuilderExtensions.
    /// </summary>
    public static class RegistrationBuilderExtensions
    {
        /// <summary>
        /// Configures the abp conventions.
        /// </summary>
        /// <typeparam name="TLimit">The type of the t limit.</typeparam>
        /// <typeparam name="TActivatorData">The type of the t activator data.</typeparam>
        /// <typeparam name="TRegistrationStyle">The type of the t registration style.</typeparam>
        /// <param name="registrationBuilder">The registration builder.</param>
        /// <param name="moduleContainer">The module container.</param>
        /// <param name="registrationActionList">The registration action list.</param>
        /// <returns>IRegistrationBuilder&lt;TLimit, TActivatorData, TRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ConfigureConventions<TLimit, TActivatorData, TRegistrationStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder,
                IModuleContainer moduleContainer,
                ServiceRegistrationActionList registrationActionList)
            where TActivatorData : ReflectionActivatorData
        {
            var serviceType = registrationBuilder.RegistrationData.Services.OfType<IServiceWithType>().FirstOrDefault()?.ServiceType;
            if (serviceType == null)
            {
                return registrationBuilder;
            }

            var implementationType = registrationBuilder.ActivatorData.ImplementationType;
            if (implementationType == null)
            {
                return registrationBuilder;//没有实现指定类型（对应于ImplementationType属性）
            }
            //当前type程序集包含模块则开启属性注入
            registrationBuilder = registrationBuilder.EnablePropertyInjection(moduleContainer, implementationType);
            //调用registration HOOK  如果有拦截器，则添加拦截器
            registrationBuilder = registrationBuilder.InvokeRegistrationActions(registrationActionList, serviceType, implementationType);

            return registrationBuilder;
        }

        /// <summary>
        /// Invokes the registration actions.
        /// </summary>
        /// <typeparam name="TLimit">The type of the t limit.</typeparam>
        /// <typeparam name="TActivatorData">The type of the t activator data.</typeparam>
        /// <typeparam name="TRegistrationStyle">The type of the t registration style.</typeparam>
        /// <param name="registrationBuilder">The registration builder.</param>
        /// <param name="registrationActionList">The registration action list.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns>IRegistrationBuilder&lt;TLimit, TActivatorData, TRegistrationStyle&gt;.</returns>
        private static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> InvokeRegistrationActions<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder, ServiceRegistrationActionList registrationActionList, Type serviceType, Type implementationType)
            where TActivatorData : ReflectionActivatorData
        {
            var serviceRegistredArgs = new OnServiceRegistredContext(serviceType, implementationType);

            foreach (var registrationAction in registrationActionList)
            {
                //执行注册操作
                registrationAction.Invoke(serviceRegistredArgs);
            }

            if (serviceRegistredArgs.Interceptors.Any())
            {
                registrationBuilder = registrationBuilder.AddInterceptors(
                    serviceType,
                    serviceRegistredArgs.Interceptors
                );
            }

            return registrationBuilder;
        }

        /// <summary>
        ///  启用属性注入.
        /// </summary>
        /// <typeparam name="TLimit">The type of the t limit.</typeparam>
        /// <typeparam name="TActivatorData">The type of the t activator data.</typeparam>
        /// <typeparam name="TRegistrationStyle">The type of the t registration style.</typeparam>
        /// <param name="registrationBuilder">The registration builder.</param>
        /// <param name="moduleContainer">The module container.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns>IRegistrationBuilder&lt;TLimit, TActivatorData, TRegistrationStyle&gt;.</returns>
        private static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> EnablePropertyInjection<TLimit, TActivatorData, TRegistrationStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder,
                IModuleContainer moduleContainer,
                Type implementationType)
            where TActivatorData : ReflectionActivatorData
        {
            //Enable Property Injection only for types in an assembly containing an AbpModule
            if (moduleContainer.Modules.Any(m => m.Assembly == implementationType.Assembly))
            {
                //属性注入
                registrationBuilder = registrationBuilder.PropertiesAutowired();
            }
            return registrationBuilder;
        }

        /// <summary>
        /// 增加拦截器
        /// </summary>
        /// <typeparam name="TLimit">The type of the t limit.</typeparam>
        /// <typeparam name="TActivatorData">The type of the t activator data.</typeparam>
        /// <typeparam name="TRegistrationStyle">The type of the t registration style.</typeparam>
        /// <param name="registrationBuilder">The registration builder.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="interceptors">The interceptors.</param>
        /// <returns>IRegistrationBuilder&lt;TLimit, TActivatorData, TRegistrationStyle&gt;.</returns>
        private static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> AddInterceptors<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder,
            Type serviceType,
            IEnumerable<Type> interceptors)
            where TActivatorData : ReflectionActivatorData
        {
            if (serviceType.IsInterface)
            {
                registrationBuilder = registrationBuilder.EnableInterfaceInterceptors();
            }
            else
            {
                (registrationBuilder as IRegistrationBuilder<TLimit, ConcreteReflectionActivatorData, TRegistrationStyle>)?.EnableClassInterceptors();
            }

            foreach (var interceptor in interceptors)
            {
                //创建代理类来拦截
                registrationBuilder.InterceptedBy(
                    typeof(AsyncDeterminationInterceptor<>).MakeGenericType(interceptor)
                );
            }

            return registrationBuilder;
        }
    }
}
