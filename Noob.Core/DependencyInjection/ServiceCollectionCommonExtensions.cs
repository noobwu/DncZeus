// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ServiceCollectionCommonExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Noob;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionCommonExtensions.
    /// </summary>
    public static class ServiceCollectionCommonExtensions
    {
        /// <summary>
        /// Determines whether the specified services is added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns><c>true</c> if the specified services is added; otherwise, <c>false</c>.</returns>
        public static bool IsAdded<T>(this IServiceCollection services)
        {
            return services.IsAdded(typeof(T));
        }

        /// <summary>
        /// Determines whether the specified type is added.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is added; otherwise, <c>false</c>.</returns>
        public static bool IsAdded(this IServiceCollection services, Type type)
        {
            return services.Any(d => d.ServiceType == type);
        }

        /// <summary>
        /// Gets the singleton instance or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            return (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        /// <exception cref="InvalidOperationException">Could not find singleton service: " + typeof(T).AssemblyQualifiedName</exception>
        public static T GetSingletonInstance<T>(this IServiceCollection services)
        {
            var service = services.GetSingletonInstanceOrNull<T>();
            if (service == null)
            {
                throw new InvalidOperationException("Could not find singleton service: " + typeof(T).AssemblyQualifiedName);
            }

            return service;
        }

        /// <summary>
        /// Builds the service provider from factory.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceProvider.</returns>
        public static IServiceProvider BuildServiceProviderFromFactory([NotNull] this IServiceCollection services)
	    {
		    Check.NotNull(services, nameof(services));
            //遍历已经注册的类型，找到之前注入的工厂类。
            foreach (var service in services)
		    {
			    var factoryInterface = service.ImplementationInstance?.GetType()
				    .GetTypeInfo()
				    .GetInterfaces()
				    .FirstOrDefault(i => i.GetTypeInfo().IsGenericType &&
				                         i.GetGenericTypeDefinition() == typeof(IServiceProviderFactory<>));

			    if (factoryInterface == null)
			    {
				    continue;
			    }

			    var containerBuilderType = factoryInterface.GenericTypeArguments[0];
			    return (IServiceProvider)typeof(ServiceCollectionCommonExtensions)
					.GetTypeInfo()
				    .GetMethods()
					.Single(m => m.Name == nameof(BuildServiceProviderFromFactory) && m.IsGenericMethod)
				    .MakeGenericMethod(containerBuilderType)
				    .Invoke(null, new object[] { services, null });
		    }

		    return services.BuildServiceProvider();
	    }

        /// <summary>
        /// Builds the service provider from factory.
        /// </summary>
        /// <typeparam name="TContainerBuilder">The type of the t container builder.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="builderAction">The builder action.</param>
        /// <returns>IServiceProvider.</returns>
        /// <exception cref="Exception">Could not find {typeof(IServiceProviderFactory<TContainerBuilder>).FullName} in {services}.</exception>
        public static IServiceProvider BuildServiceProviderFromFactory<TContainerBuilder>([NotNull] this IServiceCollection services, Action<TContainerBuilder> builderAction = null)
	    {
		    Check.NotNull(services, nameof(services));

		    var serviceProviderFactory = services.GetSingletonInstanceOrNull<IServiceProviderFactory<TContainerBuilder>>();
		    if (serviceProviderFactory == null)
		    {
			    throw new Exception($"Could not find {typeof(IServiceProviderFactory<TContainerBuilder>).FullName} in {services}.");
		    }

		    var builder = serviceProviderFactory.CreateBuilder(services);
		    builderAction?.Invoke(builder);
		    return serviceProviderFactory.CreateServiceProvider(builder);
	    }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection" />.
        /// This method should be used only after dependency injection registration phase completed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        internal static T GetService<T>(this IServiceCollection services)
        {
            return services
                .GetSingletonInstance<IApplication>()
                .ServiceProvider
                .GetService<T>();
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection" />.
        /// This method should be used only after dependency injection registration phase completed.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        internal static object GetService(this IServiceCollection services, Type type)
        {
            return services
                .GetSingletonInstance<IApplication>()
                .ServiceProvider
                .GetService(type);
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection" />.
        /// Throws exception if service is not registered.
        /// This method should be used only after dependency injection registration phase completed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        internal static T GetRequiredService<T>(this IServiceCollection services)
        {
            return services
                .GetSingletonInstance<IApplication>()
                .ServiceProvider
                .GetRequiredService<T>();
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection" />.
        /// Throws exception if service is not registered.
        /// This method should be used only after dependency injection registration phase completed.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        internal static object GetRequiredService(this IServiceCollection services, Type type)
        {
            return services
                .GetSingletonInstance<IApplication>()
                .ServiceProvider
                .GetRequiredService(type);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}" /> to resolve a service from given <see cref="IServiceCollection" />
        /// once dependency injection registration phase completed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>Lazy&lt;T&gt;.</returns>
        public static Lazy<T> GetServiceLazy<T>(this IServiceCollection services)
        {
            return new Lazy<T>(services.GetService<T>, true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}" /> to resolve a service from given <see cref="IServiceCollection" />
        /// once dependency injection registration phase completed.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns>Lazy&lt;System.Object&gt;.</returns>
        public static Lazy<object> GetServiceLazy(this IServiceCollection services, Type type)
        {
            return new Lazy<object>(() => services.GetService(type), true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}" /> to resolve a service from given <see cref="IServiceCollection" />
        /// once dependency injection registration phase completed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>Lazy&lt;T&gt;.</returns>
        public static Lazy<T> GetRequiredServiceLazy<T>(this IServiceCollection services)
        {
            return new Lazy<T>(services.GetRequiredService<T>, true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}" /> to resolve a service from given <see cref="IServiceCollection" />
        /// once dependency injection registration phase completed.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        /// <returns>Lazy&lt;System.Object&gt;.</returns>
        public static Lazy<object> GetRequiredServiceLazy(this IServiceCollection services, Type type)
        {
            return new Lazy<object>(() => services.GetRequiredService(type), true);
        }
    }
}