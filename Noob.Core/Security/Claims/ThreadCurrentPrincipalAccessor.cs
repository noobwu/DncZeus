// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="ThreadCurrentPrincipalAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Security.Claims;
using System.Threading;
using Noob.DependencyInjection;

namespace Noob.Security.Claims
{
    /// <summary>
    /// Class ThreadCurrentPrincipalAccessor.
    /// Implements the <see cref="Noob.Security.Claims.ICurrentPrincipalAccessor" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Security.Claims.ICurrentPrincipalAccessor" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class ThreadCurrentPrincipalAccessor : ICurrentPrincipalAccessor, ISingletonDependency
    {
        /// <summary>
        /// Gets the principal.
        /// </summary>
        /// <value>The principal.</value>
        public virtual ClaimsPrincipal Principal => Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}