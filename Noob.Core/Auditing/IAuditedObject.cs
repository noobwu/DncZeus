// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IAuditedObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// This interface can be implemented to add standard auditing properties to a class.
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// Implements the <see cref="Noob.Auditing.IModificationAuditedObject" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    /// <seealso cref="Noob.Auditing.IModificationAuditedObject" />
    public interface IAuditedObject : ICreationAuditedObject, IModificationAuditedObject
    {

    }

    /// <summary>
    /// Extends <see cref="IAuditedObject" /> to add user navigation properties.
    /// Implements the <see cref="Noob.Auditing.IAuditedObject" />
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    /// Implements the <see cref="Noob.Auditing.IModificationAuditedObject{TUser}" />
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    /// <seealso cref="Noob.Auditing.IAuditedObject" />
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject{TUser}" />
    /// <seealso cref="Noob.Auditing.IModificationAuditedObject{TUser}" />
    public interface IAuditedObject<TUser> : IAuditedObject, ICreationAuditedObject<TUser>, IModificationAuditedObject<TUser>
    {

    }
}