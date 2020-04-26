// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="ICreationAuditedObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// This interface can be implemented to store creation information (who and when created).
    /// Implements the <see cref="Noob.Auditing.IHasCreationTime" />
    /// Implements the <see cref="Noob.Auditing.IMayHaveCreator" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IHasCreationTime" />
    /// <seealso cref="Noob.Auditing.IMayHaveCreator" />
    public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
    {

    }

    /// <summary>
    /// Adds navigation property (object reference) to <see cref="ICreationAuditedObject" /> interface.
    /// Implements the <see cref="Noob.Auditing.ICreationAuditedObject" />
    /// Implements the <see cref="Noob.Auditing.IMayHaveCreator{TCreator}" />
    /// </summary>
    /// <typeparam name="TCreator">Type of the user</typeparam>
    /// <seealso cref="Noob.Auditing.ICreationAuditedObject" />
    /// <seealso cref="Noob.Auditing.IMayHaveCreator{TCreator}" />
    public interface ICreationAuditedObject<TCreator> : ICreationAuditedObject, IMayHaveCreator<TCreator>
    {

    }
}