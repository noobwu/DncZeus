// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationShutdownContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob
{
    /// <summary>
    /// Class ApplicationShutdownContext.
    /// </summary>
    public class ApplicationShutdownContext
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationShutdownContext"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ApplicationShutdownContext([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}