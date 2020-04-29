// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditLogInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noob.Data;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditLogInfo.
    /// Implements the <see cref="Noob.Data.IHasExtraProperties" />
    /// </summary>
    /// <seealso cref="Noob.Data.IHasExtraProperties" />
    [Serializable]
    public class AuditLogInfo : IHasExtraProperties
    {
        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the impersonator user identifier.
        /// </summary>
        /// <value>The impersonator user identifier.</value>
        public Guid? ImpersonatorUserId { get; set; }

        /// <summary>
        /// Gets or sets the impersonator tenant identifier.
        /// </summary>
        /// <value>The impersonator tenant identifier.</value>
        public Guid? ImpersonatorTenantId { get; set; }

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
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the client ip address.
        /// </summary>
        /// <value>The client ip address.</value>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>The name of the client.</value>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the browser information.
        /// </summary>
        /// <value>The browser information.</value>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        /// <value>The HTTP method.</value>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        /// <value>The HTTP status code.</value>
        public int? HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public List<AuditLogActionInfo> Actions { get; set; }

        /// <summary>
        /// Gets the exceptions.
        /// </summary>
        /// <value>The exceptions.</value>
        public List<Exception> Exceptions { get; }

        /// <summary>
        /// Gets the extra properties.
        /// </summary>
        /// <value>The extra properties.</value>
        public Dictionary<string, object> ExtraProperties { get; }

        /// <summary>
        /// Gets the entity changes.
        /// </summary>
        /// <value>The entity changes.</value>
        public List<EntityChangeInfo> EntityChanges { get; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public List<string> Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogInfo"/> class.
        /// </summary>
        public AuditLogInfo()
        {
            Actions = new List<AuditLogActionInfo>();
            Exceptions = new List<Exception>();
            ExtraProperties = new Dictionary<string, object>();
            EntityChanges = new List<EntityChangeInfo>();
            Comments = new List<string>();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"AUDIT LOG: [{HttpStatusCode?.ToString() ?? "---"}: {(HttpMethod ?? "-------").PadRight(7)}] {Url}");
            sb.AppendLine($"- UserName - UserId                 : {UserName} - {UserId}");
            sb.AppendLine($"- ClientIpAddress        : {ClientIpAddress}");
            sb.AppendLine($"- ExecutionDuration      : {ExecutionDuration}");

            if (Actions.Any())
            {
                sb.AppendLine("- Actions:");
                foreach (var action in Actions)
                {
                    sb.AppendLine($"  - {action.ServiceName}.{action.MethodName} ({action.ExecutionDuration} ms.)");
                    sb.AppendLine($"    {action.Parameters}");
                }
            }

            if (Exceptions.Any())
            {
                sb.AppendLine("- Exceptions:");
                foreach (var exception in Exceptions)
                {
                    sb.AppendLine($"  - {exception.Message}");
                    sb.AppendLine($"    {exception}");
                }
            }

            if (EntityChanges.Any())
            {
                sb.AppendLine("- Entity Changes:");
                foreach (var entityChange in EntityChanges)
                {
                    sb.AppendLine($"  - [{entityChange.ChangeType}] {entityChange.EntityTypeFullName}, Id = {entityChange.EntityId}");
                    foreach (var propertyChange in entityChange.PropertyChanges)
                    {
                        sb.AppendLine($"    {propertyChange.PropertyName}: {propertyChange.OriginalValue} -> {propertyChange.NewValue}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}