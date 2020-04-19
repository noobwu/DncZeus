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
    /// Class RegistrationBuilderExtensions.
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
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ConfigureAbpConventions<TLimit, TActivatorData, TRegistrationStyle>(
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
                return registrationBuilder;
            }

            registrationBuilder = registrationBuilder.EnablePropertyInjection(moduleContainer, implementationType);
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
        /// Enables the property injection.
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
            //Enable Property Injection only for types in an assembly containing an Module
            if (moduleContainer.Modules.Any(m => m.Assembly == implementationType.Assembly))
            {
                registrationBuilder = registrationBuilder.PropertiesAutowired();
            }

            return registrationBuilder;
        }

        /// <summary>
        /// Adds the interceptors.
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
                registrationBuilder.InterceptedBy(
                    typeof(AsyncDeterminationInterceptor<>).MakeGenericType(interceptor)
                );
            }

            return registrationBuilder;
        }
    }
}
