// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IntegratedTest.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace Noob
{
    /// <summary>
    /// Class IntegratedTest.
    /// Implements the <see cref="Noob.TestBaseWithServiceProvider" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
    /// <seealso cref="Noob.TestBaseWithServiceProvider" />
    /// <seealso cref="System.IDisposable" />
    public abstract class IntegratedTest<TStartupModule> : TestBaseWithServiceProvider, IDisposable
       where TStartupModule : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegratedTest{TStartupModule}" /> class.
        /// </summary>
        protected IntegratedTest()
        {
          
        }
        protected virtual IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            return services.BuildServiceProviderFromFactory();
        }
        /// <summary>
        /// Creates the service collection.
        /// </summary>
        /// <returns>IServiceCollection.</returns>
        protected virtual IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
  
        }
    }
}
