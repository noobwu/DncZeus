// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="AuditedEntityWithUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAuditedObject{TUser}" />.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.AuditedEntity" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.AuditedEntity" />
    /// <seealso cref="Noob.Auditing.IAuditedObject{TUser}" />
    [Serializable]
    public abstract class AuditedEntityWithUser<TUser> : AuditedEntity, IAuditedObject<TUser>
        where TUser : IEntity<Guid>
    {
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
    /// This class can be used to simplify implementing <see cref="IAuditedObject{TUser}" />.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.AuditedEntity{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.AuditedEntity{TKey}" />
    /// <seealso cref="Noob.Auditing.IAuditedObject{TUser}" />
    [Serializable]
    public abstract class AuditedEntityWithUser<TKey, TUser> : AuditedEntity<TKey>, IAuditedObject<TUser>
        where TUser : IEntity<Guid>
    {
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
        /// Initializes a new instance of the <see cref="AuditedEntityWithUser{TKey, TUser}"/> class.
        /// </summary>
        protected AuditedEntityWithUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditedEntityWithUser{TKey, TUser}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected AuditedEntityWithUser(TKey id)
            : base(id)
        {

        }
    }
}