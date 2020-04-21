// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ICancellationTokenProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;

namespace Noob.Threading
{
    /// <summary>
    /// Interface ICancellationTokenProvider
    /// </summary>
    public interface ICancellationTokenProvider
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>The token.</value>
        CancellationToken Token { get; }
    }
}
