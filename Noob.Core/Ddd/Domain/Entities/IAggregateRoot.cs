// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IAggregateRoot.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Domain.Entities
{
    /// <summary>
    /// Defines an aggregate root. It's primary key may not be "Id" or it may have a composite primary key.
    /// Use <see cref="IAggregateRoot{TKey}" /> where possible for better integration to repositories and other structures in the framework.
    /// Implements the <see cref="Noob.Domain.Entities.IEntity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.IEntity" />
    public interface IAggregateRoot : IEntity
    {

    }

    /// <summary>
    /// Defines an aggregate root with a single primary key with "Id" property.
    /// Implements the <see cref="Noob.Domain.Entities.IEntity{TKey}" />
    /// Implements the <see cref="Noob.Domain.Entities.IAggregateRoot" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.IEntity{TKey}" />
    /// <seealso cref="Noob.Domain.Entities.IAggregateRoot" />
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {

    }
}
