// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="IAuthorizationService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Security.Claims;
using Noob.DependencyInjection;

namespace Noob.Authorization
{
    /// <summary>
    /// Interface IAuthorizationService
    /// Implements the <see cref="Microsoft.AspNetCore.Authorization.IAuthorizationService" />
    /// Implements the <see cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authorization.IAuthorizationService" />
    /// <seealso cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    public interface IAuthorizationServiceExt : Microsoft.AspNetCore.Authorization.IAuthorizationService, IServiceProviderAccessor
    {
        /// <summary>
        /// Gets the current principal.
        /// </summary>
        /// <value>The current principal.</value>
        ClaimsPrincipal CurrentPrincipal { get; }
    }
}