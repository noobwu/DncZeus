// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="DefaultCorrelationIdProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.DependencyInjection;

namespace Noob.Tracing
{
    /// <summary>
    /// Class DefaultCorrelationIdProvider.
    /// Implements the <see cref="Noob.Tracing.ICorrelationIdProvider" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Tracing.ICorrelationIdProvider" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class DefaultCorrelationIdProvider : ICorrelationIdProvider, ISingletonDependency
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Get()
        {
            return CreateNewCorrelationId();
        }

        /// <summary>
        /// Creates the new correlation identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        protected virtual string CreateNewCorrelationId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}