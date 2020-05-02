// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="EntityNotFoundException.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Domain.Entities
{
    /// <summary>
    /// This exception is thrown if an entity excepted to be found but not found.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EntityNotFoundException :Exception
    {
        /// <summary>
        /// Type of the entity.
        /// </summary>
        /// <value>The type of the entity.</value>
        public Type EntityType { get; set; }

        /// <summary>
        /// Id of the Entity.
        /// </summary>
        /// <value>The identifier.</value>
        public object Id { get; set; }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        public EntityNotFoundException(Type entityType)
            : this(entityType, null, null)
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="id">The identifier.</param>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="innerException">The inner exception.</param>
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base(
                id == null
                    ? $"There is no such an entity given given id. Entity type: {entityType.FullName}"
                    : $"There is no such an entity. Entity type: {entityType.FullName}, id: {id}",
                innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
