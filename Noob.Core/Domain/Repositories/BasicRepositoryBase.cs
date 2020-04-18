// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="BasicRepositoryBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Domain.Entities;
using Noob.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Class BasicRepositoryBase.
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{TEntity}" />
    public abstract class BasicRepositoryBase<TEntity> :
          IBasicRepository<TEntity>
          where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets or sets the cancellation token provider.
        /// </summary>
        /// <value>The cancellation token provider.</value>
        public ICancellationTokenProvider CancellationTokenProvider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRepositoryBase{TEntity}" /> class.
        /// </summary>
        protected BasicRepositoryBase()
        {
            CancellationTokenProvider = NullCancellationTokenProvider.Instance;
        }

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public abstract Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public abstract Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        public abstract Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of all the entities.
        /// </summary>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity</returns>
        public abstract Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets total count of all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        public abstract Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the cancellation token.
        /// </summary>
        /// <param name="preferredValue">The preferred value.</param>
        /// <returns>CancellationToken.</returns>
        protected virtual CancellationToken GetCancellationToken(CancellationToken preferredValue = default)
        {
            return CancellationTokenProvider.FallbackToProvider(preferredValue);
        }
    }
    /// <summary>
    /// Class BasicRepositoryBase.
    /// Implements the <see cref="Noob.Domain.Repositories.BasicRepositoryBase{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.BasicRepositoryBase{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{TEntity, TKey}" />
    public abstract class BasicRepositoryBase<TEntity, TKey> : BasicRepositoryBase<TEntity>, IBasicRepository<TEntity, TKey>
      where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity</returns>
        /// <exception cref="Noob.Domain.Entities.EntityNotFoundException"></exception>
        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, includeDetails, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        /// <summary>
        /// Gets an entity with given primary key or null if not found.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity or null</returns>
        public abstract Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        public virtual async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity, autoSave, cancellationToken);
        }
    }
}
