// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="PagingQueryableExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Noob;
using Noob.Application.Dtos;

namespace System.Linq
{
    /// <summary>
    /// Class PagingQueryableExtensions.
    /// </summary>
    public static class PagingQueryableExtensions
    {
        /// <summary>
        /// Used for paging with an <see cref="IPagedResultRequest" /> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">Queryable to apply paging</param>
        /// <param name="pagedResultRequest">An object implements <see cref="IPagedResultRequest" /> interface</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public static IQueryable<T> PageBy<T>([NotNull] this IQueryable<T> query, IPagedResultRequest pagedResultRequest)
        {
            Check.NotNull(query, nameof(query));

            return query.PageBy(pagedResultRequest.SkipCount, pagedResultRequest.MaxResultCount);
        }
    }
}
