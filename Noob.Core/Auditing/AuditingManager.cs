// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditingManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;
using Noob.Threading;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingManager.
    /// Implements the <see cref="Noob.Auditing.IAuditingManager" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IAuditingManager" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class AuditingManager : IAuditingManager, ITransientDependency
    {
        /// <summary>
        /// The ambient context key
        /// </summary>
        private const string AmbientContextKey = "Noob.Auditing.IAuditLogScope";

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        protected IServiceProvider ServiceProvider { get; }
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        protected AuditingOptions Options { get; }
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        protected ILogger<AuditingManager> Logger { get; set; }
        /// <summary>
        /// The ambient scope provider
        /// </summary>
        private readonly IAmbientScopeProvider<IAuditLogScope> _ambientScopeProvider;
        /// <summary>
        /// The auditing helper
        /// </summary>
        private readonly IAuditingHelper _auditingHelper;
        /// <summary>
        /// The auditing store
        /// </summary>
        private readonly IAuditingStore _auditingStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingManager"/> class.
        /// </summary>
        /// <param name="ambientScopeProvider">The ambient scope provider.</param>
        /// <param name="auditingHelper">The auditing helper.</param>
        /// <param name="auditingStore">The auditing store.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="options">The options.</param>
        public AuditingManager(
            IAmbientScopeProvider<IAuditLogScope> ambientScopeProvider,
            IAuditingHelper auditingHelper,
            IAuditingStore auditingStore,
            IServiceProvider serviceProvider,
            IOptions<AuditingOptions> options)
        {
            ServiceProvider = serviceProvider;
            Options = options.Value;
            Logger = NullLogger<AuditingManager>.Instance;

            _ambientScopeProvider = ambientScopeProvider;
            _auditingHelper = auditingHelper;
            _auditingStore = auditingStore;
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public IAuditLogScope Current => _ambientScopeProvider.GetValue(AmbientContextKey);

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <returns>IAuditLogSaveHandle.</returns>
        public IAuditLogSaveHandle BeginScope()
        {
            var ambientScope = _ambientScopeProvider.BeginScope(
                AmbientContextKey,
                new AuditLogScope(_auditingHelper.CreateAuditLogInfo())
            );

            Debug.Assert(Current != null, "Current != null");

            return new DisposableSaveHandle(this, ambientScope, Current.Log, Stopwatch.StartNew());
        }

        /// <summary>
        /// Executes the post contributors.
        /// </summary>
        /// <param name="auditLogInfo">The audit log information.</param>
        protected virtual void ExecutePostContributors(AuditLogInfo auditLogInfo)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new AuditLogContributionContext(scope.ServiceProvider, auditLogInfo);

                foreach (var contributor in Options.Contributors)
                {
                    try
                    {
                        contributor.PostContribute(context);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex, LogLevel.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Befores the save.
        /// </summary>
        /// <param name="saveHandle">The save handle.</param>
        protected virtual void BeforeSave(DisposableSaveHandle saveHandle)
        {
            saveHandle.StopWatch.Stop();
            saveHandle.AuditLog.ExecutionDuration = Convert.ToInt32(saveHandle.StopWatch.Elapsed.TotalMilliseconds);
            ExecutePostContributors(saveHandle.AuditLog);
            MergeEntityChanges(saveHandle.AuditLog);
        }

        /// <summary>
        /// Merges the entity changes.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        protected virtual void MergeEntityChanges(AuditLogInfo auditLog)
        {
            var changeGroups = auditLog.EntityChanges
                .Where(e => e.ChangeType == EntityChangeType.Updated)
                .GroupBy(e => new { e.EntityTypeFullName, e.EntityId })
                .ToList();

            foreach (var changeGroup in changeGroups)
            {
                if (changeGroup.Count() <= 1)
                {
                    continue;
                }

                var firstEntityChange = changeGroup.First();

                foreach (var entityChangeInfo in changeGroup)
                {
                    if (entityChangeInfo == firstEntityChange)
                    {
                        continue;
                    }

                    firstEntityChange.Merge(entityChangeInfo);

                    auditLog.EntityChanges.Remove(entityChangeInfo);
                }
            }
        }

        /// <summary>
        /// save as an asynchronous operation.
        /// </summary>
        /// <param name="saveHandle">The save handle.</param>
        /// <returns>Task.</returns>
        protected virtual async Task SaveAsync(DisposableSaveHandle saveHandle)
        {
            BeforeSave(saveHandle);

            await _auditingStore.SaveAsync(saveHandle.AuditLog);
        }

        /// <summary>
        /// Class DisposableSaveHandle.
        /// Implements the <see cref="Noob.Auditing.IAuditLogSaveHandle" />
        /// </summary>
        /// <seealso cref="Noob.Auditing.IAuditLogSaveHandle" />
        protected class DisposableSaveHandle : IAuditLogSaveHandle
        {
            /// <summary>
            /// Gets the audit log.
            /// </summary>
            /// <value>The audit log.</value>
            public AuditLogInfo AuditLog { get; }
            /// <summary>
            /// Gets the stop watch.
            /// </summary>
            /// <value>The stop watch.</value>
            public Stopwatch StopWatch { get; }

            /// <summary>
            /// The auditing manager
            /// </summary>
            private readonly AuditingManager _auditingManager;
            /// <summary>
            /// The scope
            /// </summary>
            private readonly IDisposable _scope;

            /// <summary>
            /// Initializes a new instance of the <see cref="DisposableSaveHandle"/> class.
            /// </summary>
            /// <param name="auditingManager">The auditing manager.</param>
            /// <param name="scope">The scope.</param>
            /// <param name="auditLog">The audit log.</param>
            /// <param name="stopWatch">The stop watch.</param>
            public DisposableSaveHandle(
                AuditingManager auditingManager,
                IDisposable scope,
                AuditLogInfo auditLog,
                Stopwatch stopWatch)
            {
                _auditingManager = auditingManager;
                _scope = scope;
                AuditLog = auditLog;
                StopWatch = stopWatch;
            }

            /// <summary>
            /// save as an asynchronous operation.
            /// </summary>
            /// <returns>Task.</returns>
            public async Task SaveAsync()
            {
                await _auditingManager.SaveAsync(this);
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}