// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AggregateRoot.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.Domain.Entities
{
    /// <summary>
    /// Class AggregateRoot.
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public abstract class AggregateRoot : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
        }
    }
    /// <summary>
    /// Class AggregateRoot.
    /// Implements the <see cref="Noob.Domain.Entities.Entity{TKey}" />
    /// Implements the <see cref="Noob.Domain.Entities.IAggregateRoot{TKey}" />
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Entity{TKey}" />
    /// <seealso cref="Noob.Domain.Entities.IAggregateRoot{TKey}" />
    [Serializable]
    public abstract class AggregateRoot<TKey> : Entity<TKey>,
        IAggregateRoot<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TKey}"/> class.
        /// </summary>
        protected AggregateRoot()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TKey}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected AggregateRoot(TKey id)
            : base(id)
        {
        }
    }
}
