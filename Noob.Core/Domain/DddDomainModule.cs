// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="DddDomainModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Data;
using Noob.Guids;
using Noob.Modularity;
using Noob.Threading;
using Noob.Uow;

namespace Noob.Domain
{
    /// <summary>
    /// Class DddDomainModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(typeof(GuidsModule),typeof(ThreadingModule),typeof(UnitOfWorkModule))]
    public class DddDomainModule : Module
    {

    }
}
