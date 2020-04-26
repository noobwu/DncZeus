// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IMustHaveCreator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Auditing
{
    /// <summary>
    /// Standard interface for an entity that MUST have a creator of type <typeparamref name="TCreator" />.
    /// Implements the <see cref="Noob.Auditing.IMustHaveCreator" />
    /// </summary>
    /// <typeparam name="TCreator">The type of the t creator.</typeparam>
    /// <seealso cref="Noob.Auditing.IMustHaveCreator" />
    public interface IMustHaveCreator<TCreator> : IMustHaveCreator
    {
        /// <summary>
        /// Reference to the creator.
        /// </summary>
        /// <value>The creator.</value>
        [NotNull]
        TCreator Creator { get; set; }
    }

    /// <summary>
    /// Standard interface for an entity that MUST have a creator.
    /// Implements the <see cref="Noob.Auditing.IMustHaveCreator" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IMustHaveCreator" />
    public interface IMustHaveCreator
    {
        /// <summary>
        /// Id of the creator.
        /// </summary>
        /// <value>The creator identifier.</value>
        Guid CreatorId { get; set; }
    }
}