// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EntityOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.DependencyInjection
/// <summary>
/// Class EntityOptions.
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
{
    public class EfCoreEntityOptions<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Gets the empty.
        /// </summary>
        /// <value>The empty.</value>
        public static EfCoreEntityOptions<TEntity> Empty { get; } = new EfCoreEntityOptions<TEntity>();

        /// <summary>
        /// Gets or sets the default with details function.
        /// </summary>
        /// <value>The default with details function.</value>
        public Func<IQueryable<TEntity>, IQueryable<TEntity>> DefaultWithDetailsFunc { get; set; }
    }

    /// <summary>
    /// Class EntityOptions.
    /// </summary>
    public class EntityOptions
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly IDictionary<Type, object> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityOptions" /> class.
        /// </summary>
        public EntityOptions()
        {
            _options = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets the or null.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <returns>EntityOptions&lt;TEntity&gt;.</returns>
        public EfCoreEntityOptions<TEntity> GetOrNull<TEntity>()
            where TEntity : IEntity
        {
            return _options.GetOrDefault(typeof(TEntity)) as EfCoreEntityOptions<TEntity>;
        }

        /// <summary>
        /// Entities the specified options action.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="optionsAction">The options action.</param>
        public void Entity<TEntity>([NotNull] Action<EfCoreEntityOptions<TEntity>> optionsAction)
            where TEntity : IEntity
        {
            Check.NotNull(optionsAction, nameof(optionsAction));

            optionsAction(
                _options.GetOrAdd(
                    typeof(TEntity),
                    () => new EfCoreEntityOptions<TEntity>()
                ) as EfCoreEntityOptions<TEntity>
            );
        }
    }
}