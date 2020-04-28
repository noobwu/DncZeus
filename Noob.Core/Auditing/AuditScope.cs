// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditScope.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IAuditLogScope
    /// </summary>
    public interface IAuditLogScope
    {
        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>The log.</value>
        [NotNull]
        AuditLogInfo Log { get; }
    }
}
