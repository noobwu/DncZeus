// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="AuditedEntity.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAuditedObject" />.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedEntity" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedEntity" />
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    [Serializable]
    public abstract class AuditedEntity : CreationAuditedEntity, IAuditedObject
    {
        /// <summary>
        /// Gets or sets the last modification time.
        /// </summary>
        /// <value>The last modification time.</value>
        /// <inheritdoc />
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modifier identifier.
        /// </summary>
        /// <value>The last modifier identifier.</value>
        /// <inheritdoc />
        public virtual Guid? LastModifierId { get; set; }
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAuditedObject" />.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedEntity{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedEntity{TKey}" />
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    [Serializable]
    public abstract class AuditedEntity<TKey> : CreationAuditedEntity<TKey>, IAuditedObject
    {
        /// <summary>
        /// Gets or sets the last modification time.
        /// </summary>
        /// <value>The last modification time.</value>
        /// <inheritdoc />
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modifier identifier.
        /// </summary>
        /// <value>The last modifier identifier.</value>
        /// <inheritdoc />
        public virtual Guid? LastModifierId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditedEntity{TKey}"/> class.
        /// </summary>
        protected AuditedEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditedEntity{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected AuditedEntity(TKey id)
            : base(id)
        {

        }
    }
}