// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ConventionalRegistrarBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Noob.Reflection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ConventionalRegistrarBase.
    /// Implements the <see cref="Noob.DependencyInjection.IConventionalRegistrar" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IConventionalRegistrar" />
    public abstract class ConventionalRegistrarBase : IConventionalRegistrar
    {
        /// <summary>
        /// Adds the assembly.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="assembly">The assembly.</param>
        public virtual void AddAssembly(IServiceCollection services, Assembly assembly)
        {
            //获得程序集内的所有类型，过滤掉抽象类和泛型类型。
            var types = AssemblyHelper
                .GetAllTypes(assembly)
                .Where(
                    type => type != null &&
                            type.IsClass &&
                            !type.IsAbstract &&
                            !type.IsGenericType
                ).ToArray();

            AddTypes(services, types);
        }

        /// <summary>
        /// Adds the types.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="types">The types.</param>
        public virtual void AddTypes(IServiceCollection services, params Type[] types)
        {
            foreach (var type in types)
            {
                AddType(services, type);
            }
        }

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        public abstract void AddType(IServiceCollection services, Type type);

        /// <summary>
        /// Determines whether [is conventional registration disabled] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is conventional registration disabled] [the specified type]; otherwise, <c>false</c>.</returns>
        protected virtual bool IsConventionalRegistrationDisabled(Type type)
        {
            return type.IsDefined(typeof(DisableConventionalRegistrationAttribute), true);
        }

        /// <summary>
        /// Triggers the service exposing.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <param name="serviceTypes">The service types.</param>
        protected virtual void TriggerServiceExposing(IServiceCollection services, Type implementationType, List<Type> serviceTypes)
        {
            var exposeActions = services.GetExposingActionList();
            if (exposeActions.Any())
            {
                var args = new OnServiceExposingContext(implementationType, serviceTypes);
                foreach (var action in exposeActions)
                {
                    action(args);
                }
            }
        }
    }
}