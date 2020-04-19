// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Noob.Domain.Entities;
using Noob.EntityFrameworkCore;
using Noob.EntityFrameworkCore.DependencyInjection;

namespace Noob.Domain.Repositories.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreRepository.
    /// Implements the <see cref="Noob.Domain.Repositories.RepositoryBase{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.RepositoryBase{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity}" />
    public class EfCoreRepository<TDbContext,TEntity> : RepositoryBase<TEntity>, IEfCoreRepository<TEntity>
        where TDbContext :EfCoreDbContext
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <value>The database set.</value>
        public virtual DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        DbContext IEfCoreRepository<TEntity>.DbContext => DbContext.As<DbContext>();
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected virtual TDbContext DbContext => _dbContextProvider.GetDbContext();
        /// <summary>
        /// The database context provider
        /// </summary>
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        /// <summary>
        /// Gets the entity options.
        /// </summary>
        /// <value>The entity options.</value>
        protected virtual EntityOptions<TEntity> EntityOptions => _entityOptionsLazy.Value;

        /// <summary>
        /// The entity options lazy
        /// </summary>
        private readonly Lazy<EntityOptions<TEntity>> _entityOptionsLazy;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreRepository{TEntity}" /> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _entityOptionsLazy = new Lazy<EntityOptions<TEntity>>(
                () => ServiceProvider
                          .GetRequiredService<IOptions<EntityOptions>>()
                          .Value
                          .GetOrNull<TEntity>() ?? EntityOptions<TEntity>.Empty
            );
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public override async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(GetCancellationToken(cancellationToken));
            }

            return savedEntity;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public override async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(GetCancellationToken(cancellationToken));
            }

            return updatedEntity;
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        public override async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(GetCancellationToken(cancellationToken));
            }
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Entity</returns>
        public override async Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().ToListAsync(GetCancellationToken(cancellationToken))
                : await DbSet.ToListAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// get count as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        public override async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        protected override IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="predicate">A condition to find the entity</param>
        /// <param name="includeDetails">Set true to include all children of this entity</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public override async Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> predicate, 
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails()
                    .Where(predicate)
                    .SingleOrDefaultAsync(GetCancellationToken(cancellationToken))
                : await DbSet
                    .Where(predicate)
                    .SingleOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="predicate">A condition to filter entities</param>
        /// <param name="autoSave">Set true to automatically save changes to database.
        /// This is useful for ORMs / database APIs those only save changes with an explicit method call, but you need to immediately save changes to the database.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>Task.</returns>
        public override async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entities = await GetQueryable()
                .Where(predicate)
                .ToListAsync(GetCancellationToken(cancellationToken));

            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(GetCancellationToken(cancellationToken));
            }
        }

        /// <summary>
        /// ensure collection loaded as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual async Task EnsureCollectionLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class
        {
            await DbContext
                .Entry(entity)
                .Collection(propertyExpression)
                .LoadAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// ensure property loaded as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual async Task EnsurePropertyLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, TProperty>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class
        {
            await DbContext
                .Entry(entity)
                .Reference(propertyExpression)
                .LoadAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// Withes the details.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public override IQueryable<TEntity> WithDetails()
        {
            if (EntityOptions.DefaultWithDetailsFunc == null)
            {
                return base.WithDetails();
            }

            return EntityOptions.DefaultWithDetailsFunc(GetQueryable());
        }

        /// <summary>
        /// Withes the details.
        /// </summary>
        /// <param name="propertySelectors">The property selectors.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public override IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetQueryable();

            if (!propertySelectors.IsNullOrEmpty())
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }
    }

    /// <summary>
    /// Class EfCoreRepository.
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{TDbContext, TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity, TKey}" />
    /// Implements the <see cref="ISupportsExplicitLoading{TEntity, TKey}" />
    /// Implements the <see cref="Noob.Domain.Repositories.ISupportsExplicitLoading{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.ISupportsExplicitLoading{TEntity, TKey}" />
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{TDbContext, TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity, TKey}" />
    /// <seealso cref="ISupportsExplicitLoading{TEntity, TKey}" />
    public class EfCoreRepository<TDbContext, TEntity, TKey> : EfCoreRepository<TDbContext,TEntity>, 
        IEfCoreRepository<TEntity, TKey>,
        ISupportsExplicitLoading<TEntity, TKey>
        where TDbContext : EfCoreDbContext
        where TEntity : class, IEntity<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreRepository{TDbContext, TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeDetails">if set to <c>true</c> [include details].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, includeDetails, GetCancellationToken(cancellationToken));

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeDetails">if set to <c>true</c> [include details].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public virtual async Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().FirstOrDefaultAsync(e => e.Id.Equals(id), GetCancellationToken(cancellationToken))
                : await DbSet.FindAsync(new object[] {id}, GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="autoSave">if set to <c>true</c> [automatic save].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
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
