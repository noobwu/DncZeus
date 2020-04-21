// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreDbContextRegistrationOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    /// <summary>
    /// Class EfCoreDbContextRegistrationOptions.
    /// Implements the <see cref="Noob.DependencyInjection.CommonDbContextRegistrationOptions" />
    /// Implements the <see cref="Noob.EntityFrameworkCore.DependencyInjection.IEfCoreDbContextRegistrationOptionsBuilder" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.CommonDbContextRegistrationOptions" />
    /// <seealso cref="Noob.EntityFrameworkCore.DependencyInjection.IEfCoreDbContextRegistrationOptionsBuilder" />
    public class EfCoreDbContextRegistrationOptions : CommonDbContextRegistrationOptions, IEfCoreDbContextRegistrationOptionsBuilder
    {
        /// <summary>
        /// Gets the entity options.
        /// </summary>
        /// <value>The entity options.</value>
        public Dictionary<Type, object> EntityOptions { get; }

        /// <summary>
        /// Values the tuple.
        /// </summary>
        /// <param name="originalDbContextType">Type of the original database context.</param>
        /// <param name="services">The services.</param>
        /// <typeparam name="Type">The type of the type.</typeparam>
        /// <typeparam name="IServiceCollection">The type of the i service collection.</typeparam>
        /// <returns>AbpCommonDbContextRegistrationOptions.</returns>
        public EfCoreDbContextRegistrationOptions(Type originalDbContextType, IServiceCollection services)
            : base(originalDbContextType, services)
        {
            EntityOptions = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Entities the specified options action.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="optionsAction">The options action.</param>
        public void Entity<TEntity>(Action<EfCoreEntityOptions<TEntity>> optionsAction) where TEntity : IEntity
        {
            Services.Configure<EfCoreEntityOptions>(options =>
            {
                options.Entity(optionsAction);
            });
        }
    }
}