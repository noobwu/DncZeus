// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="CurrentUser.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Noob.DependencyInjection;

namespace Noob.Users
{
    /// <summary>
    /// Class CurrentUser.
    /// Implements the <see cref="Noob.Users.ICurrentUser" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Users.ICurrentUser" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class CurrentUser : ICurrentUser, ITransientDependency
    {
        /// <summary>
        /// The empty claims array
        /// </summary>
        private static readonly Claim[] EmptyClaimsArray = new Claim[0];

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        public virtual bool IsAuthenticated => Id.HasValue;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual Guid? Id => _principalAccessor.Principal?.FindUserId();

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public virtual string UserName => this.FindClaimValue(ClaimTypes.Name);

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual string[] Roles => FindClaims(ClaimTypes.Role).Select(c => c.Value).ToArray();

        /// <summary>
        /// The principal accessor
        /// </summary>
        private readonly Security.Claims.ICurrentPrincipalAccessor _principalAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUser"/> class.
        /// </summary>
        /// <param name="principalAccessor">The principal accessor.</param>
        public CurrentUser(Security.Claims.ICurrentPrincipalAccessor principalAccessor)
        {
            _principalAccessor = principalAccessor;
        }

        /// <summary>
        /// Finds the claim.
        /// </summary>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>Claim.</returns>
        public virtual Claim FindClaim(string claimType)
        {
            return _principalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == claimType);
        }

        /// <summary>
        /// Finds the claims.
        /// </summary>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns>Claim[].</returns>
        public virtual Claim[] FindClaims(string claimType)
        {
            return _principalAccessor.Principal?.Claims.Where(c => c.Type == claimType).ToArray() ?? EmptyClaimsArray;
        }

        /// <summary>
        /// Gets all claims.
        /// </summary>
        /// <returns>Claim[].</returns>
        public virtual Claim[] GetAllClaims()
        {
            return _principalAccessor.Principal?.Claims.ToArray() ?? EmptyClaimsArray;
        }

        /// <summary>
        /// Determines whether [is in role] [the specified role name].
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if [is in role] [the specified role name]; otherwise, <c>false</c>.</returns>
        public virtual bool IsInRole(string roleName)
        {
            return FindClaims(ClaimTypes.Role).Any(c => c.Value == roleName);
        }
    }
}