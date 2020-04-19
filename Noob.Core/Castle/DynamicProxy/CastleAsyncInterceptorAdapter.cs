// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="CastleAsyncInterceptorAdapter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Noob.Castle.DynamicProxy
{
    /// <summary>
    /// Class CastleAsyncInterceptorAdapter.
    /// Implements the <see cref="Castle.DynamicProxy.AsyncInterceptorBase" />
    /// </summary>
    /// <typeparam name="TInterceptor">The type of the t interceptor.</typeparam>
    /// <seealso cref="Castle.DynamicProxy.AsyncInterceptorBase" />
    public class CastleAsyncInterceptorAdapter<TInterceptor> : AsyncInterceptorBase
        where TInterceptor :Noob.DynamicProxy.IInterceptor
    {
        /// <summary>
        /// The interceptor
        /// </summary>
        private readonly TInterceptor _interceptor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleAsyncInterceptorAdapter{TInterceptor}"/> class.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        public CastleAsyncInterceptorAdapter(TInterceptor interceptor)
        {
            _interceptor = interceptor;
        }

        /// <summary>
        /// intercept as an asynchronous operation.
        /// </summary>
        /// <param name="invocation">The method invocation.</param>
        /// <param name="proceedInfo">The <see cref="T:Castle.DynamicProxy.IInvocationProceedInfo" />.</param>
        /// <param name="proceed">The function to proceed the <paramref name="proceedInfo" />.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> object that represents the asynchronous operation.</returns>
        protected override async Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            await _interceptor.InterceptAsync(
                new CastleMethodInvocationAdapter(invocation, proceedInfo, proceed)
            );
        }

        /// <summary>
        /// intercept as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the <see cref="T:System.Threading.Tasks.Task`1" /><see cref="P:System.Threading.Tasks.Task`1.Result" />.</typeparam>
        /// <param name="invocation">The method invocation.</param>
        /// <param name="proceedInfo">The <see cref="T:Castle.DynamicProxy.IInvocationProceedInfo" />.</param>
        /// <param name="proceed">The function to proceed the <paramref name="proceedInfo" />.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> object that represents the asynchronous operation.</returns>
        protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            var adapter = new CastleMethodInvocationAdapterWithReturnValue<TResult>(invocation, proceedInfo, proceed);

            await _interceptor.InterceptAsync(
                adapter
            );

            return (TResult)adapter.ReturnValue;
        }
    }
}