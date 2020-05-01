// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditingOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingOptions.
    /// </summary>
    public class AuditingOptions
    {
        //TODO: Consider to add an option to disable auditing for application service methods?

        /// <summary>
        /// If this value is true, auditing will not throw an exceptions and it will log it when an error occurred while saving AuditLog.
        /// Default: true.
        /// </summary>
        /// <value><c>true</c> if [hide errors]; otherwise, <c>false</c>.</value>
        public bool HideErrors { get; set; }

        /// <summary>
        /// Default: true.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 审计日志的应用程序名称，默认值为 null，主要在构建 AuditingInfo 被使用。
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Default: true.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled for anonymous users; otherwise, <c>false</c>.</value>
        public bool IsEnabledForAnonymousUsers { get; set; }

        /// <summary>
        /// Audit log on exceptions.
        /// Default: true.
        /// </summary>
        /// <value><c>true</c> if [always log on exception]; otherwise, <c>false</c>.</value>
        public bool AlwaysLogOnException { get; set; }

        /// <summary>
        /// 审计日志功能的协作者集合，默认添加了 AspNetCoreAuditLogContributor 实现。
        /// </summary>
        /// <value>The contributors.</value>
        public List<AuditLogContributor> Contributors { get; }

        /// <summary>
        /// 默认的忽略类型，主要在序列化时使用。
        /// </summary>
        /// <value>The ignored types.</value>
        public List<Type> IgnoredTypes { get; }

        /// <summary>
        /// 实体类型选择器。
        /// </summary>
        /// <value>The entity history selectors.</value>
        public IEntityHistorySelectorList EntityHistorySelectors { get; }

        //TODO: Move this to asp.net core layer or convert it to a more dynamic strategy?
        /// <summary>
        /// 是否为 Get 请求记录审计日志，默认值 false。
        /// </summary>
        /// <value><c>true</c> if this instance is enabled for get requests; otherwise, <c>false</c>.</value>
        public bool IsEnabledForGetRequests { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingOptions"/> class.
        /// </summary>
        public AuditingOptions()
        {
            IsEnabled = true;
            IsEnabledForAnonymousUsers = true;
            HideErrors = true;
            AlwaysLogOnException = true;

            Contributors = new List<AuditLogContributor>();

            IgnoredTypes = new List<Type>
            {
                typeof(Stream),
                typeof(Expression)
            };

            EntityHistorySelectors = new EntityHistorySelectorList();
        }
    }
}