// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-11
// ***********************************************************************
// <copyright file="CreationAuditedAggregateRoot.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAuditedObject" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    [Serializable]
    public abstract class CreationAuditedAggregateRoot : AggregateRoot, ICreationAuditedObject
    {
        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>The creation time.</value>
        /// <inheritdoc />
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>The creator identifier.</value>
        /// <inheritdoc />
        public virtual Guid? CreatorId { get; set; }
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAuditedObject" /> for aggregate roots.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{TKey}" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{TKey}" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    [Serializable]
    public abstract class CreationAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICreationAuditedObject
    {
        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>The creation time.</value>
        /// <inheritdoc />
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>The creator identifier.</value>
        /// <inheritdoc />
        public virtual Guid? CreatorId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreationAuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        protected CreationAuditedAggregateRoot()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreationAuditedAggregateRoot{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected CreationAuditedAggregateRoot(TKey id)
            : base(id)
        {

        }
    }
}
