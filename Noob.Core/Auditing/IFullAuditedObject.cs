// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IFullAuditedObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// This interface adds <see cref="IDeletionAuditedObject" /> to <see cref="IAuditedObject" />.
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// Implements the <see cref="Noob.Auditing.IDeletionAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    /// <seealso cref="Noob.Auditing.IDeletionAuditedObject" />
    public interface IFullAuditedObject : IAuditedObject, IDeletionAuditedObject
    {
        
    }

    /// <summary>
    /// Adds user navigation properties to <see cref="IFullAuditedObject" /> interface for user.
    /// Implements the <see cref="Noob.Auditing.IAuditedObject{TUser}" />
    /// Implements the <see cref="Noob.Auditing.IFullAuditedObject" />
    /// Implements the <see cref="Noob.Auditing.IDeletionAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Auditing.IAuditedObject{TUser}" />
    /// <seealso cref="Noob.Auditing.IFullAuditedObject" />
    /// <seealso cref="Noob.Auditing.IDeletionAuditedObject{TUser}" />
    public interface IFullAuditedObject<TUser> : IAuditedObject<TUser>, IFullAuditedObject, IDeletionAuditedObject<TUser>
    {

    }
}