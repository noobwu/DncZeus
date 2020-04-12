// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-08-30
// ***********************************************************************
// <copyright file="StringBuilderCache.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;

namespace Noob.Text
{
    /// <summary>
    /// Reusable StringBuilder ThreadStatic Cache
    /// </summary>
    public static class StringBuilderCache
    {
        /// <summary>
        /// The cache
        /// </summary>
        [ThreadStatic]
        static StringBuilder cache;

        /// <summary>
        /// Allocates this instance.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Allocate()
        {
            var ret = cache;
            if (ret == null)
                return new StringBuilder();

            ret.Length = 0;
            cache = null;  //don't re-issue cached instance until it's freed
            return ret;
        }

        /// <summary>
        /// Frees the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        public static void Free(StringBuilder sb)
        {
            cache = sb;
        }

        /// <summary>
        /// Returns the and free.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>System.String.</returns>
        public static string ReturnAndFree(StringBuilder sb)
        {
            var ret = sb.ToString();
            cache = sb;
            return ret;
        }
    }

    /// <summary>
    /// Alternative Reusable StringBuilder ThreadStatic Cache
    /// </summary>
    public static class StringBuilderCacheAlt
    {
        /// <summary>
        /// The cache
        /// </summary>
        [ThreadStatic]
        static StringBuilder cache;

        /// <summary>
        /// Allocates this instance.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Allocate()
        {
            var ret = cache;
            if (ret == null)
                return new StringBuilder();

            ret.Length = 0;
            cache = null;  //don't re-issue cached instance until it's freed
            return ret;
        }

        /// <summary>
        /// Frees the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        public static void Free(StringBuilder sb)
        {
            cache = sb;
        }

        /// <summary>
        /// Returns the and free.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>System.String.</returns>
        public static string ReturnAndFree(StringBuilder sb)
        {
            var ret = sb.ToString();
            cache = sb;
            return ret;
        }
    }

    //Use separate cache internally to avoid re-allocations and cache misses
    /// <summary>
    /// Class StringBuilderThreadStatic.
    /// </summary>
    internal static class StringBuilderThreadStatic
    {
        /// <summary>
        /// The cache
        /// </summary>
        [ThreadStatic]
        static StringBuilder cache;

        /// <summary>
        /// Allocates this instance.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Allocate()
        {
            var ret = cache;
            if (ret == null)
                return new StringBuilder();

            ret.Length = 0;
            cache = null;  //don't re-issue cached instance until it's freed
            return ret;
        }

        /// <summary>
        /// Frees the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        public static void Free(StringBuilder sb)
        {
            cache = sb;
        }

        /// <summary>
        /// Returns the and free.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>System.String.</returns>
        public static string ReturnAndFree(StringBuilder sb)
        {
            var ret = sb.ToString();
            cache = sb;
            return ret;
        }
    }
}