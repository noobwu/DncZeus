// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2019-10-20
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IMethodInvocation.cs" company="Noob.Core">
//     Copyright (c) Noob.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

/// <summary>
/// The DynamicProxy namespace.
/// </summary>
namespace Noob.DynamicProxy
{
    /// <summary>
    /// Interface IAbpMethodInvocation
    /// </summary>
    public interface IMethodInvocation
    {
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        object[] Arguments { get; }

        /// <summary>
        /// Gets the arguments dictionary.
        /// </summary>
        /// <value>The arguments dictionary.</value>
        IReadOnlyDictionary<string, object> ArgumentsDictionary { get; }

        /// <summary>
        /// Gets the generic arguments.
        /// </summary>
        /// <value>The generic arguments.</value>
        Type[] GenericArguments { get; }

        /// <summary>
        /// Gets the target object.
        /// </summary>
        /// <value>The target object.</value>
        object TargetObject { get; }

        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <value>The method.</value>
        MethodInfo Method { get; }

        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        /// <value>The return value.</value>
        object ReturnValue { get; set; }

        /// <summary>
        /// Proceeds the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task ProceedAsync();
    }
}