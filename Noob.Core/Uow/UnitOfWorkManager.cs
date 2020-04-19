// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkManager.
    /// Implements the <see cref="Noob.Uow.IUnitOfWorkManager" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IUnitOfWorkManager" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class UnitOfWorkManager : IUnitOfWorkManager, ISingletonDependency
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public IUnitOfWork Current => GetCurrentUnitOfWork();

        /// <summary>
        /// The service scope factory
        /// </summary>
        private readonly IHybridServiceScopeFactory _serviceScopeFactory;
        /// <summary>
        /// The ambient unit of work
        /// </summary>
        private readonly IAmbientUnitOfWork _ambientUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkManager"/> class.
        /// </summary>
        /// <param name="ambientUnitOfWork">The ambient unit of work.</param>
        /// <param name="serviceScopeFactory">The service scope factory.</param>
        public UnitOfWorkManager(
            IAmbientUnitOfWork ambientUnitOfWork,
            IHybridServiceScopeFactory serviceScopeFactory)
        {
            _ambientUnitOfWork = ambientUnitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Begins the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requiresNew">if set to <c>true</c> [requires new].</param>
        /// <returns>IUnitOfWork.</returns>
        public IUnitOfWork Begin(UnitOfWorkOptions options, bool requiresNew = false)
        {
            Check.NotNull(options, nameof(options));

            var currentUow = Current;
            if (currentUow != null && !requiresNew)
            {
                return new ChildUnitOfWork(currentUow);
            }

            var unitOfWork = CreateNewUnitOfWork();
            unitOfWork.Initialize(options);

            return unitOfWork;
        }

        /// <summary>
        /// Reserves the specified reservation name.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="requiresNew">if set to <c>true</c> [requires new].</param>
        /// <returns>IUnitOfWork.</returns>
        public IUnitOfWork Reserve(string reservationName, bool requiresNew = false)
        {
            Check.NotNull(reservationName, nameof(reservationName));

            if (!requiresNew &&
                _ambientUnitOfWork.UnitOfWork != null &&
                _ambientUnitOfWork.UnitOfWork.IsReservedFor(reservationName))
            {
                return new ChildUnitOfWork(_ambientUnitOfWork.UnitOfWork);
            }

            var unitOfWork = CreateNewUnitOfWork();
            unitOfWork.Reserve(reservationName);

            return unitOfWork;
        }

        /// <summary>
        /// Begins the reserved.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="Exception">Could not find a reserved unit of work with reservation name: {reservationName}</exception>
        public void BeginReserved(string reservationName, UnitOfWorkOptions options)
        {
            if (!TryBeginReserved(reservationName, options))
            {
                throw new Exception($"Could not find a reserved unit of work with reservation name: {reservationName}");
            }
        }

        /// <summary>
        /// Tries the begin reserved.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryBeginReserved(string reservationName, UnitOfWorkOptions options)
        {
            Check.NotNull(reservationName, nameof(reservationName));

            var uow = _ambientUnitOfWork.UnitOfWork;

            //Find reserved unit of work starting from current and going to outers
            while (uow != null && !uow.IsReservedFor(reservationName))
            {
                uow = uow.Outer;
            }

            if (uow == null)
            {
                return false;
            }

            uow.Initialize(options);

            return true;
        }

        /// <summary>
        /// Gets the current unit of work.
        /// </summary>
        /// <returns>IUnitOfWork.</returns>
        private IUnitOfWork GetCurrentUnitOfWork()
        {
            var uow = _ambientUnitOfWork.UnitOfWork;

            //Skip reserved unit of work
            while (uow != null && (uow.IsReserved || uow.IsDisposed || uow.IsCompleted))
            {
                uow = uow.Outer;
            }

            return uow;
        }

        /// <summary>
        /// Creates the new unit of work.
        /// </summary>
        /// <returns>IUnitOfWork.</returns>
        private IUnitOfWork CreateNewUnitOfWork()
        {
            var scope = _serviceScopeFactory.CreateScope();
            try
            {
                var outerUow = _ambientUnitOfWork.UnitOfWork;

                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                unitOfWork.SetOuter(outerUow);

                _ambientUnitOfWork.SetUnitOfWork(unitOfWork);

                unitOfWork.Disposed += (sender, args) =>
                {
                    _ambientUnitOfWork.SetUnitOfWork(outerUow);
                    scope.Dispose();
                };

                return unitOfWork;
            }
            catch
            {
                scope.Dispose();
                throw;
            }
        }
    }
}