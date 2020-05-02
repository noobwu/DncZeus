// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EntityFrameworkCoreSqlServerModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Modularity;

namespace Noob.EntityFrameworkCore.SqlServer
{
    /// <summary>
    /// Class EntityFrameworkCoreSqlServerModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(
        typeof(EntityFrameworkCoreModule)
        )]
    public class EntityFrameworkCoreSqlServerModule : Module
    {

    }
}
