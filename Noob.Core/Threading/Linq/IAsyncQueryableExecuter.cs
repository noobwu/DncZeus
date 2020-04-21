// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="IAsyncQueryableExecuter.cs" company="Noob.Core">
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
    /// This interface is intended to be used by ABP.
    /// </summary>
    public interface IAsyncQueryableExecuter
    {
        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> CountAsync<T>(IQueryable<T> queryable);

        /// <summary>
        /// Converts to listasync.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        Task<List<T>> ToListAsync<T>(IQueryable<T> queryable);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken);
    }
}