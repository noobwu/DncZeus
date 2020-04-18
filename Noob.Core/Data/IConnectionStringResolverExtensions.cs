// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IConnectionStringResolverExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Data
{
    /// <summary>
    /// Class ConnectionStringResolverExtensions.
    /// </summary>
    public static class ConnectionStringResolverExtensions
    {
        /// <summary>
        /// Resolves the specified resolver.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resolver">The resolver.</param>
        /// <returns>System.String.</returns>
        public static string Resolve<T>(this IConnectionStringResolver resolver)
        {
            return resolver.Resolve(ConnectionStringNameAttribute.GetConnStringName<T>());
        }
    }
}
