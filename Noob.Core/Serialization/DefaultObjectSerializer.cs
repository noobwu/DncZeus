// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="DefaultObjectSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Serialization.Binary;

namespace Noob.Serialization
{
    /// <summary>
    /// Class DefaultObjectSerializer.
    /// Implements the <see cref="Noob.Serialization.IObjectSerializer" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Serialization.IObjectSerializer" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class DefaultObjectSerializer : IObjectSerializer, ITransientDependency
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultObjectSerializer"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultObjectSerializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.Byte[].</returns>
        public virtual byte[] Serialize<T>(T obj)
        {
            if (obj == null)
            {
                return null;
            }

            //Check if a specific serializer is registered
            using (var scope = _serviceProvider.CreateScope())
            {
                var specificSerializer = scope.ServiceProvider.GetService<IObjectSerializer<T>>();
                if (specificSerializer != null)
                {
                    return specificSerializer.Serialize(obj);
                }
            }

            return AutoSerialize(obj);
        }

        /// <summary>
        /// Deserializes the specified bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes">The bytes.</param>
        /// <returns>T.</returns>
        [CanBeNull]
        public virtual T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null)
            {
                return default;
            }

            //Check if a specific serializer is registered
            using (var scope = _serviceProvider.CreateScope())
            {
                var specificSerializer = scope.ServiceProvider.GetService<IObjectSerializer<T>>();
                if (specificSerializer != null)
                {
                    return specificSerializer.Deserialize(bytes);
                }
            }

            return AutoDeserialize<T>(bytes);
        }

        /// <summary>
        /// Automatics the serialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.Byte[].</returns>
        protected virtual byte[] AutoSerialize<T>(T obj)
        {
            return BinarySerializationHelper.Serialize(obj);
        }

        /// <summary>
        /// Automatics the deserialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes">The bytes.</param>
        /// <returns>T.</returns>
        protected virtual T AutoDeserialize<T>(byte[] bytes)
        {
            return (T) BinarySerializationHelper.DeserializeExtended(bytes);
        }
    }
}