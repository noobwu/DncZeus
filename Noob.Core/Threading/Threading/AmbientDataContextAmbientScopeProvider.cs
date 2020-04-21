// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="AmbientDataContextAmbientScopeProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Noob.Threading
{
    /// <summary>
    /// Class AmbientDataContextAmbientScopeProvider.
    /// Implements the <see cref="Noob.Threading.IAmbientScopeProvider{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Noob.Threading.IAmbientScopeProvider{T}" />
    public class AmbientDataContextAmbientScopeProvider<T> : IAmbientScopeProvider<T>
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger<AmbientDataContextAmbientScopeProvider<T>> Logger { get; set; }

        /// <summary>
        /// The scope dictionary
        /// </summary>
        private static readonly ConcurrentDictionary<string, ScopeItem> ScopeDictionary = new ConcurrentDictionary<string, ScopeItem>();

        /// <summary>
        /// The data context
        /// </summary>
        private readonly IAmbientDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmbientDataContextAmbientScopeProvider{T}"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public AmbientDataContextAmbientScopeProvider([NotNull] IAmbientDataContext dataContext)
        {
            Check.NotNull(dataContext, nameof(dataContext));

            _dataContext = dataContext;

            Logger = NullLogger<AmbientDataContextAmbientScopeProvider<T>>.Instance;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="contextKey">The context key.</param>
        /// <returns>T.</returns>
        public T GetValue(string contextKey)
        {
            var item = GetCurrentItem(contextKey);
            if (item == null)
            {
                return default;
            }

            return item.Value;
        }

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <param name="contextKey">The context key.</param>
        /// <param name="value">The value.</param>
        /// <returns>IDisposable.</returns>
        /// <exception cref="AbpException">Can not add item! ScopeDictionary.TryAdd returns false!</exception>
        public IDisposable BeginScope(string contextKey, T value)
        {
            var item = new ScopeItem(value, GetCurrentItem(contextKey));

            if (!ScopeDictionary.TryAdd(item.Id, item))
            {
                throw new Exception("Can not add item! ScopeDictionary.TryAdd returns false!");
            }

            _dataContext.SetData(contextKey, item.Id);

            return new DisposeAction(() =>
            {
                ScopeDictionary.TryRemove(item.Id, out item);

                if (item.Outer == null)
                {
                    _dataContext.SetData(contextKey, null);
                    return;
                }

                _dataContext.SetData(contextKey, item.Outer.Id);
            });
        }

        /// <summary>
        /// Gets the current item.
        /// </summary>
        /// <param name="contextKey">The context key.</param>
        /// <returns>ScopeItem.</returns>
        private ScopeItem GetCurrentItem(string contextKey)
        {
            var objKey = _dataContext.GetData(contextKey) as string;
            return objKey != null ? ScopeDictionary.GetOrDefault(objKey) : null;
        }

        /// <summary>
        /// Class ScopeItem.
        /// </summary>
        private class ScopeItem
        {
            /// <summary>
            /// Gets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; }

            /// <summary>
            /// Gets the outer.
            /// </summary>
            /// <value>The outer.</value>
            public ScopeItem Outer { get; }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <value>The value.</value>
            public T Value { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ScopeItem"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="outer">The outer.</param>
            public ScopeItem(T value, ScopeItem outer = null)
            {
                Id = Guid.NewGuid().ToString();

                Value = value;
                Outer = outer;
            }
        }
    }
}