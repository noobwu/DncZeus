// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkOptions.
    /// Implements the <see cref="Noob.Uow.IUnitOfWorkOptions" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IUnitOfWorkOptions" />
    public class UnitOfWorkOptions : IUnitOfWorkOptions
    {
        /// <summary>
        /// Default: false.
        /// </summary>
        /// <value><c>true</c> if this instance is transactional; otherwise, <c>false</c>.</value>
        public bool IsTransactional { get; set; }

        /// <summary>
        /// Gets or sets the isolation level.
        /// </summary>
        /// <value>The isolation level.</value>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkOptions"/> class.
        /// </summary>
        public UnitOfWorkOptions()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkOptions"/> class.
        /// </summary>
        /// <param name="isTransactional">if set to <c>true</c> [is transactional].</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="timeout">The timeout.</param>
        public UnitOfWorkOptions(bool isTransactional = false, IsolationLevel? isolationLevel = null, TimeSpan? timeout = null)
        {
            IsTransactional = isTransactional;
            IsolationLevel = isolationLevel;
            Timeout = timeout;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UnitOfWorkOptions.</returns>
        public UnitOfWorkOptions Clone()
        {
            return new UnitOfWorkOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout
            };
        }
    }
}