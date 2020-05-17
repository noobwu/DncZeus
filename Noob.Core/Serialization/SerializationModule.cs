// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="SerializationModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;
using Noob.Reflection;

namespace Noob.Serialization
{
    /// <summary>
    /// Class SerializationModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    public class SerializationModule : Module
    {
        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.OnExposing(onServiceExposingContext =>
            {
                //Register types for IObjectSerializer<T> if implements
                onServiceExposingContext.ExposedTypes.AddRange(
                    ReflectionHelper.GetImplementedGenericTypes(
                        onServiceExposingContext.ImplementationType,
                        typeof(IObjectSerializer<>)
                    )
                );
            });
        }
    }
}
