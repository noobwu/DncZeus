// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="ValidationHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;

namespace Noob.Validators
{
    /// <summary>
    /// Class ValidationHelper.
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// The email reg ex
        /// </summary>
        private const string EmailRegEx = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        /// <summary>
        /// Determines whether [is valid email address] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is valid email address] [the specified email]; otherwise, <c>false</c>.</returns>
        public static bool IsValidEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            /*RFC 2822 (simplified)*/
            return Regex.IsMatch(email, EmailRegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}