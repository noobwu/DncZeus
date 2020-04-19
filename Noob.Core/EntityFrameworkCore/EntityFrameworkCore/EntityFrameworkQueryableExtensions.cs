// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EntityFrameworkQueryableExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// Class EntityFrameworkQueryableExtensions.
    /// </summary>
    public static class EntityFrameworkQueryableExtensions
    {
        /// <summary>
        /// Specifies the related objects to include in the query results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}" /> on which to call Include.</param>
        /// <param name="condition">A boolean value to determine to include <paramref name="path" /> or not.</param>
        /// <param name="path">The type of navigation property being included.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public static IQueryable<T> IncludeIf<T, TProperty>(this IQueryable<T> source, bool condition, Expression<Func<T, TProperty>> path)
            where T : class
        {
            return condition
                ? source.Include(path)
                : source;
        }
    }
}
