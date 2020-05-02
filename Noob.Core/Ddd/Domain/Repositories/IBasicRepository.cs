// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IBasicRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Interface IBasicRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    public interface IBasicRepository<TEntity> : IReadOnlyBasicRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        [NotNull]
        Task<TEntity> InsertAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        [NotNull]
        Task<TEntity> UpdateAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        Task DeleteAsync([NotNull] TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Interface IBasicRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity, TKey}" />
    public interface IBasicRepository<TEntity, TKey> : IBasicRepository<TEntity>, IReadOnlyBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);  //TODO: Return true if deleted
    }
}
