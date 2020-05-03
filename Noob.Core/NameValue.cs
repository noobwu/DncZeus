// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="NameValue.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob
{
    /// <summary>
    /// Can be used to store Name/Value (or Key/Value) pairs.
    /// Implements the <see cref="Noob.NameValue{System.String}" />
    /// </summary>
    /// <seealso cref="Noob.NameValue{System.String}" />
    [Serializable]
    public class NameValue : NameValue<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue"/> class.
        /// </summary>
        public NameValue()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    /// <summary>
    /// Can be used to store Name/Value (or Key/Value) pairs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class NameValue<T>
    {
        /// <summary>
        /// Name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue{T}"/> class.
        /// </summary>
        public NameValue()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue{T}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public NameValue(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}