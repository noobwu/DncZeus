// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 04-05-2020
//
// Last Modified By : Administrator
// Last Modified On : 04-05-2020
// ***********************************************************************
// <copyright file="IEntity.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.Domain.Entities
{
    /// <summary>
    /// Defines an entity. It's primary key may not be "Id" or it may have a composite primary key.
    /// Use <see cref="IEntity{TKey}" /> where possible for better integration to repositories and other structures in the framework.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns>System.Object[].</returns>
        object[] GetKeys();
    }

    /// <summary>
    /// Defines an entity with a single primary key with "Id" property.
    /// Implements the <see cref="Noob.D2CMSApi.Domain.Entities.IEntity" />
    /// Implements the <see cref="Noob.Domain.Entities.IEntity" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.IEntity" />
    /// <seealso cref="Noob.D2CMSApi.Domain.Entities.IEntity" />
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        /// <value>The identifier.</value>
        TKey Id { get; }
    }
}
