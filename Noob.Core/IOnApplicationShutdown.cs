// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IOnApplicationShutdown.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob
{
    /// <summary>
    /// Interface IOnApplicationShutdown
    /// </summary>
    public interface IOnApplicationShutdown
    {
        /// <summary>
        /// Called when [application shutdown].
        /// </summary>
        /// <param name="context">The context.</param>
        void OnApplicationShutdown([NotNull] ApplicationShutdownContext context);
    }
}