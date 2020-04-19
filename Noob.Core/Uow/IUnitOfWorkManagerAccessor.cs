// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IUnitOfWorkManagerAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Uow
{
    /// <summary>
    /// Interface IUnitOfWorkManagerAccessor
    /// </summary>
    public interface IUnitOfWorkManagerAccessor
    {
        /// <summary>
        /// Gets the unit of work manager.
        /// </summary>
        /// <value>The unit of work manager.</value>
        IUnitOfWorkManager UnitOfWorkManager { get; }
    }
}
