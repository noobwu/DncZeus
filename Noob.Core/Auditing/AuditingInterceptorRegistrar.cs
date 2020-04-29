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
            
            if (ShouldAuditTypeByDefault(type))
            {
                return true;
            }

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