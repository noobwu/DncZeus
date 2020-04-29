// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="ClaimsIdentityExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Security.Claims;
using JetBrains.Annotations;
using Noob;
namespace System.Security.Principal
{
    /// <summary>
    /// Class ClaimsIdentityExtensions.
    /// </summary>
    public static class ClaimsIdentityExtensions
    {
        /// <summary>
        /// Finds the user identifier.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <returns>System.Nullable&lt;Guid&gt;.</returns>
        public static Guid? FindUserId([NotNull] this ClaimsPrincipal principal)
        {
            Check.NotNull(principal, nameof(principal));

            var userIdOrNull = principal.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrWhiteSpace())
            {
                return null;
            }
            if (Guid.TryParse(userIdOrNull.Value, out Guid result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Finds the user identifier.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>System.Nullable&lt;Guid&gt;.</returns>
        public static Guid? FindUserId([NotNull] this IIdentity identity)
        {
            Check.NotNull(identity, nameof(identity));

            var claimsIdentity = identity as ClaimsIdentity;

            var userIdOrNull = claimsIdentity?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return Guid.Parse(userIdOrNull.Value);
        }

        /// <summary>
        /// Finds the client identifier.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <returns>System.String.</returns>
        public static string FindClientId([NotNull] this ClaimsPrincipal principal)
        {
            Check.NotNull(principal, nameof(principal));

            var clientIdOrNull = principal.Claims?.FirstOrDefault(c => c.Type == Noob.Security.Claims.ClaimTypes.ClientId);
            if (clientIdOrNull == null || clientIdOrNull.Value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return clientIdOrNull.Value;
        }

        /// <summary>
        /// Finds the client identifier.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>System.String.</returns>
        public static string FindClientId([NotNull] this IIdentity identity)
        {
            Check.NotNull(identity, nameof(identity));

            var claimsIdentity = identity as ClaimsIdentity;

            var clientIdOrNull = claimsIdentity?.Claims?.FirstOrDefault(c => c.Type == Noob.Security.Claims.ClaimTypes.ClientId);
            if (clientIdOrNull == null || clientIdOrNull.Value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return clientIdOrNull.Value;
        }

    }
}
