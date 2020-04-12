// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="ITracer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Text
{
    /// <summary>
    /// Interface ITracer
    /// </summary>
    public interface ITracer
    {
        /// <summary>
        /// Writes the debug.
        /// </summary>
        /// <param name="error">The error.</param>
        void WriteDebug(string error);
        /// <summary>
        /// Writes the debug.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void WriteDebug(string format, params object[] args);
        /// <summary>
        /// Writes the warning.
        /// </summary>
        /// <param name="warning">The warning.</param>
        void WriteWarning(string warning);
        /// <summary>
        /// Writes the warning.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void WriteWarning(string format, params object[] args);

        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        void WriteError(Exception ex);
        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <param name="error">The error.</param>
        void WriteError(string error);
        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void WriteError(string format, params object[] args);
    }
}