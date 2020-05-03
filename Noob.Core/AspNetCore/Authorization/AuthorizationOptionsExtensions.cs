// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="AuthorizationOptionsExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Class AuthorizationOptionsExtensions.
    /// </summary>
    public static class AuthorizationOptionsExtensions
    {
        /// <summary>
        /// The policy map property
        /// </summary>
        private static readonly PropertyInfo PolicyMapProperty = typeof(AuthorizationOptions)
            .GetProperty("PolicyMap", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// Gets all policies.
        /// IMPORTANT NOTE: Use this method carefully.
        /// It relies on reflection to get all policies from a private field of the <see cref="options" />.
        /// This method may be removed in the future if internals of <see cref="AuthorizationOptions" /> changes.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetPoliciesNames(this AuthorizationOptions options)
        {
            return ((IDictionary<string, AuthorizationPolicy>) PolicyMapProperty.GetValue(options)).Keys.ToList();
        }
    }
}