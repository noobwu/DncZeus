// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IExposedServiceTypesProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IExposedServiceTypesProvider
    /// </summary>
    public interface IExposedServiceTypesProvider
    {
        /// <summary>
        /// Gets the exposed service types.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>Type[].</returns>
        Type[] GetExposedServiceTypes(Type targetType);
    }
}
