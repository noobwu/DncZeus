// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkDefaultOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

namespace Noob.Uow
{
    //TODO: Implement default options!

    /// <summary>
    /// Global (default) unit of work options
    /// </summary>
    public class UnitOfWorkDefaultOptions
    {
        /// <summary>
        /// Default value: <see cref="UnitOfWorkTransactionBehavior.Auto" />.
        /// </summary>
        /// <value>The transaction behavior.</value>
        public UnitOfWorkTransactionBehavior TransactionBehavior { get; set; } = UnitOfWorkTransactionBehavior.Auto;

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
        /// Normalizes the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>UnitOfWorkOptions.</returns>
        internal UnitOfWorkOptions Normalize(UnitOfWorkOptions options)
        {
            if (options.IsolationLevel == null)
            {
                options.IsolationLevel = IsolationLevel;
            }

            if (options.Timeout == null)
            {
                options.Timeout = Timeout;
            }

            return options;
        }

        /// <summary>
        /// Calculates the is transactional.
        /// </summary>
        /// <param name="autoValue">if set to <c>true</c> [automatic value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception">Not implemented TransactionBehavior value: " + TransactionBehavior</exception>
        public bool CalculateIsTransactional(bool autoValue)
        {
            switch (TransactionBehavior)
            {
                case UnitOfWorkTransactionBehavior.Enabled:
                    return true;
                case UnitOfWorkTransactionBehavior.Disabled:
                    return false;
                case UnitOfWorkTransactionBehavior.Auto:
                    return autoValue;
                default:
                    throw new Exception("Not implemented TransactionBehavior value: " + TransactionBehavior);
            }
        }
    }
}