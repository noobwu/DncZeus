// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="StringBuilderPool.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Text.Pools
{
    // Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

    using System.Text;

    /// <summary>
    /// Class StringBuilderPool.
    /// </summary>
    public static class StringBuilderPool
    {
        /// <summary>
        /// Allocates this instance.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Allocate()
        {
            return SharedPools.Default<StringBuilder>().AllocateAndClear();
        }

        /// <summary>
        /// Frees the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Free(StringBuilder builder)
        {
            SharedPools.Default<StringBuilder>().ClearAndFree(builder);
        }

        /// <summary>
        /// Returns the and free.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>System.String.</returns>
        public static string ReturnAndFree(StringBuilder builder)
        {
            SharedPools.Default<StringBuilder>().ForgetTrackedObject(builder);
            return builder.ToString();
        }
    }
}