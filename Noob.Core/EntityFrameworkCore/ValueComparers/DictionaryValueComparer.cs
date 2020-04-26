// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="DictionaryValueComparer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Noob.EntityFrameworkCore.ValueComparers
{
    /// <summary>
    /// Class DictionaryValueComparer.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer{System.Collections.Generic.Dictionary{TKey, TValue}}" />
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TValue">The type of the t value.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer{System.Collections.Generic.Dictionary{TKey, TValue}}" />
    public class DictionaryValueComparer<TKey, TValue> : ValueComparer<Dictionary<TKey, TValue>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryValueComparer{TKey, TValue}"/> class.
        /// </summary>
        public DictionaryValueComparer()
            : base(
                  (d1, d2) => d1.SequenceEqual(d2),
                  d => d.Aggregate(0, (k, v) => HashCode.Combine(k, v.GetHashCode())),
                  d => d.ToDictionary(k => k.Key, v => v.Value))
        {
        }
    }
}
