// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="TestBaseWithServiceProvider.cs" company="Noob.NUnitTests">
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
    /// Class TestBaseWithServiceProvider.
    /// </summary>
    public abstract class TestBaseWithServiceProvider
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        protected IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        protected virtual T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        /// <summary>
        /// Gets the required service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        protected virtual T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
