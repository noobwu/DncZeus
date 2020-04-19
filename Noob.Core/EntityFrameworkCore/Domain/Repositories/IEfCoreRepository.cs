// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IEfCoreRepository.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories.EntityFrameworkCore
{
    /// <summary>
    /// Interface IEfCoreRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.IRepository{TEntity}" />
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        DbContext DbContext { get; }

        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <value>The database set.</value>
        DbSet<TEntity> DbSet { get; }
    }

    /// <summary>
    /// Interface IEfCoreRepository
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity}" />
    /// Implements the <see cref="Noob.Domain.Repositories.IRepository{TEntity, TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.IEfCoreRepository{TEntity}" />
    /// <seealso cref="Noob.Domain.Repositories.IRepository{TEntity, TKey}" />
    public interface IEfCoreRepository<TEntity, TKey> : IEfCoreRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}