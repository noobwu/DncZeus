// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IEntityWithIntPkRepository.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noob.Domain.Repositories;

namespace Noob.TestApp.Domain
{

    /// <summary>
    /// Interface IEntityWithIntPkRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.EntityWithIntPk, System.Int32}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.EntityWithIntPk, System.Int32}" />
    public interface IEntityWithIntPkRepository : IBasicRepository<EntityWithIntPk, int>
    {

    }
}
