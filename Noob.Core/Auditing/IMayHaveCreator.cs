// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IMayHaveCreator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IMayHaveCreator
    /// </summary>
    /// <typeparam name="TCreator">The type of the t creator.</typeparam>
    public interface IMayHaveCreator<TCreator>
    {
        /// <summary>
        /// Reference to the creator.
        /// </summary>
        /// <value>The creator.</value>
        [CanBeNull]
        TCreator Creator { get; set; }
    }

    /// <summary>
    /// Standard interface for an entity that MAY have a creator.
    /// </summary>
    public interface IMayHaveCreator
    {
        /// <summary>
        /// Id of the creator.
        /// </summary>
        /// <value>The creator identifier.</value>
        Guid? CreatorId { get; set; }
    }
}