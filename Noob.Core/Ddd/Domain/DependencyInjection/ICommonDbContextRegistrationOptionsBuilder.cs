// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ICommonDbContextRegistrationOptionsBuilder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface ICommonDbContextRegistrationOptionsBuilder
    /// </summary>
    public interface ICommonDbContextRegistrationOptionsBuilder
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        IServiceCollection Services { get; }

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// </summary>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories(bool includeAllEntities = false);

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// Default repositories will use given <see cref="TDefaultRepositoryDbContext" />.
        /// </summary>
        /// <typeparam name="TDefaultRepositoryDbContext">DbContext type that will be used by default repositories</typeparam>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories<TDefaultRepositoryDbContext>(bool includeAllEntities = false);

        /// <summary>
        /// Registers default repositories for this DbContext.
        /// Default repositories will use given <see cref="defaultRepositoryDbContextType" />.
        /// </summary>
        /// <param name="defaultRepositoryDbContextType">DbContext type that will be used by default repositories</param>
        /// <param name="includeAllEntities">Registers repositories only for aggregate root entities by default.
        /// set <see cref="includeAllEntities" /> to true to include all entities.</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder AddDefaultRepositories(Type defaultRepositoryDbContextType, bool includeAllEntities = false);

        /// <summary>
        /// Registers custom repository for a specific entity.
        /// Custom repositories overrides default repositories.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TRepository">Repository type</typeparam>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder AddRepository<TEntity, TRepository>();

        /// <summary>
        /// Uses given class(es) for default repositories.
        /// </summary>
        /// <param name="repositoryImplementationType">Repository implementation type</param>
        /// <param name="repositoryImplementationTypeWithoutKey">Repository implementation type (without primary key)</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder SetDefaultRepositoryClasses([NotNull] Type repositoryImplementationType, [NotNull] Type repositoryImplementationTypeWithoutKey);

        /// <summary>
        /// Replaces given DbContext type with this DbContext type.
        /// </summary>
        /// <typeparam name="TOtherDbContext">The DbContext type to be replaced</typeparam>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder ReplaceDbContext<TOtherDbContext>();

        /// <summary>
        /// Replaces given DbContext type with this DbContext type.
        /// </summary>
        /// <param name="otherDbContextType">The DbContext type to be replaced</param>
        /// <returns>ICommonDbContextRegistrationOptionsBuilder.</returns>
        ICommonDbContextRegistrationOptionsBuilder ReplaceDbContext(Type otherDbContextType);
    }
}