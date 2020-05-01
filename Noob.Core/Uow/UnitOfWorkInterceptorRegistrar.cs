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
using System;
using System.Reflection;
using Noob.DependencyInjection;
using Noob.DynamicProxy;

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
            // 根据回调传入的context 绑定的实现类型，判断是否应该为该类型注册 UnitOfWorkInterceptor 拦截器。
            if (ShouldIntercept(context.ImplementationType))
            {
                context.Interceptors.TryAdd<UnitOfWorkInterceptor>();
            }
        }

        /// <summary>
        /// Shoulds the intercept.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ShouldIntercept(Type type)
        {
            return !DynamicProxyIgnoreTypes.Contains(type) && UnitOfWorkHelper.IsUnitOfWorkType(type.GetTypeInfo());
        }
    }
}