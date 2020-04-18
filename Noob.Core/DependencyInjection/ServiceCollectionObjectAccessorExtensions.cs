// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ServiceCollectionObjectAccessorExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using Noob.DependencyInjection;
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionObjectAccessorExtensions.
    /// </summary>
    public static class ServiceCollectionObjectAccessorExtensions
    {
        /// <summary>
        /// Tries the add object accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>ObjectAccessor&lt;T&gt;.</returns>
        public static ObjectAccessor<T> TryAddObjectAccessor<T>(this IServiceCollection services)
        {
            if (services.Any(s => s.ServiceType == typeof(ObjectAccessor<T>)))
            {
                return services.GetSingletonInstance<ObjectAccessor<T>>();
            }

            return services.AddObjectAccessor<T>();
        }

        /// <summary>
        /// Adds the object accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>ObjectAccessor&lt;T&gt;.</returns>
        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services)
        {
            return services.AddObjectAccessor(new ObjectAccessor<T>());
        }

        /// <summary>
        /// Adds the object accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <param name="obj">The object.</param>
        /// <returns>ObjectAccessor&lt;T&gt;.</returns>
        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, T obj)
        {
            return services.AddObjectAccessor(new ObjectAccessor<T>(obj));
        }

        /// <summary>
        /// Adds the object accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <param name="accessor">The accessor.</param>
        /// <returns>ObjectAccessor&lt;T&gt;.</returns>
        /// <exception cref="NullReferenceException">Services is null</exception>
        /// <exception cref="Exception">An object accessor is registered before for type: " + typeof(T).AssemblyQualifiedName</exception>
        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, ObjectAccessor<T> accessor)
        {
            if (services == null)
            {
                throw new NullReferenceException("Services is null");
            }
            if (services.Any(s => s.ServiceType == typeof(ObjectAccessor<T>)))
            {
                throw new Exception("An object accessor is registered before for type: " + typeof(T).AssemblyQualifiedName);
            }

            //Add to the beginning for fast retrieve
            services.Insert(0, ServiceDescriptor.Singleton(typeof(ObjectAccessor<T>), accessor));
            services.Insert(0, ServiceDescriptor.Singleton(typeof(IObjectAccessor<T>), accessor));

            return accessor;
        }

        /// <summary>
        /// Gets the object or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        public static T GetObjectOrNull<T>(this IServiceCollection services)
            where T : class 
        {
            return services.GetSingletonInstanceOrNull<IObjectAccessor<T>>()?.Value;
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns>T.</returns>
        /// <exception cref="Exception">Could not find an object of {typeof(T).AssemblyQualifiedName} in services. Be sure that you have used AddObjectAccessor before!</exception>
        public static T GetObject<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetObjectOrNull<T>() ?? throw new Exception($"Could not find an object of {typeof(T).AssemblyQualifiedName} in services. Be sure that you have used AddObjectAccessor before!");
        }
    }
}