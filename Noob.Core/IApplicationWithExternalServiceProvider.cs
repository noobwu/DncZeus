// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IApplicationWithExternalServiceProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob
{
    /// <summary>
    /// Interface IApplicationWithExternalServiceProvider
    /// Implements the <see cref="Noob.IApplication" />
    /// </summary>
    /// <seealso cref="Noob.IApplication" />
    public interface IApplicationWithExternalServiceProvider : IApplication
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        void Initialize([NotNull] IServiceProvider serviceProvider);
    }
}