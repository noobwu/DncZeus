// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IPreConfigureServices.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IPreConfigureServices
    /// </summary>
    public interface IPreConfigureServices
    {
        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        void PreConfigureServices(ServiceConfigurationContext context);
    }
}
