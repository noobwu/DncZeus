// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="FullAuditedAggregateRootWithUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// Implements <see cref="IFullAuditedObject{TUser}" /> to be a base class for full-audited aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.FullAuditedAggregateRoot" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.FullAuditedAggregateRoot" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    [Serializable]
    public abstract class FullAuditedAggregateRootWithUser<TUser> : FullAuditedAggregateRoot, IFullAuditedObject<TUser>
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// Gets or sets the deleter.
        /// </summary>
        /// <value>The deleter.</value>
        /// <inheritdoc />
        public virtual TUser Deleter { get; set; }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        /// <inheritdoc />
        public virtual TUser Creator { get; set; }

        /// <summary>
        /// Gets or sets the last modifier.
        /// </summary>
        /// <value>The last modifier.</value>
        /// <inheritdoc />
        public virtual TUser LastModifier { get; set; }
    }

    /// <summary>
    /// Implements <see cref="IFullAuditedObject{TUser}" /> to be a base class for full-audited aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.FullAuditedAggregateRoot{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.FullAuditedAggregateRoot{TKey}" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    [Serializable]
    public abstract class FullAuditedAggregateRootWithUser<TKey, TUser> : FullAuditedAggregateRoot<TKey>, IFullAuditedObject<TUser>
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// Gets or sets the deleter.
        /// </summary>
        /// <value>The deleter.</value>
        /// <inheritdoc />
        public virtual TUser Deleter { get; set; }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        /// <inheritdoc />
        public virtual TUser Creator { get; set; }

        /// <summary>
        /// Gets or sets the last modifier.
        /// </summary>
        /// <value>The last modifier.</value>
        /// <inheritdoc />
        public virtual TUser LastModifier { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullAuditedAggregateRootWithUser{TKey, TUser}"/> class.
        /// </summary>
        protected FullAuditedAggregateRootWithUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullAuditedAggregateRootWithUser{TKey, TUser}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected FullAuditedAggregateRootWithUser(TKey id)
            : base(id)
        {

        }
    }
}