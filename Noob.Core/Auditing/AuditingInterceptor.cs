﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditingInterceptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Noob.Aspects;
using Noob.DependencyInjection;
using Noob.DynamicProxy;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingInterceptor.
    /// Implements the <see cref="Noob.DynamicProxy.Interceptor" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DynamicProxy.Interceptor" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class AuditingInterceptor :Interceptor, ITransientDependency
    {
        /// <summary>
        /// The auditing helper
        /// </summary>
        private readonly IAuditingHelper _auditingHelper;
        /// <summary>
        /// The auditing manager
        /// </summary>
        private readonly IAuditingManager _auditingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingInterceptor"/> class.
        /// </summary>
        /// <param name="auditingHelper">The auditing helper.</param>
        /// <param name="auditingManager">The auditing manager.</param>
        public AuditingInterceptor(IAuditingHelper auditingHelper, IAuditingManager auditingManager)
        {
            _auditingHelper = auditingHelper;
            _auditingManager = auditingManager;
        }

        /// <summary>
        /// intercept as an asynchronous operation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        public override async Task InterceptAsync(IMethodInvocation invocation)
        {
            if (!ShouldIntercept(invocation, out var auditLog, out var auditLogAction))
            {
                await invocation.ProceedAsync();
                return;
            }
            // 开始进行计时操作。
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await invocation.ProceedAsync();
            }
            catch (Exception ex)
            {
                // 如果出现了异常，一样的将异常信息添加到审计日志结果中。
                auditLog.Exceptions.Add(ex);
                throw;
            }
            finally
            {
                // 统计完成，并将信息加入到审计日志结果中。
                stopwatch.Stop();
                auditLogAction.ExecutionDuration = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
                auditLog.Actions.Add(auditLogAction);
            }
        }

        /// <summary>
        /// Shoulds the intercept.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="auditLog">The audit log.</param>
        /// <param name="auditLogAction">The audit log action.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool ShouldIntercept(
            IMethodInvocation invocation, 
            out AuditLogInfo auditLog, 
            out AuditLogActionInfo auditLogAction)
        {
            auditLog = null;
            auditLogAction = null;

            if (CrossCuttingConcerns.IsApplied(invocation.TargetObject, CrossCuttingConcerns.Auditing))
            {
                return false;
            }
            // 如果没有获取到 Scop，则返回 false。
            var auditLogScope = _auditingManager.Current;
            if (auditLogScope == null)
            {
                return false;
            }
            // 进行二次判断是否需要存储审计日志。
            if (!_auditingHelper.ShouldSaveAudit(invocation.Method))
            {
                return false;
            }
            // 构建审计日志信息。
            auditLog = auditLogScope.Log;
            auditLogAction = _auditingHelper.CreateAuditLogAction(
                auditLog,
                invocation.TargetObject.GetType(),
                invocation.Method, 
                invocation.Arguments
            );

            return true;
        }
    }
}
