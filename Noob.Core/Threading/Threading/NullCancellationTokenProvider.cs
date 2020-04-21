// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="NullCancellationTokenProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;

namespace Noob.Threading
{
    /// <summary>
    /// Class NullCancellationTokenProvider.
    /// Implements the <see cref="Noob.Threading.ICancellationTokenProvider" />
    /// </summary>
    /// <seealso cref="Noob.Threading.ICancellationTokenProvider" />
    public class NullCancellationTokenProvider : ICancellationTokenProvider
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static NullCancellationTokenProvider Instance { get; } = new NullCancellationTokenProvider();

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>The token.</value>
        public CancellationToken Token { get; } = CancellationToken.None;

        /// <summary>
        /// Prevents a default instance of the <see cref="NullCancellationTokenProvider"/> class from being created.
        /// </summary>
        private NullCancellationTokenProvider()
        {
            
        }
    }
}