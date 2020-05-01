// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-21
// ***********************************************************************
// <copyright file="HasLogLevelExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Noob.Logging
{
    /// <summary>
    /// Class HasLogLevelExtensions.
    /// </summary>
    public static class HasLogLevelExtensions
    {
        /// <summary>
        /// Withes the log level.
        /// </summary>
        /// <typeparam name="TException">The type of the t exception.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <param name="logLevel">The log level.</param>
        /// <returns>TException.</returns>
        public static TException WithLogLevel<TException>([NotNull] this TException exception, LogLevel logLevel)
            where TException : IHasLogLevel
        {
            Check.NotNull(exception, nameof(exception));

            exception.LogLevel = logLevel;

            return exception;
        }
    }
}
