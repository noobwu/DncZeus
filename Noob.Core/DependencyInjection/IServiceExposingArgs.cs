// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IServiceExposingArgs.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IOnServiceExposingContext
    /// </summary>
    public interface IOnServiceExposingContext
    {
        /// <summary>
        /// Gets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        Type ImplementationType { get; }

        /// <summary>
        /// Gets the exposed types.
        /// </summary>
        /// <value>The exposed types.</value>
        List<Type> ExposedTypes { get; }
    }
}