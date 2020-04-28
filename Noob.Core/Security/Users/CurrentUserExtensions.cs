// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="CurrentUserExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Noob.Users
{
    /// <summary>
    /// Class CurrentUserExtensions.
    /// </summary>
    public static class CurrentUserExtensions
    {
        /// <summary>
        /// Finds the claim value.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>System.String.</returns>
        [CanBeNull]
        public static string FindClaimValue(this ICurrentUser currentUser, string claimType)
        {
            return currentUser.FindClaim(claimType)?.Value;
        }

        /// <summary>
        /// Finds the claim value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentUser">The current user.</param>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>T.</returns>
        public static T FindClaimValue<T>(this ICurrentUser currentUser, string claimType)
            where T : struct
        {
            var value = currentUser.FindClaimValue(claimType);
            if (value == null)
            {
                return default;
            }

            return value.To<T>();
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>Guid.</returns>
        public static Guid GetId(this ICurrentUser currentUser)
        {
            Debug.Assert(currentUser.Id != null, "currentUser.Id != null");

            return currentUser.Id.Value;
        }
    }
}