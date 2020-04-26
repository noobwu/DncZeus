// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IAuditPropertySetter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// Interface IAuditPropertySetter
    /// </summary>
    public interface IAuditPropertySetter
    {
        /// <summary>
        /// Sets the creation properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        void SetCreationProperties(object targetObject);

        /// <summary>
        /// Sets the modification properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        void SetModificationProperties(object targetObject);

        /// <summary>
        /// Sets the deletion properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        void SetDeletionProperties(object targetObject);
    }
}