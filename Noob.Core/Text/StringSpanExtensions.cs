// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="StringSpanExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.Text
{
    /// <summary>
    /// Helpful extensions on ReadOnlySpan&lt;char&gt;
    /// Previous extensions on StringSegment available from: https://gist.github.com/mythz/9825689f0db7464d1d541cb62954614c
    /// </summary>
    public static class StringSpanExtensions
    {
        /// <summary>
        /// Withouts the bom.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ReadOnlySpan&lt;System.Char&gt;.</returns>
        public static ReadOnlySpan<char> WithoutBom(this ReadOnlySpan<char> value)
        {
            return value.Length > 0 && value[0] == 65279
                ? value.Slice(1)
                : value;
        }

        /// <summary>
        /// Withouts the bom.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ReadOnlySpan&lt;System.Byte&gt;.</returns>
        public static ReadOnlySpan<byte> WithoutBom(this ReadOnlySpan<byte> value)
        {
            return value.Length > 3 && value[0] == 0xEF && value[1] == 0xBB && value[2] == 0xBF
                ? value.Slice(3)
                : value;
        }
    }
}
