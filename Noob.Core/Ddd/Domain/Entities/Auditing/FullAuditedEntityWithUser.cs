// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="FullAuditedEntityWithUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// Implements <see cref="IFullAuditedObject{TUser}" /> to be a base class for full-audited entities.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.FullAuditedEntity" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.FullAuditedEntity" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    [Serializable]
    public abstract class FullAuditedEntityWithUser<TUser> : FullAuditedEntity, IFullAuditedObject<TUser>
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
    /// Implements <see cref="IFullAuditedObjectObject{TUser}" /> to be a base class for full-audited entities.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.FullAuditedEntity{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.FullAuditedEntity{TKey}" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject{TUser}" />
    [Serializable]
    public abstract class FullAuditedEntityWithUser<TKey, TUser> : FullAuditedEntity<TKey>, IFullAuditedObject<TUser>
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
        /// Initializes a new instance of the <see cref="FullAuditedEntityWithUser{TKey, TUser}"/> class.
        /// </summary>
        protected FullAuditedEntityWithUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullAuditedEntityWithUser{TKey, TUser}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected FullAuditedEntityWithUser(TKey id)
            : base(id)
        {

        }
    }
}