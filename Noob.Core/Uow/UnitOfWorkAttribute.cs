// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

namespace Noob.Uow
{
    /// <summary>
    /// Used to indicate that declaring method (or all methods of the class) is atomic and should be considered as a unit of work (UOW).
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <remarks>This attribute has no effect if there is already a unit of work before calling this method. It uses the ambient UOW in this case.</remarks>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class UnitOfWorkAttribute : Attribute
    {
        /// <summary>
        /// Is this UOW transactional?
        /// Uses default value if not supplied.
        /// </summary>
        /// <value><c>null</c> if [is transactional] contains no value, <c>true</c> if [is transactional]; otherwise, <c>false</c>.</value>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// Timeout of UOW As milliseconds.
        /// Uses default value if not supplied.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// If this UOW is transactional, this option indicated the isolation level of the transaction.
        /// Uses default value if not supplied.
        /// </summary>
        /// <value>The isolation level.</value>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// Used to prevent starting a unit of work for the method.
        /// If there is already a started unit of work, this property is ignored.
        /// Default: false.
        /// </summary>
        /// <value><c>true</c> if this instance is disabled; otherwise, <c>false</c>.</value>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkAttribute"/> class.
        /// </summary>
        public UnitOfWorkAttribute()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkAttribute"/> class.
        /// </summary>
        /// <param name="isTransactional">if set to <c>true</c> [is transactional].</param>
        public UnitOfWorkAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkAttribute"/> class.
        /// </summary>
        /// <param name="isTransactional">if set to <c>true</c> [is transactional].</param>
        /// <param name="isolationLevel">The isolation level.</param>
        public UnitOfWorkAttribute(bool isTransactional, IsolationLevel isolationLevel)
        {
            IsTransactional = isTransactional;
            IsolationLevel = isolationLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkAttribute"/> class.
        /// </summary>
        /// <param name="isTransactional">if set to <c>true</c> [is transactional].</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="timeout">The timeout.</param>
        public UnitOfWorkAttribute(bool isTransactional, IsolationLevel isolationLevel, TimeSpan timeout)
        {
            IsTransactional = isTransactional;
            IsolationLevel = isolationLevel;
            Timeout = timeout;
        }

        //TODO: More constructors!

        /// <summary>
        /// Sets the options.
        /// </summary>
        /// <param name="options">The options.</param>
        public virtual void SetOptions(UnitOfWorkOptions options)
        {
            if (IsTransactional.HasValue)
            {
                options.IsTransactional = IsTransactional.Value;
            }

            if (Timeout.HasValue)
            {
                options.Timeout = Timeout;
            }

            if (IsolationLevel.HasValue)
            {
                options.IsolationLevel = IsolationLevel;
            }
        }
    }
}
