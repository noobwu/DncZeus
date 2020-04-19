// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DefaultServiceScopeFactory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class DefaultServiceScopeFactory.
    /// Implements the <see cref="Noob.DependencyInjection.IHybridServiceScopeFactory" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IHybridServiceScopeFactory" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    [ExposeServices(typeof(IHybridServiceScopeFactory),typeof(DefaultServiceScopeFactory))]
    public class DefaultServiceScopeFactory : IHybridServiceScopeFactory, ITransientDependency
    {
        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <value>The factory.</value>
        protected IServiceScopeFactory Factory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceScopeFactory"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public DefaultServiceScopeFactory(IServiceScopeFactory factory)
        {
            Factory = factory;
        }

        /// <summary>
        /// Creates the scope.
        /// </summary>
        /// <returns>IServiceScope.</returns>
        public IServiceScope CreateScope()
        {
            return Factory.CreateScope();
        }
    }
}