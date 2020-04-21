// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="IRunnable.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;
using System.Threading.Tasks;

namespace Noob.Threading
{
    /// <summary>
    /// Interface to start/stop self threaded services.
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Starts the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task StopAsync(CancellationToken cancellationToken = default);
    }
}
