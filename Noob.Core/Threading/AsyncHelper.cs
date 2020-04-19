// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AsyncHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nito.AsyncEx;

namespace Noob.Threading
{
    /// <summary>
    /// Provides some helper methods to work with async methods.
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// Checks if given method is an async method.
        /// </summary>
        /// <param name="method">A method to check</param>
        /// <returns><c>true</c> if the specified method is asynchronous; otherwise, <c>false</c>.</returns>
        public static bool IsAsync([NotNull] this MethodInfo method)
        {
            Check.NotNull(method, nameof(method));

            return method.ReturnType.IsTaskOrTaskOfT();
        }

        /// <summary>
        /// Determines whether [is task or task of t] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is task or task of t] [the specified type]; otherwise, <c>false</c>.</returns>
        public static bool IsTaskOrTaskOfT([NotNull] this Type type)
        {
            return type == typeof(Task) || (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>));
        }

        /// <summary>
        /// Determines whether [is task of t] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is task of t] [the specified type]; otherwise, <c>false</c>.</returns>
        public static bool IsTaskOfT([NotNull] this Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>);
        }

        /// <summary>
        /// Returns void if given type is Task.
        /// Return T, if given type is Task{T}.
        /// Returns given type otherwise.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Type.</returns>
        public static Type UnwrapTask([NotNull] Type type)
        {
            Check.NotNull(type, nameof(type));

            if (type == typeof(Task))
            {
                return typeof(void);
            }

            if (type.IsTaskOfT())
            {
                return type.GenericTypeArguments[0];
            }

            return type;
        }

        /// <summary>
        /// Runs a async method synchronously.
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="func">A function that returns a result</param>
        /// <returns>Result of the async operation</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return AsyncContext.Run(func);
        }

        /// <summary>
        /// Runs a async method synchronously.
        /// </summary>
        /// <param name="action">An async action</param>
        public static void RunSync(Func<Task> action)
        {
            AsyncContext.Run(action);
        }
    }
}
