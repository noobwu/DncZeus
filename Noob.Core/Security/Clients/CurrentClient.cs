// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="CurrentClient.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Security.Principal;
using Noob.DependencyInjection;
using Noob.Security.Claims;

namespace Noob.Clients
{
    /// <summary>
    /// Class CurrentClient.
    /// Implements the <see cref="Noob.Clients.ICurrentClient" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Clients.ICurrentClient" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class CurrentClient : ICurrentClient, ITransientDependency
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual string Id => _principalAccessor.Principal?.FindClientId();

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        public virtual bool IsAuthenticated => Id != null;

        /// <summary>
        /// The principal accessor
        /// </summary>
        private readonly ICurrentPrincipalAccessor _principalAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentClient"/> class.
        /// </summary>
        /// <param name="principalAccessor">The principal accessor.</param>
        public CurrentClient(ICurrentPrincipalAccessor principalAccessor)
        {
            _principalAccessor = principalAccessor;
        }
    }
}
