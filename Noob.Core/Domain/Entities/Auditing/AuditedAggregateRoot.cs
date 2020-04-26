// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-11
// ***********************************************************************
// <copyright file="AuditedAggregateRoot.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="IAuditedObject" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot" />
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    [Serializable]
    public abstract class AuditedAggregateRoot : CreationAuditedAggregateRoot, IAuditedObject
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
    /// This class can be used to simplify implementing <see cref="IAuditedObject" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.CreationAuditedAggregateRoot{TKey}" />
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    [Serializable]
    public abstract class AuditedAggregateRoot<TKey> : CreationAuditedAggregateRoot<TKey>, IAuditedObject
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
        /// Initializes a new instance of the <see cref="AuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        protected AuditedAggregateRoot()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected AuditedAggregateRoot(TKey id)
            : base(id)
        {

        }
    }
}