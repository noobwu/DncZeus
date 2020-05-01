// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="LoggerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Noob.ExceptionHandling;
using Noob.Logging;
namespace Microsoft.Extensions.Logging
{
    /// <summary>
    /// Class LoggerExtensions.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Logs the with level.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        public static void LogWithLevel(this ILogger logger, LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    logger.LogCritical(message);
                    break;
                case LogLevel.Error:
                    logger.LogError(message);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning(message);
                    break;
                case LogLevel.Information:
                    logger.LogInformation(message);
                    break;
                case LogLevel.Trace:
                    logger.LogTrace(message);
                    break;
                default: // LogLevel.Debug || LogLevel.None
                    logger.LogDebug(message);
                    break;
            }
        }

        /// <summary>
        /// Logs the with level.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void LogWithLevel(this ILogger logger, LogLevel logLevel, string message, Exception exception)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    logger.LogCritical(exception, message);
                    break;
                case LogLevel.Error:
                    logger.LogError(exception, message);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning(exception, message);
                    break;
                case LogLevel.Information:
                    logger.LogInformation(exception, message);
                    break;
                case LogLevel.Trace:
                    logger.LogTrace(exception, message);
                    break;
                default: // LogLevel.Debug || LogLevel.None
                    logger.LogDebug(exception, message);
                    break;
            }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="level">The level.</param>
        public static void LogException(this ILogger logger, Exception ex, LogLevel? level = null)
        {
            var selectedLevel = level ?? ex.GetLogLevel();

            logger.LogWithLevel(selectedLevel, ex.Message, ex);
            LogKnownProperties(logger, ex, selectedLevel);
            LogSelfLogging(logger, ex);
            LogData(logger, ex, selectedLevel);
        }

        /// <summary>
        /// Logs the known properties.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="logLevel">The log level.</param>
        private static void LogKnownProperties(ILogger logger, Exception exception, LogLevel logLevel)
        {
            if (exception is IHasErrorCode exceptionWithErrorCode)
            {
                logger.LogWithLevel(logLevel, "Code:" + exceptionWithErrorCode.Code);
            }

            if (exception is IHasErrorDetails exceptionWithErrorDetails)
            {
                logger.LogWithLevel(logLevel, "Details:" + exceptionWithErrorDetails.Details);
            }
        }

        /// <summary>
        /// Logs the data.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="logLevel">The log level.</param>
        private static void LogData(ILogger logger, Exception exception, LogLevel logLevel)
        {
            if (exception.Data == null || exception.Data.Count <= 0)
            {
                return;
            }

            logger.LogWithLevel(logLevel, "---------- Exception Data ----------");

            foreach (var key in exception.Data.Keys)
            {
                logger.LogWithLevel(logLevel, $"{key} = {exception.Data[key]}");
            }
        }

        /// <summary>
        /// Logs the self logging.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        private static void LogSelfLogging(ILogger logger, Exception exception)
        {
            var loggingExceptions = new List<IExceptionWithSelfLogging>();

            if (exception is IExceptionWithSelfLogging)
            {
                loggingExceptions.Add(exception as IExceptionWithSelfLogging);
            }
            else if (exception is AggregateException && exception.InnerException != null)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerException is IExceptionWithSelfLogging)
                {
                    loggingExceptions.Add(aggException.InnerException as IExceptionWithSelfLogging);
                }

                foreach (var innerException in aggException.InnerExceptions)
                {
                    if (innerException is IExceptionWithSelfLogging)
                    {
                        loggingExceptions.AddIfNotContains(innerException as IExceptionWithSelfLogging);
                    }
                }
            }

            foreach (var ex in loggingExceptions)
            {
                ex.Log(logger);
            }
        }
    }
}
