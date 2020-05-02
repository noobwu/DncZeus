// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Just to mark a class as repository.
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// Interface IRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IBasicRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Get a single entity by the given <paramref name="predicate" />.
        /// It returns null if no entity with the given <paramref name="predicate" />.
        /// It throws <see cref="InvalidOperationException" /> if there are multiple entities with the given <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A condition to find the entity</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> FindAsync(
            [NotNull] Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Get a single entity by the given <paramref name="predicate" />.
        /// It throws <see cref="EntityNotFoundException" /> if there is no entity with the given <paramref name="predicate" />.
        /// It throws <see cref="InvalidOperationException" /> if there are multiple entities with the given <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A condition to filter entities</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> GetAsync(
            [NotNull] Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Deletes many entities by function.
        /// Notice that: All entities fits to given predicate are retrieved and deleted.
        /// This may cause major performance problems if there are too many entities with
        /// given predicate.
        /// </summary>
        /// <param name="predicate">A condition to filter entities</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(
            [NotNull] Expression<Func<TEntity, bool>> predicate,
            bool autoSave = false,
            CancellationToken cancellationToken = default
        );
    }

    /// <summary>
    /// Interface IRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IRepository{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity, TKey}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IRepository{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyRepository{TEntity, TKey}" />
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{TEntity, TKey}" />
    public interface IRepository<TEntity, TKey> : IRepository<TEntity>, IReadOnlyRepository<TEntity, TKey>, IBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}