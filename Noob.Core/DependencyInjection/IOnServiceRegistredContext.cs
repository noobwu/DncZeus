// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IOnServiceRegistredContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Collections;
using Noob.DynamicProxy;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IOnServiceRegistredContext
    /// </summary>
    public interface IOnServiceRegistredContext
    {
        /// <summary>
        /// Gets the interceptors.
        /// </summary>
        /// <value>The interceptors.</value>
        ITypeList<IInterceptor> Interceptors { get; }

        /// <summary>
        /// Gets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        Type ImplementationType { get; }
    }
}