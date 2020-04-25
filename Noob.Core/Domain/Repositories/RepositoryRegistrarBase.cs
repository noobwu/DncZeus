// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="RepositoryRegistrarBase.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Domain.Entities;

namespace Noob.Domain.Repositories
{
    /// <summary>
    /// Class RepositoryRegistrarBase.
    /// </summary>
    /// <typeparam name="TOptions">The type of the t options.</typeparam>
    public abstract class RepositoryRegistrarBase<TOptions>
        where TOptions: CommonDbContextRegistrationOptions
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public TOptions Options { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRegistrarBase{TOptions}"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        protected RepositoryRegistrarBase(TOptions options)
        {
            Options = options;
        }

        /// <summary>
        /// Adds the repositories.
        /// </summary>
        public virtual void AddRepositories()
        {
            //遍历自定义仓储。
            foreach (var customRepository in Options.CustomRepositories)
            {
                Options.Services.AddDefaultRepository(customRepository.Key, customRepository.Value);
            }
            //是否注册 ABP vNext 生成的默认仓储。
            if (Options.RegisterDefaultRepositories)
            {
                RegisterDefaultRepositories();
            }
        }

        /// <summary>
        /// Registers the default repositories.
        /// </summary>
        protected virtual void RegisterDefaultRepositories()
        {
            foreach (var entityType in GetEntityTypes(Options.OriginalDbContextType))
            {
                if (!ShouldRegisterDefaultRepositoryFor(entityType))
                {
                    continue;
                }

                RegisterDefaultRepository(entityType);
            }
        }

        /// <summary>
        /// Registers the default repository.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        protected virtual void RegisterDefaultRepository(Type entityType)
        {
            Options.Services.AddDefaultRepository(
                entityType,
                GetDefaultRepositoryImplementationType(entityType)
            );
        }

        /// <summary>
        /// Gets the default type of the repository implementation.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>Type.</returns>
        protected virtual Type GetDefaultRepositoryImplementationType(Type entityType)
        {
            var primaryKeyType = EntityHelper.FindPrimaryKeyType(entityType);

            if (primaryKeyType == null)
            {
                return Options.SpecifiedDefaultRepositoryTypes
                    ? Options.DefaultRepositoryImplementationTypeWithoutKey.MakeGenericType(entityType)
                    : GetRepositoryType(Options.DefaultRepositoryDbContextType, entityType);
            }

            return Options.SpecifiedDefaultRepositoryTypes
                ? Options.DefaultRepositoryImplementationType.MakeGenericType(entityType, primaryKeyType)
                : GetRepositoryType(Options.DefaultRepositoryDbContextType, entityType, primaryKeyType);
        }

        /// <summary>
        /// Shoulds the register default repository for.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool ShouldRegisterDefaultRepositoryFor(Type entityType)
        {
            if (!Options.RegisterDefaultRepositories)
            {
                return false;
            }

            if (Options.CustomRepositories.ContainsKey(entityType))
            {
                return false;
            }

            if (!Options.IncludeAllEntitiesForDefaultRepositories && !typeof(IAggregateRoot).IsAssignableFrom(entityType))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the entity types.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        protected abstract IEnumerable<Type> GetEntityTypes(Type dbContextType);

        /// <summary>
        /// Gets the type of the repository.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>Type.</returns>
        protected abstract Type GetRepositoryType(Type dbContextType, Type entityType);

        /// <summary>
        /// Gets the type of the repository.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="primaryKeyType">Type of the primary key.</param>
        /// <returns>Type.</returns>
        protected abstract Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType);
    }
}