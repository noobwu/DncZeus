// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IUnitOfWorkAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Interface IUnitOfWorkAccessor
    /// </summary>
    public interface IUnitOfWorkAccessor
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        [CanBeNull]
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Sets the unit of work.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        void SetUnitOfWork([CanBeNull] IUnitOfWork unitOfWork);
    }
}