// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="OnServiceRegistredContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob.Collections;
using Noob.DynamicProxy;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class OnServiceRegistredContext.
    /// Implements the <see cref="Noob.DependencyInjection.IOnServiceRegistredContext" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IOnServiceRegistredContext" />
    public class OnServiceRegistredContext : IOnServiceRegistredContext
    {
        /// <summary>
        /// Gets the interceptors.
        /// </summary>
        /// <value>The interceptors.</value>
        public virtual ITypeList<IInterceptor> Interceptors { get; }

        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        public virtual Type ServiceType { get; }

        /// <summary>
        /// Gets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        public virtual Type ImplementationType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnServiceRegistredContext"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        public OnServiceRegistredContext(Type serviceType, [NotNull] Type implementationType)
        {
            ServiceType = Check.NotNull(serviceType, nameof(serviceType));
            ImplementationType = Check.NotNull(implementationType, nameof(implementationType));

            Interceptors = new TypeList<IInterceptor>();
        }
    }
}