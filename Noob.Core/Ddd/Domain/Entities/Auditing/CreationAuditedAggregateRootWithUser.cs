// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="CreationAuditedAggregateRootWithUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAuditedObjectObject{TCreator}" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    [Serializable]
    public abstract class CreationAuditedAggregateRootWithUser<TUser> : CreationAuditedAggregateRoot, ICreationAuditedObject<TUser>
    {
        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        /// <inheritdoc />
        public virtual TUser Creator { get; set; }
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAuditedObjectObject{TCreator}" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot{TKey}" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot{TKey}" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    [Serializable]
    public abstract class CreationAuditedAggregateRootWithUser<TKey, TUser> : CreationAuditedAggregateRoot<TKey>, ICreationAuditedObject<TUser>
    {
        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        /// <inheritdoc />
        public virtual TUser Creator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreationAuditedAggregateRootWithUser{TKey, TUser}"/> class.
        /// </summary>
        protected CreationAuditedAggregateRootWithUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreationAuditedAggregateRootWithUser{TKey, TUser}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected CreationAuditedAggregateRootWithUser(TKey id)
            : base(id)
        {

        }
    }
}