// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="AsyncLocalAmbientDataContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Concurrent;
using System.Threading;
using Noob.DependencyInjection;

namespace Noob.Threading
{
    /// <summary>
    /// Class AsyncLocalAmbientDataContext.
    /// Implements the <see cref="Noob.Threading.IAmbientDataContext" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Threading.IAmbientDataContext" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class AsyncLocalAmbientDataContext : IAmbientDataContext, ISingletonDependency
    {
        /// <summary>
        /// The asynchronous local dictionary
        /// </summary>
        private static readonly ConcurrentDictionary<string, AsyncLocal<object>> AsyncLocalDictionary = new ConcurrentDictionary<string, AsyncLocal<object>>();

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetData(string key, object value)
        {
            var asyncLocal = AsyncLocalDictionary.GetOrAdd(key, (k) => new AsyncLocal<object>());
            asyncLocal.Value = value;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public object GetData(string key)
        {
            var asyncLocal = AsyncLocalDictionary.GetOrAdd(key, (k) => new AsyncLocal<object>());
            return asyncLocal.Value;
        }
    }
}