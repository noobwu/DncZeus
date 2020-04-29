// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="IAuditingHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Noob.Auditing
{
    //TODO: Move ShouldSaveAudit & IsEntityHistoryEnabled and rename to IAuditingFactory
    /// <summary>
    /// Interface IAuditingHelper
    /// </summary>
    public interface IAuditingHelper
    {
        /// <summary>
        /// Shoulds the save audit.
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false);

        /// <summary>
        /// Determines whether [is entity history enabled] [the specified entity type].
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if [is entity history enabled] [the specified entity type]; otherwise, <c>false</c>.</returns>
        bool IsEntityHistoryEnabled(Type entityType, bool defaultValue = false);

        /// <summary>
        /// Creates the audit log information.
        /// </summary>
        /// <returns>AuditLogInfo.</returns>
        AuditLogInfo CreateAuditLogInfo();

        /// <summary>
        /// Creates the audit log action.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        /// <param name="type">The type.</param>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>AuditLogActionInfo.</returns>
        AuditLogActionInfo CreateAuditLogAction(
            AuditLogInfo auditLog,
            Type type,
            MethodInfo method,
            object[] arguments
        );

        /// <summary>
        /// Creates the audit log action.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        /// <param name="type">The type.</param>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>AuditLogActionInfo.</returns>
        AuditLogActionInfo CreateAuditLogAction(
            AuditLogInfo auditLog,
            Type type,
            MethodInfo method,
            IDictionary<string, object> arguments
        );
    }
}