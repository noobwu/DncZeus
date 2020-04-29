// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="IAuditingManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IAuditingManager
    /// </summary>
    public interface IAuditingManager
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        [CanBeNull]
        IAuditLogScope Current { get; }

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <returns>IAuditLogSaveHandle.</returns>
        IAuditLogSaveHandle BeginScope();
    }
}