// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="CastleMethodInvocationAdapterBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Noob.DynamicProxy;

namespace Noob.Castle.DynamicProxy
{
    /// <summary>
    /// Class CastleMethodInvocationAdapterBase.
    /// Implements the <see cref="Noob.DynamicProxy.IMethodInvocation" />
    /// </summary>
    /// <seealso cref="Noob.DynamicProxy.IMethodInvocation" />
    public abstract class CastleMethodInvocationAdapterBase : IMethodInvocation
    {
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public object[] Arguments => Invocation.Arguments;

        /// <summary>
        /// Gets the arguments dictionary.
        /// </summary>
        /// <value>The arguments dictionary.</value>
        public IReadOnlyDictionary<string, object> ArgumentsDictionary => _lazyArgumentsDictionary.Value;
        /// <summary>
        /// The lazy arguments dictionary
        /// </summary>
        private readonly Lazy<IReadOnlyDictionary<string, object>> _lazyArgumentsDictionary;

        /// <summary>
        /// Gets the generic arguments.
        /// </summary>
        /// <value>The generic arguments.</value>
        public Type[] GenericArguments => Invocation.GenericArguments;

        /// <summary>
        /// Gets the target object.
        /// </summary>
        /// <value>The target object.</value>
        public object TargetObject => Invocation.InvocationTarget ?? Invocation.MethodInvocationTarget;

        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <value>The method.</value>
        public MethodInfo Method => Invocation.MethodInvocationTarget ?? Invocation.Method;

        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        /// <value>The return value.</value>
        public object ReturnValue { get; set; }

        /// <summary>
        /// Gets the invocation.
        /// </summary>
        /// <value>The invocation.</value>
        protected IInvocation Invocation { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleMethodInvocationAdapterBase"/> class.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected CastleMethodInvocationAdapterBase(IInvocation invocation)
        {
            Invocation = invocation;
            _lazyArgumentsDictionary = new Lazy<IReadOnlyDictionary<string, object>>(GetArgumentsDictionary);
        }

        /// <summary>
        /// Proceeds the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task ProceedAsync();

        /// <summary>
        /// Gets the arguments dictionary.
        /// </summary>
        /// <returns>IReadOnlyDictionary&lt;System.String, System.Object&gt;.</returns>
        private IReadOnlyDictionary<string, object> GetArgumentsDictionary()
        {
            var dict = new Dictionary<string, object>();

            var methodParameters = Method.GetParameters();
            for (int i = 0; i < methodParameters.Length; i++)
            {
                dict[methodParameters[i].Name] = Invocation.Arguments[i];
            }

            return dict;
        }
    }
}