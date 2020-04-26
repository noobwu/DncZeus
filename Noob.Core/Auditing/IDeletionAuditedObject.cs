// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IDeletionAuditedObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// This interface can be implemented to store deletion information (who delete and when deleted).
    /// Implements the <see cref="Noob.Auditing.IHasDeletionTime" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IHasDeletionTime" />
    public interface IDeletionAuditedObject : IHasDeletionTime
    {
        /// <summary>
        /// Id of the deleter user.
        /// </summary>
        /// <value>The deleter identifier.</value>
        Guid? DeleterId { get; set; }
    }

    /// <summary>
    /// Extends <see cref="IDeletionAuditedObject" /> to add user navigation propery.
    /// Implements the <see cref="Noob.Auditing.IDeletionAuditedObject" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Auditing.IDeletionAuditedObject" />
    public interface IDeletionAuditedObject<TUser> : IDeletionAuditedObject
    {
        /// <summary>
        /// Reference to the deleter user.
        /// </summary>
        /// <value>The deleter.</value>
        TUser Deleter { get; set; }
    }
}