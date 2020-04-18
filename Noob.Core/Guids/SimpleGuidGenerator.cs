// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="SimpleGuidGenerator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Guids
{
    /// <summary>
    /// Implements <see cref="IGuidGenerator" /> by using <see cref="Guid.NewGuid" />.
    /// Implements the <see cref="Noob.Guids.IGuidGenerator" />
    /// </summary>
    /// <seealso cref="Noob.Guids.IGuidGenerator" />
    public class SimpleGuidGenerator : IGuidGenerator
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static SimpleGuidGenerator Instance { get; } = new SimpleGuidGenerator();

        /// <summary>
        /// Creates a new <see cref="Guid" />.
        /// </summary>
        /// <returns>Guid.</returns>
        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}