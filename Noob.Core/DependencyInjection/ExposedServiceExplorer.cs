// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ExposedServiceExplorer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ExposedServiceExplorer.
    /// </summary>
    public static class ExposedServiceExplorer
    {
        /// <summary>
        /// The default expose services attribute
        /// </summary>
        private static readonly ExposeServicesAttribute DefaultExposeServicesAttribute =
            new ExposeServicesAttribute
            {
                IncludeDefaults = true,
                IncludeSelf = true
            };

        /// <summary>
        /// Gets the exposed services.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>List&lt;Type&gt;.</returns>
        public static List<Type> GetExposedServices(Type type)
        {
            return type
                .GetCustomAttributes(true)
                .OfType<IExposedServiceTypesProvider>()
                .DefaultIfEmpty(DefaultExposeServicesAttribute)
                .SelectMany(p => p.GetExposedServiceTypes(type))
                .Distinct()
                .ToList();
        }
    }
}
