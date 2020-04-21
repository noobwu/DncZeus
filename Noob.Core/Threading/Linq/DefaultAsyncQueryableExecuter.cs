// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="DefaultAsyncQueryableExecuter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Noob.Linq
{
    /// <summary>
    /// Class DefaultAsyncQueryableExecuter.
    /// Implements the <see cref="Noob.Linq.IAsyncQueryableExecuter" />
    /// </summary>
    /// <seealso cref="Noob.Linq.IAsyncQueryableExecuter" />
    public class DefaultAsyncQueryableExecuter : IAsyncQueryableExecuter
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DefaultAsyncQueryableExecuter Instance { get; } = new DefaultAsyncQueryableExecuter();

        /// <summary>
        /// Prevents a default instance of the <see cref="DefaultAsyncQueryableExecuter"/> class from being created.
        /// </summary>
        private DefaultAsyncQueryableExecuter()
        {
            
        }

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> CountAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult(queryable.Count());
        }

        /// <summary>
        /// Converts to listasync.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult(queryable.ToList());
        }

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult(queryable.FirstOrDefault());
        }

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken)
        {
            return Task.FromResult(queryable.FirstOrDefault());
        }
    }
}