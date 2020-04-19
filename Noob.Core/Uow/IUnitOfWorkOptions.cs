// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IUnitOfWorkOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

namespace Noob.Uow
{
    /// <summary>
    /// Interface IUnitOfWorkOptions
    /// </summary>
    public interface IUnitOfWorkOptions
    {
        /// <summary>
        /// Gets a value indicating whether this instance is transactional.
        /// </summary>
        /// <value><c>true</c> if this instance is transactional; otherwise, <c>false</c>.</value>
        bool IsTransactional { get; }

        /// <summary>
        /// Gets the isolation level.
        /// </summary>
        /// <value>The isolation level.</value>
        IsolationLevel? IsolationLevel { get; }

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        TimeSpan? Timeout { get; }
    }
}