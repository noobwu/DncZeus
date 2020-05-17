// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="IExceptionSubscriber.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Noob.ExceptionHandling
{
    /// <summary>
    /// Interface IExceptionSubscriber
    /// </summary>
    public interface IExceptionSubscriber
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        Task HandleAsync([NotNull] ExceptionNotificationContext context);
    }
}
