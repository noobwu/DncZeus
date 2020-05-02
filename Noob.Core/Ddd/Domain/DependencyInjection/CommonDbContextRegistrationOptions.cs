// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="CommonDbContextRegistrationOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Noob.Domain.Entities;
using Noob.Domain.Repositories;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// This is a base class for dbcoUse derived
    /// Implements the <see cref="Noob.DependencyInjection.ICommonDbContextRegistrationOptionsBuilder" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ICommonDbContextRegistrationOptionsBuilder" />
    public abstract class CommonDbContextRegistrationOptions : ICommonDbContextRegistrationOptionsBuilder
    {
        /// <summary>
        /// Gets the type of the original database context.
        /// </summary>
        /// <value>The type of the original database context.</value>
        public Type OriginalDbContextType { get; }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets the replaced database context types.
        /// </summary>
        /// <value>The replaced database context types.</value>
        public List<Type> ReplacedDbContextTypes { get; }

        /// <summary>
        /// Gets or sets the default type of the repository database context.
        /// </summary>
        /// <value>The default type of the repository database context.</value>
        public Type DefaultRepositoryDbContextType { get; protected set; }

        /// <summary>
        /// Gets the default type of the repository implementation.
        /// </summary>
        /// <value>The default type of the repository implementation.</value>
        public Type DefaultRepositoryImplementationType { get; private set; }

        /// <summary>
        /// Gets the default repository implementation type without key.
        /// </summary>
        /// <value>The default repository implementation type without key.</value>
        public Type DefaultRepositoryImplementationTypeWithoutKey { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [register default repositories].
        /// </summary>
        /// <value><c>true</c> if [register default repositories]; otherwise, <c>false</c>.</value>
        public bool RegisterDefaultRepositories { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [include all entities for default repositories].
        /// </summary>
        /// <value><c>true</c> if [include all entities for default repositories]; otherwise, <c>false</c>.</value>
        public bool IncludeAllEntitiesForDefaultRepositories { get; private set; }

        /// <summary>
        /// Gets the custom repositories.
        /// </summary>
        /// <value>The custom repositories.</value>
        public Dictionary<Type, Type> CustomRepositories { get; }

        /// <summary>
        /// Gets a value indicating whether [specified default repository types].
        /// </summary>
        /// <value><c>true</c> if [specified default repository types]; otherwise, <c>false</c>.</value>
        public bool SpecifiedDefaultRepositoryTypes => DefaultRepositoryImplementationType != null && DefaultRepositoryImplementationTypeWithoutKey != null;

        /// <summary>
        /// Values the tuple.
        /// </summary>
        /// <param name="originalDbContextType">Type of the original database context.</param>
        /// <param name="services">The services.</param>
        /// <typeparam name="Type">The type of the type.</typeparam>
        /// <typeparam name="IServiceCollection">The type of the i service collection.</typeparam>
        /// <returns>AbpCommonDbContextRegistrationOptions.</returns>
        protected CommonDbContextRegistrationOptions(Type originalDbContextType, IServiceCollection services)
        {
            OriginalDbContextType = originalDbContextType;
            Services = services;
            DefaultRepositoryDbContextType = originalDbContextType;
            CustomRepositories = new Dictionary<Type, Type>();
            ReplacedDbContextTypes = new List<Type>();
        }

        /// <summary>
        /// Replaces given DbContext type with this DbContext type.
        /// </summary>
        /// <typeparam name="TOtherDbContext">The DbContext type to be replaced</typeparam>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        public ICommonDbContextRegistrationOptionsBuilder ReplaceDbContext<TOtherDbContext>()
        {
            return ReplaceDbContext(typeof(TOtherDbContext));
        }

        /// <summary>
        /// Replaces given DbContext type with this DbContext type.
        /// </summary>
        /// <param name="otherDbContextType">The DbContext type to be replaced</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        /// <exception cref="Exception"></exception>
        public ICommonDbContextRegistrationOptionsBuilder ReplaceDbContext(Type otherDbContextType)
        {
            if (!otherDbContextType.IsAssignableFrom(OriginalDbContextType))
            {
                throw new Exception($"{OriginalDbContextType.AssemblyQualifiedName} should inherit/implement {otherDbContextType.AssemblyQualifiedName}!");
            }

            ReplacedDbContextTypes.Add(otherDbContextType);

            return this;
        }

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// </summary>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        public ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories(bool includeAllEntities = false)
        {
            RegisterDefaultRepositories = true;
            IncludeAllEntitiesForDefaultRepositories = includeAllEntities;

            return this;
        }

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// Default repositories will use given <see cref="defaultRepositoryDbContextType" />.
        /// </summary>
        /// <param name="defaultRepositoryDbContextType">DbContext type that will be used by default repositories</param>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        /// <exception cref="Exception"></exception>
        public ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories(Type defaultRepositoryDbContextType, bool includeAllEntities = false)
        {
            if (!defaultRepositoryDbContextType.IsAssignableFrom(OriginalDbContextType))
            {
                throw new Exception($"{OriginalDbContextType.AssemblyQualifiedName} should inherit/implement {defaultRepositoryDbContextType.AssemblyQualifiedName}!");
            }

            DefaultRepositoryDbContextType = defaultRepositoryDbContextType;

            return AddDefaultRepositories(includeAllEntities);
        }

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// Default repositories will use given <see cref="TDefaultRepositoryDbContext" />.
        /// </summary>
        /// <typeparam name="TDefaultRepositoryDbContext">DbContext type that will be used by default repositories</typeparam>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        public ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories<TDefaultRepositoryDbContext>(bool includeAllEntities = false)
        {
            return AddDefaultRepositories(typeof(TDefaultRepositoryDbContext), includeAllEntities);
        }

        /// <summary>
        /// Registers custom repository for a specific entity.
        /// Custom repositories overrides default repositories.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TRepository">Repository type</typeparam>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        public ICommonDbContextRegistrationOptionsBuilder AddRepository<TEntity, TRepository>()
        {
            AddCustomRepository(typeof(TEntity), typeof(TRepository));

            return this;
        }

        /// <summary>
        /// Uses given class(es) for default repositories.
        /// </summary>
        /// <param name="repositoryImplementationType">Repository implementation type</param>
        /// <param name="repositoryImplementationTypeWithoutKey">Repository implementation type (without primary key)</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        public ICommonDbContextRegistrationOptionsBuilder SetDefaultRepositoryClasses(
            Type repositoryImplementationType,
            Type repositoryImplementationTypeWithoutKey
            )
        {
            Check.NotNull(repositoryImplementationType, nameof(repositoryImplementationType));
            Check.NotNull(repositoryImplementationTypeWithoutKey, nameof(repositoryImplementationTypeWithoutKey));

            DefaultRepositoryImplementationType = repositoryImplementationType;
            DefaultRepositoryImplementationTypeWithoutKey = repositoryImplementationTypeWithoutKey;

            return this;
        }

        /// <summary>
        /// Adds the custom repository.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="repositoryType">Type of the repository.</param>
        /// <exception cref="Exception">
        /// Given entityType is not an entity: {entityType.AssemblyQualifiedName}. It must implement {typeof(IEntity<>).AssemblyQualifiedName}.
        /// or
        /// Given repositoryType is not a repository: {entityType.AssemblyQualifiedName}. It must implement {typeof(IBasicRepository<>).AssemblyQualifiedName}.
        /// </exception>
        private void AddCustomRepository(Type entityType, Type repositoryType)
        {
            if (!typeof(IEntity).IsAssignableFrom(entityType))
            {
                throw new Exception($"Given entityType is not an entity: {entityType.AssemblyQualifiedName}. It must implement {typeof(IEntity<>).AssemblyQualifiedName}.");
            }

            if (!typeof(IRepository).IsAssignableFrom(repositoryType))
            {
                throw new Exception($"Given repositoryType is not a repository: {entityType.AssemblyQualifiedName}. It must implement {typeof(IBasicRepository<>).AssemblyQualifiedName}.");
            }

            CustomRepositories[entityType] = repositoryType;
        }

        /// <summary>
        /// Shoulds the register default repository for.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldRegisterDefaultRepositoryFor(Type entityType)
        {
            if (!RegisterDefaultRepositories)
            {
                return false;
            }

            if (CustomRepositories.ContainsKey(entityType))
            {
                return false;
            }

            if (!IncludeAllEntitiesForDefaultRepositories && !typeof(IAggregateRoot).IsAssignableFrom(entityType))
            {
                return false;
            }

            return true;
        }
    }
}