// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkFailedEventArgs.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Used as event arguments on <see cref="IUnitOfWork.Failed" /> event.
    /// Implements the <see cref="Noob.Uow.UnitOfWorkEventArgs" />
    /// </summary>
    /// <seealso cref="Noob.Uow.UnitOfWorkEventArgs" />
    public class UnitOfWorkFailedEventArgs : UnitOfWorkEventArgs
    {
        /// <summary>
        /// Exception that caused failure. This is set only if an error occurred during <see cref="IUnitOfWork.Complete" />.
        /// Can be null if there is no exception, but <see cref="IUnitOfWork.Complete" /> is not called.
        /// Can be null if another exception occurred during the UOW.
        /// </summary>
        /// <value>The exception.</value>
        [CanBeNull]
        public Exception Exception { get; }

        /// <summary>
        /// True, if the unit of work is manually rolled back.
        /// </summary>
        /// <value><c>true</c> if this instance is rolledback; otherwise, <c>false</c>.</value>
        public bool IsRolledback { get; }

        /// <summary>
        /// Creates a new <see cref="UnitOfWorkFailedEventArgs" /> object.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="isRolledback">if set to <c>true</c> [is rolledback].</param>
        public UnitOfWorkFailedEventArgs([NotNull] IUnitOfWork unitOfWork, [CanBeNull] Exception exception, bool isRolledback)
            : base(unitOfWork)
        {
            Exception = exception;
            IsRolledback = isRolledback;
        }
    }
}
