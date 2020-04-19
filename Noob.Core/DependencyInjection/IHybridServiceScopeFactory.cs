// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IHybridServiceScopeFactory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IHybridServiceScopeFactory
    /// Implements the <see cref="Microsoft.Extensions.DependencyInjection.IServiceScopeFactory" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.DependencyInjection.IServiceScopeFactory" />
    public interface IHybridServiceScopeFactory : IServiceScopeFactory
    {

    }
}