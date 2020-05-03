// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="AuthorizationServiceExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noob.Authorization;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Class AuthorizationServiceExtensions.
    /// </summary>
    public static class AuthorizationServiceExtensions
    {
        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, string policyName)
        {
            return await AuthorizeAsync(
                authorizationService,
                null,
                policyName
            );
        }

        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirement">The requirement.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, object resource, IAuthorizationRequirement requirement)
        {
            return await authorizationService.AuthorizeAsync(
                authorizationService.AsAuthorizationServiceExt().CurrentPrincipal,
                resource,
                requirement
            );
        }

        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, object resource, AuthorizationPolicy policy)
        {
            return await authorizationService.AuthorizeAsync(
                authorizationService.AsAuthorizationServiceExt().CurrentPrincipal,
                resource,
                policy
            );
        }

        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, AuthorizationPolicy policy)
        {
            return await AuthorizeAsync(
                authorizationService,
                null,
                policy
            );
        }

        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirements">The requirements.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            return await authorizationService.AuthorizeAsync(
                authorizationService.AsAuthorizationServiceExt().CurrentPrincipal,
                resource,
                requirements
            );
        }

        /// <summary>
        /// authorize as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task&lt;AuthorizationResult&gt;.</returns>
        public static async Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService authorizationService, object resource, string policyName)
        {
            return await authorizationService.AuthorizeAsync(
                authorizationService.AsAuthorizationServiceExt().CurrentPrincipal,
                resource,
                policyName
            );
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, string policyName)
        {
            return (await authorizationService.AuthorizeAsync(policyName)).Succeeded;
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirement">The requirement.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, object resource, IAuthorizationRequirement requirement)
        {
            return (await authorizationService.AuthorizeAsync(resource, requirement)).Succeeded;
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, object resource, AuthorizationPolicy policy)
        {
            return (await authorizationService.AuthorizeAsync(resource, policy)).Succeeded;
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, AuthorizationPolicy policy)
        {
            return (await authorizationService.AuthorizeAsync(policy)).Succeeded;
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirements">The requirements.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            return (await authorizationService.AuthorizeAsync(resource, requirements)).Succeeded;
        }

        /// <summary>
        /// is granted as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> IsGrantedAsync(this IAuthorizationService authorizationService, object resource, string policyName)
        {
            return (await authorizationService.AuthorizeAsync(resource, policyName)).Succeeded;
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given policy has not granted: " + policyName</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, string policyName)
        {
            if (!await authorizationService.IsGrantedAsync(policyName))
            {
                throw new AuthorizationException("Authorization failed! Given policy has not granted: " + policyName);
            }
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirement">The requirement.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given requirement has not granted for given resource: " + resource</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, object resource, IAuthorizationRequirement requirement)
        {
            if (!await authorizationService.IsGrantedAsync(resource, requirement))
            {
                throw new AuthorizationException("Authorization failed! Given requirement has not granted for given resource: " + resource);
            }
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given policy has not granted for given resource: " + resource</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, object resource, AuthorizationPolicy policy)
        {
            if (!await authorizationService.IsGrantedAsync(resource, policy))
            {
                throw new AuthorizationException("Authorization failed! Given policy has not granted for given resource: " + resource);
            }
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given policy has not granted.</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, AuthorizationPolicy policy)
        {
            if (!await authorizationService.IsGrantedAsync(policy))
            {
                throw new AuthorizationException("Authorization failed! Given policy has not granted.");
            }
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="requirements">The requirements.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given requirements have not granted for given resource: " + resource</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            if (!await authorizationService.IsGrantedAsync(resource, requirements))
            {
                throw new AuthorizationException("Authorization failed! Given requirements have not granted for given resource: " + resource);
            }
        }

        /// <summary>
        /// check as an asynchronous operation.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Noob.Authorization.AuthorizationException">Authorization failed! Given polist has not granted for given resource: " + resource</exception>
        public static async Task CheckAsync(this IAuthorizationService authorizationService, object resource, string policyName)
        {
            if (!await authorizationService.IsGrantedAsync(resource, policyName))
            {
                throw new AuthorizationException("Authorization failed! Given polist has not granted for given resource: " + resource);
            }
        }

        /// <summary>
        /// Ases the authorization service ext.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <returns>IAuthorizationServiceExt.</returns>
        /// <exception cref="Exception"></exception>
        private static IAuthorizationServiceExt AsAuthorizationServiceExt(this IAuthorizationService authorizationService)
        {
            if (!(authorizationService is IAuthorizationServiceExt abpAuthorizationService))
            {
                throw new Exception($"{nameof(authorizationService)} should implement {typeof(IAuthorizationServiceExt).FullName}");
            }

            return abpAuthorizationService;
        }
    }
}