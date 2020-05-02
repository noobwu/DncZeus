// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IReadOnlyRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Interface IReadOnlyRepository
    /// Implements the <see cref="System.Linq.IQueryable{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="System.Linq.IQueryable{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    public interface IReadOnlyRepository<TEntity> : IQueryable<TEntity>, IReadOnlyBasicRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Withes the details.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> WithDetails();

        /// <summary>
        /// Withes the details.
        /// </summary>
        /// <param name="propertySelectors">The property selectors.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors);
    }

    /// <summary>
    /// Interface IReadOnlyRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity, TKey}" />
    public interface IReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity>, IReadOnlyBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}
