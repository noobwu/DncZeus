// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Interceptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

namespace Noob.DynamicProxy
{
    /// <summary>
    /// 拦截器的默认抽象实现。
    /// Implements the <see cref="Noob.DynamicProxy.IInterceptor" />
    /// </summary>
    /// <seealso cref="Noob.DynamicProxy.IInterceptor" />
    public abstract class Interceptor : IInterceptor
    {
        /// <summary>
        /// 异步方法拦截。
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        public abstract Task InterceptAsync(IMethodInvocation invocation);
    }
}