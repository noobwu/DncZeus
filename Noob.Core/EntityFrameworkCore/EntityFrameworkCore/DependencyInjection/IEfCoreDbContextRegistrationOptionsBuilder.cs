// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IEfCoreDbContextRegistrationOptionsBuilder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob.DependencyInjection;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    /// <summary>
    /// Interface IEfCoreDbContextRegistrationOptionsBuilder
    /// Implements the <see cref="Noob.DependencyInjection.ICommonDbContextRegistrationOptionsBuilder" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ICommonDbContextRegistrationOptionsBuilder" />
    public interface IEfCoreDbContextRegistrationOptionsBuilder : ICommonDbContextRegistrationOptionsBuilder
    {
        /// <summary>
        /// Entities the specified options action.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="optionsAction">The options action.</param>
        void Entity<TEntity>([NotNull] Action<EfCoreEntityOptions<TEntity>> optionsAction)
            where TEntity : IEntity;
    }
}