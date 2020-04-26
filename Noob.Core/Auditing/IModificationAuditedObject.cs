// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IModificationAuditedObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// This interface can be implemented to store modification information (who and when modified lastly).
    /// Implements the <see cref="Noob.Auditing.IHasModificationTime" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IHasModificationTime" />
    public interface IModificationAuditedObject : IHasModificationTime
    {
        /// <summary>
        /// Last modifier user for this entity.
        /// </summary>
        /// <value>The last modifier identifier.</value>
        Guid? LastModifierId { get; set; }
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IModificationAuditedObject" /> interface for a user.
    /// Implements the <see cref="Noob.Auditing.IModificationAuditedObject" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Auditing.IModificationAuditedObject" />
    public interface IModificationAuditedObject<TUser> : IModificationAuditedObject
    {
        /// <summary>
        /// Reference to the last modifier user of this entity.
        /// </summary>
        /// <value>The last modifier.</value>
        TUser LastModifier { get; set; }
    }
}