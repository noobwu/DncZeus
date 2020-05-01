// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="IHasLogLevel.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;

namespace Noob.Logging
{
    /// <summary>
    /// Interface to define a <see cref="LogLevel" /> property (see <see cref="LogLevel" />).
    /// </summary>
    public interface IHasLogLevel
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        /// <value>The log level.</value>
        LogLevel LogLevel { get; set; }
    }
}