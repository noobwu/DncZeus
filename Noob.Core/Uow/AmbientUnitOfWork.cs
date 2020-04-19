// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AmbientUnitOfWork.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;
using Noob.DependencyInjection;

namespace Noob.Uow
{
    /// <summary>
    /// Class AmbientUnitOfWork.
    /// Implements the <see cref="Noob.Uow.IAmbientUnitOfWork" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IAmbientUnitOfWork" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    [ExposeServices(typeof(IAmbientUnitOfWork), typeof(IUnitOfWorkAccessor))]
    public class AmbientUnitOfWork : IAmbientUnitOfWork, ISingletonDependency
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork UnitOfWork => _currentUow.Value;

        /// <summary>
        /// The current uow
        /// </summary>
        private readonly AsyncLocal<IUnitOfWork> _currentUow;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmbientUnitOfWork"/> class.
        /// </summary>
        public AmbientUnitOfWork()
        {
            _currentUow = new AsyncLocal<IUnitOfWork>();
        }

        /// <summary>
        /// Sets the unit of work.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            _currentUow.Value = unitOfWork;
        }
    }
}