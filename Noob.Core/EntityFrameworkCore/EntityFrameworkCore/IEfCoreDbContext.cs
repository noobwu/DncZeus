// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IEfCoreDbContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Interface IEfCoreDbContext
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure{System.IServiceProvider}" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Internal.IDbSetCache" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Internal.IDbContextPoolable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure{System.IServiceProvider}" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.Internal.IDbSetCache" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.Internal.IDbContextPoolable" />
    public interface IEfCoreDbContext : IDisposable, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, IDbContextPoolable
    {
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Attach([NotNull] object entity);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int SaveChanges();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <returns>System.Int32.</returns>
        int SaveChanges(bool acceptAllChangesOnSuccess);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>DbSet&lt;T&gt;.</returns>
        DbSet<T> Set<T>()
            where T : class;

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>The database.</value>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Gets the change tracker.
        /// </summary>
        /// <value>The change tracker.</value>
        ChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Add([NotNull] object entity);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>ValueTask&lt;EntityEntry&gt;.</returns>
        ValueTask<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>ValueTask&lt;EntityEntry&lt;TEntity&gt;&gt;.</returns>
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange([NotNull] IEnumerable<object> entities);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange([NotNull] params object[] entities);

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task.</returns>
        Task AddRangeAsync([NotNull] params object[] entities);

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attaches the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AttachRange([NotNull] IEnumerable<object> entities);

        /// <summary>
        /// Attaches the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AttachRange([NotNull] params object[] entities);

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Entry([NotNull] object entity);

        /// <summary>
        /// Finds the specified entity type.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns>System.Object.</returns>
        object Find([NotNull] Type entityType, [NotNull] params object[] keyValues);

        /// <summary>
        /// Finds the specified key values.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <returns>TEntity.</returns>
        TEntity Find<TEntity>([NotNull] params object[] keyValues) where TEntity : class;

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        ValueTask<object> FindAsync([NotNull] Type entityType, [NotNull] object[] keyValues, CancellationToken cancellationToken);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>ValueTask&lt;TEntity&gt;.</returns>
        ValueTask<TEntity> FindAsync<TEntity>([NotNull] object[] keyValues, CancellationToken cancellationToken) where TEntity : class;

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <returns>ValueTask&lt;TEntity&gt;.</returns>
        ValueTask<TEntity> FindAsync<TEntity>([NotNull] params object[] keyValues) where TEntity : class;

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        ValueTask<object> FindAsync([NotNull] Type entityType, [NotNull] params object[] keyValues);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Remove([NotNull] object entity);

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange([NotNull] IEnumerable<object> entities);

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange([NotNull] params object[] entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Update([NotNull] object entity);

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange([NotNull] params object[] entities);

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange([NotNull] IEnumerable<object> entities);
    }
}
