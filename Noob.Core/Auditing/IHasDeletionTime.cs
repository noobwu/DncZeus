// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IHasDeletionTime.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// A standard interface to add DeletionTime property to a class.
    /// It also makes the class soft delete (see <see cref="ISoftDelete" />).
    /// Implements the <see cref="Noob.ISoftDelete" />
    /// </summary>
    /// <seealso cref="Noob.ISoftDelete" />
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// Deletion time.
        /// </summary>
        /// <value>The deletion time.</value>
        DateTime? DeletionTime { get; set; }
    }
}