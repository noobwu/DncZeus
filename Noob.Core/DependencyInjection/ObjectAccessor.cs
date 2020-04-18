// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ObjectAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using JetBrains.Annotations;

/// <summary>
/// The DependencyInjection namespace.
/// </summary>
namespace Noob.DependencyInjection
{

    /// <summary>
    /// Class ObjectAccessor.
    /// Implements the <see cref="Noob.DependencyInjection.IObjectAccessor{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Noob.DependencyInjection.IObjectAccessor{T}" />
    public class ObjectAccessor<T> : IObjectAccessor<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAccessor{T}" /> class.
        /// </summary>
        public ObjectAccessor()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAccessor{T}" /> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        public ObjectAccessor([CanBeNull] T obj)
        {
            Value = obj;
        }
    }
}