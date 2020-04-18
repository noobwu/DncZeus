// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="CancellationTokenProviderExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;

namespace Noob.Threading
{
    /// <summary>
    /// Class CancellationTokenProviderExtensions.
    /// </summary>
    public static class CancellationTokenProviderExtensions
    {
        /// <summary>
        /// Fallbacks to provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="prefferedValue">The preffered value.</param>
        /// <returns>CancellationToken.</returns>
        public static CancellationToken FallbackToProvider(this ICancellationTokenProvider provider, CancellationToken prefferedValue = default)
        {
            return prefferedValue == default || prefferedValue == CancellationToken.None
                ? provider.Token
                : prefferedValue;
        }
    }
}