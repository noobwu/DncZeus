// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="ICurrentPrincipalAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Security.Claims;

namespace Noob.Security.Claims
{
    /// <summary>
    /// Interface ICurrentPrincipalAccessor
    /// </summary>
    public interface ICurrentPrincipalAccessor
    {
        /// <summary>
        /// Gets the principal.
        /// </summary>
        /// <value>The principal.</value>
        ClaimsPrincipal Principal { get; }
    }
}
