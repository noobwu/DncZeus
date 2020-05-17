// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="ExceptionNotificationContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Noob.ExceptionHandling
{
    /// <summary>
    /// Class ExceptionNotificationContext.
    /// </summary>
    public class ExceptionNotificationContext
    {
        /// <summary>
        /// The exception object.
        /// </summary>
        /// <value>The exception.</value>
        [NotNull]
        public Exception Exception { get; }

        /// <summary>
        /// Gets the log level.
        /// </summary>
        /// <value>The log level.</value>
        public LogLevel LogLevel { get; }

        /// <summary>
        /// True, if it is handled.
        /// </summary>
        /// <value><c>true</c> if handled; otherwise, <c>false</c>.</value>
        public bool Handled { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionNotificationContext"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="handled">if set to <c>true</c> [handled].</param>
        public ExceptionNotificationContext(
            [NotNull] Exception exception,
            LogLevel? logLevel = null,
            bool handled = true)
        {
            Exception = Check.NotNull(exception, nameof(exception));
            LogLevel = logLevel ?? exception.GetLogLevel();
            Handled = handled;
        }
    }
}