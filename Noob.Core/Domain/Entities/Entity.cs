// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 04-05-2020
//
// Last Modified By : Administrator
// Last Modified On : 04-05-2020
// ***********************************************************************
// <copyright file="Entity.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Noob.Domain.Entities
{
    /// <summary>
    /// Class Entity.
    /// Implements the <see cref="Noob.D2CMSApi.Domain.Entities.IEntity" />
    /// Implements the <see cref="Noob.Domain.Entities.IEntity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.IEntity" />
    /// <seealso cref="Noob.D2CMSApi.Domain.Entities.IEntity" />
    /// <inheritdoc />
    [Serializable]
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        /// <inheritdoc />
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Keys = { string.Join(", ", GetKeys())}";
        }

        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public abstract object[] GetKeys();
    }

    /// <summary>
    /// Class Entity.
    /// Implements the <see cref="Noob.D2CMSApi.Domain.Entities.Entity" />
    /// Implements the <see cref="Noob.D2CMSApi.Domain.Entities.IEntity{TKey}" />
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// Implements the <see cref="Noob.Domain.Entities.IEntity{TKey}" />
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    /// <seealso cref="Noob.Domain.Entities.IEntity{TKey}" />
    /// <seealso cref="Noob.D2CMSApi.Domain.Entities.Entity" />
    /// <seealso cref="Noob.D2CMSApi.Domain.Entities.IEntity{TKey}" />
    /// <inheritdoc cref="IEntity{TKey}" />
    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        /// <value>The identifier.</value>
        /// <inheritdoc />
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TKey}" /> class.
        /// </summary>
        protected Entity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TKey}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Entity(TKey id)
        {
            Id = id;
        }

        /// <summary>
        /// Entities the equals.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool EntityEquals(object obj)
        {
            if (obj == null || !(obj is Entity<TKey>))
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            //Transient objects are not considered as equal
            var other = (Entity<TKey>)obj;
            if (EntityHelper.HasDefaultId(this) && EntityHelper.HasDefaultId(other))
            {
                return false;
            }

            //Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType().GetTypeInfo();
            var typeOfOther = other.GetType().GetTypeInfo();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public override object[] GetKeys()
        {
            return new object[] {Id};
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        /// <inheritdoc />
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }
    }
}
