// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="ICorrelationIdProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Tracing
{
    /// <summary>
    /// Interface ICorrelationIdProvider
    /// </summary>
    public interface ICorrelationIdProvider
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        [NotNull]
        string Get();
    }
}
