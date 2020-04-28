// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="InternalUtils.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// Class InternalUtils.
    /// </summary>
    internal static class InternalUtils
    {
        /// <summary>
        /// Adds the counter.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        internal static string AddCounter(string str)
        {
            if (str.Contains("__"))
            {
                var splitted = str.Split("__");
                if (splitted.Length == 2)
                {
                    if (int.TryParse(splitted[1], out var num))
                    {
                        return splitted[0] + "__" + (++num);
                    }
                }
            }

            return str + "__2";
        }
    }
}
