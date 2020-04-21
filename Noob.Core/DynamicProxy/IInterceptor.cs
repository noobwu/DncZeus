// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IInterceptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;

/// <summary>
/// The DynamicProxy namespace.
/// </summary>
namespace Noob.DynamicProxy
{
    /// <summary>
    /// 拦截器定义
    /// </summary>
    public interface IInterceptor
    {
        /// <summary>
        /// 异步方法拦截。
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        Task InterceptAsync(IMethodInvocation invocation);
    }
}
