// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="FullAuditedAggregateRoot.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// Implements <see cref="IFullAuditedObject" /> to be a base class for full-audited aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.AuditedAggregateRoot" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Auditing.AuditedAggregateRoot" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject" />
    [Serializable]
    public abstract class FullAuditedAggregateRoot : AuditedAggregateRoot, IFullAuditedObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        /// <inheritdoc />
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleter identifier.
        /// </summary>
        /// <value>The deleter identifier.</value>
        /// <inheritdoc />
        public virtual Guid? DeleterId { get; set; }

        /// <summary>
        /// Gets or sets the deletion time.
        /// </summary>
        /// <value>The deletion time.</value>
        /// <inheritdoc />
        public virtual DateTime? DeletionTime { get; set; }
    }

    /// <summary>
    /// Implements <see cref="IFullAuditedObject" /> to be a base class for full-audited aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.Auditing.AuditedAggregateRoot{TKey}" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Auditing.AuditedAggregateRoot{TKey}" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject" />
    [Serializable]
    public abstract class FullAuditedAggregateRoot<TKey> : AuditedAggregateRoot<TKey>, IFullAuditedObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        /// <inheritdoc />
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleter identifier.
        /// </summary>
        /// <value>The deleter identifier.</value>
        /// <inheritdoc />
        public virtual Guid? DeleterId { get; set; }

        /// <summary>
        /// Gets or sets the deletion time.
        /// </summary>
        /// <value>The deletion time.</value>
        /// <inheritdoc />
        public virtual DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullAuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        protected FullAuditedAggregateRoot()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullAuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected FullAuditedAggregateRoot(TKey id)
        : base(id)
        {
            
        }
    }
}