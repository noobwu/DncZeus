// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="CreationAuditedEntity.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Auditing;

namespace Noob.Domain.Entities.Auditing
{
    /// <summary>
    /// This class can be used to simplify implementing <see cref="T:Noob.Auditing.ICreationAuditedObject" /> for an entity.
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    [Serializable]
    public abstract class CreationAuditedEntity : Entity, ICreationAuditedObject
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
    /// This class can be used to simplify implementing <see cref="ICreationAuditedObject" /> for an entity.
    /// Implements the <see cref="Noob.Domain.Entities.Entity{TKey}" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Entity{TKey}" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    [Serializable]
    public abstract class CreationAuditedEntity<TKey> : Entity<TKey>, ICreationAuditedObject
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
        /// Initializes a new instance of the <see cref="CreationAuditedEntity{TKey}"/> class.
        /// </summary>
        protected CreationAuditedEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreationAuditedEntity{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected CreationAuditedEntity(TKey id)
            : base(id)
        {

        }
    }
}