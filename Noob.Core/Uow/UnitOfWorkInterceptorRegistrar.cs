// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkInterceptorRegistrar.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;
using Noob.DependencyInjection;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkInterceptorRegistrar.
    /// </summary>
    public static class UnitOfWorkInterceptorRegistrar
    {
        /// <summary>
        /// Registers if needed.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void RegisterIfNeeded(IOnServiceRegistredContext context)
        {
            if (UnitOfWorkHelper.IsUnitOfWorkType(context.ImplementationType.GetTypeInfo()))
            {
                context.Interceptors.TryAdd<UnitOfWorkInterceptor>();
            }
        }
    }
}