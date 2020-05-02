// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="EntityFrameworkCoreMySQLModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Modularity;

namespace Noob.EntityFrameworkCore.MySQL
{
    /// <summary>
    /// Class EntityFrameworkCoreMySQLModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(typeof(EntityFrameworkCoreModule))]
    public class EntityFrameworkCoreMySQLModule : Module
    {

    }
}
