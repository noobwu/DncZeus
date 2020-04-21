// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ServiceCollectionConventionalRegistrationExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
using Noob.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionConventionalRegistrationExtensions.
    /// </summary>
    public static class ServiceCollectionConventionalRegistrationExtensions
    {
        /// <summary>
        /// Adds the conventional registrar.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="registrar">The registrar.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddConventionalRegistrar(this IServiceCollection services, IConventionalRegistrar registrar)
        {
            GetOrCreateRegistrarList(services).Add(registrar);
            return services;
        }

        /// <summary>
        /// Gets the conventional registrars.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>List&lt;IConventionalRegistrar&gt;.</returns>
        internal static List<IConventionalRegistrar> GetConventionalRegistrars(this IServiceCollection services)
        {
            return GetOrCreateRegistrarList(services);
        }

        /// <summary>
        /// Gets the or create registrar list.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ConventionalRegistrarList.</returns>
        private static ConventionalRegistrarList GetOrCreateRegistrarList(IServiceCollection services)
        {
            var conventionalRegistrars = services.GetSingletonInstanceOrNull<IObjectAccessor<ConventionalRegistrarList>>()?.Value;
            if (conventionalRegistrars == null)
            {
                conventionalRegistrars = new ConventionalRegistrarList { new DefaultConventionalRegistrar() };
                services.AddObjectAccessor(conventionalRegistrars);
            }

            return conventionalRegistrars;
        }

        /// <summary>
        /// Adds the assembly of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddAssemblyOf<T>(this IServiceCollection services)
        {
            return services.AddAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Adds the assembly.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly)
        {
            //获得所有规约注册器，然后调用规约注册器的 AddAssmbly 方法注册类型。
            foreach (var registrar in services.GetConventionalRegistrars())
            {
                registrar.AddAssembly(services, assembly);
            }

            return services;
        }

        /// <summary>
        /// Adds the types.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="types">The types.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddTypes(this IServiceCollection services, params Type[] types)
        {
            foreach (var registrar in services.GetConventionalRegistrars())
            {
                registrar.AddTypes(services, types);
            }

            return services;
        }

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <typeparam name="TType">The type of the t type.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddType<TType>(this IServiceCollection services)
        {
            return services.AddType(typeof(TType));
        }

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddType(this IServiceCollection services, Type type)
        {
            foreach (var registrar in services.GetConventionalRegistrars())
            {
                registrar.AddType(services, type);
            }

            return services;
        }
    }
}