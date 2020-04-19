// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkExtensions.
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// Determines whether [is reserved for] [the specified reservation name].
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <returns><c>true</c> if [is reserved for] [the specified reservation name]; otherwise, <c>false</c>.</returns>
        public static bool IsReservedFor([NotNull] this IUnitOfWork unitOfWork, string reservationName)
        {
            Check.NotNull(unitOfWork, nameof(unitOfWork));

            return unitOfWork.IsReserved && unitOfWork.ReservationName == reservationName;
        }
    }
}