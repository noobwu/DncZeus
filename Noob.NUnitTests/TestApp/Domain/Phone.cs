// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Phone.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Noob.Domain.Entities;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Class Phone.
    /// Implements the <see cref="Noob.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity{System.Guid}" />
    [Table("AppPhones")]
    public class Phone : Entity<Guid>
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public virtual Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public virtual string Number { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public virtual PhoneType Type { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Phone"/> class from being created.
        /// </summary>
        private Phone()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="type">The type.</param>
        public Phone(Guid personId, string number, PhoneType type = PhoneType.Mobile)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            Number = number;
            Type = type;
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public override object[] GetKeys()
        {
            return new object[] { PersonId, Number };
        }
    }

    /// <summary>
    /// Class Order.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    public class Order : AggregateRoot<Guid>
    {
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public virtual string ReferenceNo { get; protected set; }

        /// <summary>
        /// Gets or sets the total item count.
        /// </summary>
        /// <value>The total item count.</value>
        public virtual float TotalItemCount { get; protected set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>The creation time.</value>
        public virtual DateTime CreationTime { get; protected set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        /// <value>The order lines.</value>
        public virtual List<OrderLine> OrderLines { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        protected Order()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="referenceNo">The reference no.</param>
        public Order(Guid id, string referenceNo)
            : base(id)
        {
            ReferenceNo = referenceNo;
            OrderLines = new List<OrderLine>();
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="ArgumentException">You can not add zero or negative count of products! - count</exception>
        public void AddProduct(Guid productId, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("You can not add zero or negative count of products!", nameof(count));
            }

            var existingLine = OrderLines.FirstOrDefault(ol => ol.ProductId == productId);

            if (existingLine == null)
            {
                OrderLines.Add(new OrderLine(this.Id, productId, count));
            }
            else
            {
                existingLine.ChangeCount(existingLine.Count + count);
            }

            TotalItemCount += count;
        }
    }

    /// <summary>
    /// Class OrderLine.
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    public class OrderLine : Entity
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public virtual Guid OrderId { get; protected set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public virtual Guid ProductId { get; protected set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public virtual int Count { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class.
        /// </summary>
        protected OrderLine()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="count">The count.</param>
        public OrderLine(Guid orderId, Guid productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        /// <summary>
        /// Changes the count.
        /// </summary>
        /// <param name="newCount">The new count.</param>
        internal void ChangeCount(int newCount)
        {
            Count = newCount;
        }

        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public override object[] GetKeys()
        {
            return new object[] { OrderId, ProductId };
        }
    }
}