// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="OnServiceExposingArgs.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class OnServiceExposingContext.
    /// Implements the <see cref="Noob.DependencyInjection.IOnServiceExposingContext" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IOnServiceExposingContext" />
    public class OnServiceExposingContext : IOnServiceExposingContext
    {
        /// <summary>
        /// Gets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        public Type ImplementationType { get; }

        /// <summary>
        /// Gets the exposed types.
        /// </summary>
        /// <value>The exposed types.</value>
        public List<Type> ExposedTypes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnServiceExposingContext"/> class.
        /// </summary>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <param name="exposedTypes">The exposed types.</param>
        public OnServiceExposingContext([NotNull] Type implementationType, List<Type> exposedTypes)
        {
            ImplementationType = Check.NotNull(implementationType, nameof(implementationType));
            ExposedTypes = Check.NotNull(exposedTypes, nameof(exposedTypes));
        }
    }
}