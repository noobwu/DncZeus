// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="IAuditingStore.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IAuditingStore
    /// </summary>
    public interface IAuditingStore
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="auditInfo">The audit information.</param>
        /// <returns>Task.</returns>
        Task SaveAsync(AuditLogInfo auditInfo);
    }
}