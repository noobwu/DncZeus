// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreRepositoryRegistrar.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Noob.Domain.Repositories;
using Noob.Domain.Repositories.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    /// <summary>
    /// Class EfCoreRepositoryRegistrar.
    /// Implements the <see cref="Noob.Domain.Repositories.RepositoryRegistrarBase{Noob.EntityFrameworkCore.DependencyInjection.EfCoreDbContextRegistrationOptions}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.RepositoryRegistrarBase{Noob.EntityFrameworkCore.DependencyInjection.EfCoreDbContextRegistrationOptions}" />
    public class EfCoreRepositoryRegistrar : RepositoryRegistrarBase<EfCoreDbContextRegistrationOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreRepositoryRegistrar"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public EfCoreRepositoryRegistrar(EfCoreDbContextRegistrationOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// Gets the entity types.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return DbContextHelper.GetEntityTypes(dbContextType);
        }

        /// <summary>
        /// Gets the type of the repository.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>Type.</returns>
        protected override Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(EfCoreRepository<,>).MakeGenericType(dbContextType, entityType);
        }

        /// <summary>
        /// Gets the type of the repository.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="primaryKeyType">Type of the primary key.</param>
        /// <returns>Type.</returns>
        protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
        {
            return typeof(EfCoreRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
        }
    }
}