// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditingInterceptorRegistrar.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using Noob.DependencyInjection;
using Noob.DynamicProxy;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingInterceptorRegistrar.
    /// </summary>
    public static class AuditingInterceptorRegistrar
    {
        /// <summary>
        /// Registers if needed.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void RegisterIfNeeded(IOnServiceRegistredContext context)
        {
            //满足条件时，将会为该类型注入审计日志拦截器。
            if (ShouldIntercept(context.ImplementationType))
            {
                context.Interceptors.TryAdd<AuditingInterceptor>();
            }
        }

        /// <summary>
        /// Shoulds the intercept.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ShouldIntercept(Type type)
        {
            if (DynamicProxyIgnoreTypes.Contains(type))
            {
                return false;
            }
            // 首先判断类型上面是否使用了辅助类型。
            if (ShouldAuditTypeByDefault(type))
            {
                return true;
            }
            //如果任意方法上面标注了 AuditedAttribute 特性，则仍然为该类型注入拦截器。
            if (type.GetMethods().Any(m => m.IsDefined(typeof(AuditedAttribute), true)))
            {
                return true;
            }

            return false;
        }

        //TODO: Move to a better place
        /// <summary>
        /// Shoulds the audit type by default.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ShouldAuditTypeByDefault(Type type)
        {
            //TODO: In an inheritance chain, it would be better to check the attributes on the top class first.
            //下面就是根据三种辅助类型进行判断，是否为当前 type 注入审计日志拦截器。
            if (type.IsDefined(typeof(AuditedAttribute), true))
            {
                return true;
            }

            if (type.IsDefined(typeof(DisableAuditingAttribute), true))
            {
                return false;
            }

            if (typeof(IAuditingEnabled).IsAssignableFrom(type))
            {
                return true;
            }

            return false;
        }
    }
}