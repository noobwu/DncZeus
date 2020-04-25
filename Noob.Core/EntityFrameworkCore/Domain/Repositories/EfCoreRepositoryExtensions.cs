// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-25
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="EfCoreRepositoryExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore;
using Noob.Domain.Entities;
using Noob.Domain.Repositories.EntityFrameworkCore;

namespace Noob.Domain.Repositories
{
    //TODO: Should work for any IRepository implementation

    /// <summary>
    /// Class EfCoreRepositoryExtensions.
    /// </summary>
    public static class EfCoreRepositoryExtensions
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns>DbContext.</returns>
        public static DbContext GetDbContext<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToEfCoreRepository().DbContext;
        }

        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns>DbSet&lt;TEntity&gt;.</returns>
        public static DbSet<TEntity> GetDbSet<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToEfCoreRepository().DbSet;
        }

        /// <summary>
        /// Converts to efcorerepository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns>IEfCoreRepository&lt;TEntity, TKey&gt;.</returns>
        /// <exception cref="ArgumentException">Given repository does not implement " + typeof(IEfCoreRepository<TEntity, TKey>).AssemblyQualifiedName - repository</exception>
        public static IEfCoreRepository<TEntity, TKey> ToEfCoreRepository<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            var efCoreRepository = repository as IEfCoreRepository<TEntity, TKey>;
            if (efCoreRepository == null)
            {
                throw new ArgumentException("Given repository does not implement " + typeof(IEfCoreRepository<TEntity, TKey>).AssemblyQualifiedName, nameof(repository));
            }

            return efCoreRepository;
        }
    }
}
