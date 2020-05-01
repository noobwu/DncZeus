// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AutofacModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Castle;
using Noob.Modularity;

namespace Noob.Autofac
{
    /// <summary>
    /// Class AutofacModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(typeof(CastleCoreModule))]
    public class AutofacModule :Module
    {

    }
}
