// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="IAuditLogSaveHandle.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IAuditLogSaveHandle
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IAuditLogSaveHandle : IDisposable
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task SaveAsync();
    }
}