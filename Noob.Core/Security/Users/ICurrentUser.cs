// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="ICurrentUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Claims;
using JetBrains.Annotations;

namespace Noob.Users
{
    /// <summary>
    /// Interface ICurrentUser
    /// </summary>
    public interface ICurrentUser
    {
        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [CanBeNull]
        Guid? Id { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [CanBeNull]
        string UserName { get; }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [NotNull]
        string[] Roles { get; }

        /// <summary>
        /// Finds the claim.
        /// </summary>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>Claim.</returns>
        [CanBeNull]
        Claim FindClaim(string claimType);

        /// <summary>
        /// Finds the claims.
        /// </summary>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>Claim[].</returns>
        [NotNull]
        Claim[] FindClaims(string claimType);

        /// <summary>
        /// Gets all claims.
        /// </summary>
        /// <returns>Claim[].</returns>
        [NotNull]
        Claim[] GetAllClaims();

        /// <summary>
        /// Determines whether [is in role] [the specified role name].
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if [is in role] [the specified role name]; otherwise, <c>false</c>.</returns>
        bool IsInRole(string roleName);
    }
}
