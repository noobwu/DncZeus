// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-22
// ***********************************************************************
// <copyright file="PersonCacheItem.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;

namespace Noob.Caching
{
    /// <summary>
    /// Class PersonCacheItem.
    /// </summary>
    [Serializable]
    public class PersonCacheItem
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="PersonCacheItem"/> class from being created.
        /// </summary>
        private PersonCacheItem()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCacheItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PersonCacheItem(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Class ComplexObjectAsCacheKey.
    /// </summary>
    public class ComplexObjectAsCacheKey
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            // Return selective fields
            //return $"{Name}_{Age}";
            // Return all the fields concatenated
            var sb = new System.Text.StringBuilder();
            var properties = this.GetType().GetProperties()
                .Where(prop => prop.CanRead && prop.CanWrite);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(this, null);
                if (value != null)
                {
                    sb.Append(value.ToString());
                }
            }
            return sb.ToString();
        }
    }
}

namespace Sail.Testing.Caching
{
    /// <summary>
    /// Class PersonCacheItem.
    /// </summary>
    [Serializable]
    public class PersonCacheItem
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="PersonCacheItem"/> class from being created.
        /// </summary>
        private PersonCacheItem()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCacheItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PersonCacheItem(string name)
        {
            Name = name;
        }
    }
}