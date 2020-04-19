// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AsyncDeterminationInterceptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.DynamicProxy;
using Castle.DynamicProxy;
namespace Noob.Castle.DynamicProxy
{
    /// <summary>
    /// Class AsyncDeterminationInterceptor.
    /// Implements the <see cref="Castle.DynamicProxy.AsyncDeterminationInterceptor" />
    /// </summary>
    /// <typeparam name="TInterceptor">The type of the t interceptor.</typeparam>
    /// <seealso cref="Castle.DynamicProxy.AsyncDeterminationInterceptor" />
    public class AsyncDeterminationInterceptor<TInterceptor> :AsyncDeterminationInterceptor
        where TInterceptor : Noob.DynamicProxy.IInterceptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncDeterminationInterceptor{TInterceptor}"/> class.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        public AsyncDeterminationInterceptor(TInterceptor interceptor)
            : base(new CastleAsyncInterceptorAdapter<TInterceptor>(interceptor))
        {

        }
    }
}