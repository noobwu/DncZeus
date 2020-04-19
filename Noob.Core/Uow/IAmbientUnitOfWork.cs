// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IAmbientUnitOfWork.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Uow
{
    /// <summary>
    /// Interface IAmbientUnitOfWork
    /// Implements the <see cref="Noob.Uow.IUnitOfWorkAccessor" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IUnitOfWorkAccessor" />
    public interface IAmbientUnitOfWork : IUnitOfWorkAccessor
    {

    }
}