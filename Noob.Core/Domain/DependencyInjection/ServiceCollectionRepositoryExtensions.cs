// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="ServiceCollectionRepositoryExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.Domain.Entities;
using Noob.Domain.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionRepositoryExtensions.
    /// </summary>
    public static class ServiceCollectionRepositoryExtensions
    {
        /// <summary>
        /// Adds the default repository.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="repositoryImplementationType">Type of the repository implementation.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddDefaultRepository(this IServiceCollection services, Type entityType, Type repositoryImplementationType)
        {
            //注册复合主键实体所对应的仓储。
            //IReadOnlyBasicRepository<TEntity>
            var readOnlyBasicRepositoryInterface = typeof(IReadOnlyBasicRepository<>).MakeGenericType(entityType);
            if (readOnlyBasicRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
            {
                services.TryAddTransient(readOnlyBasicRepositoryInterface, repositoryImplementationType);

                //IReadOnlyRepository<TEntity>
                var readOnlyRepositoryInterface = typeof(IReadOnlyRepository<>).MakeGenericType(entityType);
                if (readOnlyRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
                {
                    services.TryAddTransient(readOnlyRepositoryInterface, repositoryImplementationType);
                }

                //IBasicRepository<TEntity>
                var basicRepositoryInterface = typeof(IBasicRepository<>).MakeGenericType(entityType);
                if (basicRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
                {
                    services.TryAddTransient(basicRepositoryInterface, repositoryImplementationType);

                    //IRepository<TEntity>
                    var repositoryInterface = typeof(IRepository<>).MakeGenericType(entityType);
                    if (repositoryInterface.IsAssignableFrom(repositoryImplementationType))
                    {
                        services.TryAddTransient(repositoryInterface, repositoryImplementationType);
                    }
                }
            }
            //首先获得实体的主键类型，再进行注册。
            var primaryKeyType = EntityHelper.FindPrimaryKeyType(entityType);
            if (primaryKeyType != null)
            {
                //IReadOnlyBasicRepository<TEntity, TKey>
                var readOnlyBasicRepositoryInterfaceWithPk = typeof(IReadOnlyBasicRepository<,>).MakeGenericType(entityType, primaryKeyType);
                if (readOnlyBasicRepositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
                {
                    services.TryAddTransient(readOnlyBasicRepositoryInterfaceWithPk, repositoryImplementationType);

                    //IReadOnlyRepository<TEntity, TKey>
                    var readOnlyRepositoryInterfaceWithPk = typeof(IReadOnlyRepository<,>).MakeGenericType(entityType, primaryKeyType);
                    if (readOnlyRepositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
                    {
                        services.TryAddTransient(readOnlyRepositoryInterfaceWithPk, repositoryImplementationType);
                    }

                    //IBasicRepository<TEntity, TKey>
                    var basicRepositoryInterfaceWithPk = typeof(IBasicRepository<,>).MakeGenericType(entityType, primaryKeyType);
                    if (basicRepositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
                    {
                        services.TryAddTransient(basicRepositoryInterfaceWithPk, repositoryImplementationType);

                        //IRepository<TEntity, TKey>
                        var repositoryInterfaceWithPk = typeof(IRepository<,>).MakeGenericType(entityType, primaryKeyType);
                        if (repositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
                        {
                            services.TryAddTransient(repositoryInterfaceWithPk, repositoryImplementationType);
                        }
                    }
                }
            }

            return services;
        }
    }
}