// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="IExceptionWithSelfLogging.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;

namespace Noob.Logging
{
    /// <summary>
    /// Interface IExceptionWithSelfLogging
    /// </summary>
    public interface IExceptionWithSelfLogging
    {
        /// <summary>
        /// Logs the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        void Log(ILogger logger);
    }
}