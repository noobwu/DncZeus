// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditLogActionInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Noob.Data;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditLogActionInfo.
    /// Implements the <see cref="Noob.Data.IHasExtraProperties" />
    /// </summary>
    /// <seealso cref="Noob.Data.IHasExtraProperties" />
    [Serializable]
    public class AuditLogActionInfo : IHasExtraProperties
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>The name of the method.</value>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public string Parameters { get; set; }

        /// <summary>
        /// Gets or sets the execution time.
        /// </summary>
        /// <value>The execution time.</value>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Gets or sets the duration of the execution.
        /// </summary>
        /// <value>The duration of the execution.</value>
        public int ExecutionDuration { get; set; }

        /// <summary>
        /// Gets the extra properties.
        /// </summary>
        /// <value>The extra properties.</value>
        public Dictionary<string, object> ExtraProperties { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogActionInfo"/> class.
        /// </summary>
        public AuditLogActionInfo()
        {
            ExtraProperties = new Dictionary<string, object>();
        }
    }
}