// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditingHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Tracing;
using Noob.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Noob.Clients;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingHelper.
    /// Implements the <see cref="Noob.Auditing.IAuditingHelper" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IAuditingHelper" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class AuditingHelper : IAuditingHelper, ITransientDependency
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        protected ILogger<AuditingHelper> Logger { get; }
        /// <summary>
        /// Gets the auditing store.
        /// </summary>
        /// <value>The auditing store.</value>
        protected IAuditingStore AuditingStore { get; }
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        protected ICurrentUser CurrentUser { get; }
        /// <summary>
        /// Gets the current client.
        /// </summary>
        /// <value>The current client.</value>
        protected ICurrentClient CurrentClient { get; }
        /// <summary>
        /// The audit serializer
        /// </summary>
        protected IAuditSerializer AuditSerializer;
        /// <summary>
        /// The options
        /// </summary>
        protected AuditingOptions Options;
        /// <summary>
        /// The service provider
        /// </summary>
        protected IServiceProvider ServiceProvider;
        /// <summary>
        /// Gets the correlation identifier provider.
        /// </summary>
        /// <value>The correlation identifier provider.</value>
        protected ICorrelationIdProvider CorrelationIdProvider { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingHelper"/> class.
        /// </summary>
        /// <param name="auditSerializer">The audit serializer.</param>
        /// <param name="options">The options.</param>
        /// <param name="currentUser">The current user.</param>
        /// <param name="currentClient">The current client.</param>
        /// <param name="auditingStore">The auditing store.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="correlationIdProvider">The correlation identifier provider.</param>
        public AuditingHelper(
        IAuditSerializer auditSerializer,
        IOptions<AuditingOptions> options,
        ICurrentUser currentUser,
        ICurrentClient currentClient,
        IAuditingStore auditingStore,
        ILogger<AuditingHelper> logger,
        IServiceProvider serviceProvider,
        ICorrelationIdProvider correlationIdProvider)
        {
            Options = options.Value;
            AuditSerializer = auditSerializer;
            CurrentUser = currentUser;
            CurrentClient = currentClient;
            AuditingStore = auditingStore;

            Logger = logger;
            ServiceProvider = serviceProvider;
            CorrelationIdProvider = correlationIdProvider;
        }
        /// <summary>
        /// Shoulds the save audit.
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false)
        {
            if (methodInfo == null)
            {
                return false;
            }

            if (!methodInfo.IsPublic)
            {
                return false;
            }

            if (methodInfo.IsDefined(typeof(AuditedAttribute), true))
            {
                return true;
            }

            if (methodInfo.IsDefined(typeof(DisableAuditingAttribute), true))
            {
                return false;
            }

            var classType = methodInfo.DeclaringType;
            if (classType != null)
            {
                if (AuditingInterceptorRegistrar.ShouldAuditTypeByDefault(classType))
                {
                    return true;
                }
            }

            return defaultValue;
        }
        /// <summary>
        /// Determines whether [is entity history enabled] [the specified entity type].
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if [is entity history enabled] [the specified entity type]; otherwise, <c>false</c>.</returns>
        public virtual bool IsEntityHistoryEnabled(Type entityType, bool defaultValue = false)
        {
            if (!entityType.IsPublic)
            {
                return false;
            }

            if (Options.IgnoredTypes.Any(t => t.IsAssignableFrom(entityType)))
            {
                return false;
            }

            if (entityType.IsDefined(typeof(AuditedAttribute), true))
            {
                return true;
            }

            foreach (var propertyInfo in entityType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.IsDefined(typeof(AuditedAttribute)))
                {
                    return true;
                }
            }

            if (entityType.IsDefined(typeof(DisableAuditingAttribute), true))
            {
                return false;
            }

            if (Options.EntityHistorySelectors.Any(selector => selector.Predicate(entityType)))
            {
                return true;
            }

            return defaultValue;
        }

        /// <summary>
        /// Creates the audit log information.
        /// </summary>
        /// <returns>AuditLogInfo.</returns>
        public virtual AuditLogInfo CreateAuditLogInfo()
        {
            var auditInfo = new AuditLogInfo
            {
                ApplicationName = Options.ApplicationName,
                UserId = CurrentUser.Id,
                UserName = CurrentUser.UserName,
                ClientId = CurrentClient.Id,
                CorrelationId = CorrelationIdProvider.Get(),
                ExecutionTime = DateTime.Now
            };

            ExecutePreContributors(auditInfo);

            return auditInfo;
        }
        /// <summary>
        /// Creates the audit log action.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        /// <param name="type">The type.</param>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>AuditLogActionInfo.</returns>
        public virtual AuditLogActionInfo CreateAuditLogAction(
           AuditLogInfo auditLog,
           Type type,
           MethodInfo method,
           object[] arguments)
        {
            return CreateAuditLogAction(auditLog, type, method, CreateArgumentsDictionary(method, arguments));
        }
        /// <summary>
        /// Creates the audit log action.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        /// <param name="type">The type.</param>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>AuditLogActionInfo.</returns>
        public virtual AuditLogActionInfo CreateAuditLogAction(
        AuditLogInfo auditLog,
        Type type,
        MethodInfo method,
        IDictionary<string, object> arguments)
        {
            var actionInfo = new AuditLogActionInfo
            {
                ServiceName = type != null
                    ? type.FullName
                    : "",
                MethodName = method.Name,
                // 序列化参数信息。
                Parameters = SerializeConvertArguments(arguments),
                ExecutionTime = DateTime.Now
            };

            //TODO Execute contributors

            return actionInfo;
        }

        /// <summary>
        /// Executes the pre contributors.
        /// </summary>
        /// <param name="auditLogInfo">The audit log information.</param>
        protected virtual void ExecutePreContributors(AuditLogInfo auditLogInfo)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new AuditLogContributionContext(scope.ServiceProvider, auditLogInfo);

                foreach (var contributor in Options.Contributors)
                {
                    try
                    {
                        contributor.PreContribute(context);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex, LogLevel.Warning);
                    }
                }
            }
        }
        /// <summary>
        /// Serializes the convert arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>System.String.</returns>
        protected virtual string SerializeConvertArguments(IDictionary<string, object> arguments)
        {
            try
            {
                if (arguments.IsNullOrEmpty())
                {
                    return "{}";
                }

                var dictionary = new Dictionary<string, object>();

                foreach (var argument in arguments)
                {
                    if (argument.Value != null && Options.IgnoredTypes.Any(t => t.IsInstanceOfType(argument.Value)))
                    {
                        dictionary[argument.Key] = null;
                    }
                    else
                    {
                        dictionary[argument.Key] = argument.Value;
                    }
                }
                // 调用序列化器，序列化 Action 的调用参数。
                return AuditSerializer.Serialize(dictionary);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, LogLevel.Warning);
                return "{}";
            }
        }
        /// <summary>
        /// Creates the arguments dictionary.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        protected virtual Dictionary<string, object> CreateArgumentsDictionary(MethodInfo method, object[] arguments)
        {
            var parameters = method.GetParameters();
            var dictionary = new Dictionary<string, object>();

            for (var i = 0; i < parameters.Length; i++)
            {
                dictionary[parameters[i].Name] = arguments[i];
            }

            return dictionary;
        }
    }
}
