// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IReadOnlyBasicRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Interface IReadOnlyBasicRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IRepository" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IRepository" />
    public interface IReadOnlyBasicRepository<TEntity> : IRepository
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets a list of all the entities.
        /// </summary>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity</returns>
        Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets total count of all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Interface IReadOnlyBasicRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IReadOnlyBasicRepository{TEntity}" />
    public interface IReadOnlyBasicRepository<TEntity, TKey> : IReadOnlyBasicRepository<TEntity>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Gets an entity with given primary key.
        /// Throws <see cref="EntityNotFoundException" /> if can not find an entity with given id.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity</returns>
        [NotNull]
        Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity with given primary key or null if not found.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity or null</returns>
        Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
    }
}
