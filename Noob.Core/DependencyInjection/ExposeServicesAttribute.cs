// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ExposeServicesAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ExposeServicesAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// Implements the <see cref="Noob.DependencyInjection.IExposedServiceTypesProvider" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Noob.DependencyInjection.IExposedServiceTypesProvider" />
    public class ExposeServicesAttribute : Attribute, IExposedServiceTypesProvider
    {
        /// <summary>
        /// Gets the service types.
        /// </summary>
        /// <value>The service types.</value>
        public Type[] ServiceTypes { get; }

        /// <summary>
        /// Gets or sets a value indicating whether [include defaults].
        /// </summary>
        /// <value><c>true</c> if [include defaults]; otherwise, <c>false</c>.</value>
        public bool IncludeDefaults { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [include self].
        /// </summary>
        /// <value><c>true</c> if [include self]; otherwise, <c>false</c>.</value>
        public bool IncludeSelf { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeServicesAttribute"/> class.
        /// </summary>
        /// <param name="serviceTypes">The service types.</param>
        public ExposeServicesAttribute(params Type[] serviceTypes)
        {
            ServiceTypes = serviceTypes ?? new Type[0];
        }

        /// <summary>
        /// Gets the exposed service types.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>Type[].</returns>
        public Type[] GetExposedServiceTypes(Type targetType)
        {
            var serviceList = ServiceTypes.ToList();

            if (IncludeDefaults)
            {
                foreach (var type in GetDefaultServices(targetType))
                {
                    serviceList.AddIfNotContains(type);
                }

                if (IncludeSelf)
                {
                    serviceList.AddIfNotContains(targetType);
                }
            }
            else if (IncludeSelf)
            {
                serviceList.AddIfNotContains(targetType);
            }

            return serviceList.ToArray();
        }

        /// <summary>
        /// Gets the default services.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>List&lt;Type&gt;.</returns>
        private static List<Type> GetDefaultServices(Type type)
        {
            var serviceTypes = new List<Type>();

            foreach (var interfaceType in type.GetTypeInfo().GetInterfaces())
            {
                var interfaceName = interfaceType.Name;

                if (interfaceName.StartsWith("I"))
                {
                    interfaceName = interfaceName.Right(interfaceName.Length - 1);
                }

                if (type.Name.EndsWith(interfaceName))
                {
                    serviceTypes.Add(interfaceType);
                }
            }

            return serviceTypes;
        }
    }
}