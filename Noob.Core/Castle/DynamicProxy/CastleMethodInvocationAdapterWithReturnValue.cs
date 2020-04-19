// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="CastleMethodInvocationAdapterWithReturnValue.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Noob.DynamicProxy;

namespace Noob.Castle.DynamicProxy
{
    /// <summary>
    /// Class CastleMethodInvocationAdapterWithReturnValue.
    /// Implements the <see cref="Noob.Castle.DynamicProxy.CastleMethodInvocationAdapterBase" />
    /// Implements the <see cref="Noob.DynamicProxy.IMethodInvocation" />
    /// </summary>
    /// <typeparam name="TResult">The type of the t result.</typeparam>
    /// <seealso cref="Noob.Castle.DynamicProxy.CastleMethodInvocationAdapterBase" />
    /// <seealso cref="Noob.DynamicProxy.IMethodInvocation" />
    public class CastleMethodInvocationAdapterWithReturnValue<TResult> : CastleMethodInvocationAdapterBase, IMethodInvocation
    {
        /// <summary>
        /// Gets the proceed information.
        /// </summary>
        /// <value>The proceed information.</value>
        protected IInvocationProceedInfo ProceedInfo { get; }
        /// <summary>
        /// Gets the proceed.
        /// </summary>
        /// <value>The proceed.</value>
        protected Func<IInvocation, IInvocationProceedInfo, Task<TResult>> Proceed { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleMethodInvocationAdapterWithReturnValue{TResult}"/> class.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="proceedInfo">The proceed information.</param>
        /// <param name="proceed">The proceed.</param>
        public CastleMethodInvocationAdapterWithReturnValue(IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
            : base(invocation)
        {
            ProceedInfo = proceedInfo;
            Proceed = proceed;
        }

        /// <summary>
        /// proceed as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task ProceedAsync()
        {
            ReturnValue = await Proceed(Invocation, ProceedInfo);
        }
    }
}