// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="EnumerableExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noob.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty<T>(this T[] collection)
        {
            return collection == null || collection.Length == 0;
        }
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }


        /// <summary>
        /// Determines whether the specified collection is any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is any; otherwise, <c>false</c>.</returns>
        public static bool IsAny<T>(this ICollection<T> collection)
        {
            return collection != null && collection.Count > 0;
        }
        /// <summary>
        /// Determines whether the specified collection is any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is any; otherwise, <c>false</c>.</returns>
        public static bool IsAny<T>(this T[] collection)
        {
            return collection != null && collection.Length > 0;
        }
        /// <summary>
        /// Determines whether the specified collection is any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is any; otherwise, <c>false</c>.</returns>
        public static bool IsAny<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Count() > 0;
        }
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty(this NameValueCollection collection)
        {
            return collection == null || collection.Count == 0 || collection.AllKeys.IsEmpty();
        }
        /// <summary>
        /// Determines whether the specified collection is any.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns><c>true</c> if the specified collection is any; otherwise, <c>false</c>.</returns>
        public static bool IsAny(this NameValueCollection collection)
        {
            return collection != null && collection.Count > 0 && collection.AllKeys.IsAny();
        }
        /// <summary>
        /// Distincts the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="Tkey">The type of the tkey.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>IEnumerable&lt;TSource&gt;.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, Tkey>(this IEnumerable<TSource> source, Func<TSource, Tkey> keySelector)
        {
            HashSet<Tkey> hashSet = new HashSet<Tkey>();
            foreach (TSource item in source)
            {
                if (hashSet.Add(keySelector(item)))
                {
                    yield return item;
                }
            }
        }
        /// <summary>
        /// Eaches the specified action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="action">The action.</param>
        public static void Each<T>(this IEnumerable<T> values, Action<T> action)
        {
            if (values == null) return;

            foreach (var value in values)
            {
                action(value);
            }
        }
        /// <summary>
        /// Eaches the specified action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="action">The action.</param>
        public static void Each<T>(this IEnumerable<T> values, Action<int, T> action)
        {
            if (values == null) return;

            var i = 0;
            foreach (var value in values)
            {
                action(i++, value);
            }
        }
        /// <summary>
        /// Eaches the specified action.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="map">The map.</param>
        /// <param name="action">The action.</param>
        public static void Each<TKey, TValue>(this IDictionary<TKey, TValue> map, Action<TKey, TValue> action)
        {
            if (map == null) return;

            var keys = map.Keys.ToList();
            foreach (var key in keys)
            {
                action(key, map[key]);
            }
        }
        /// <summary>
        /// Maps the specified converter.
        /// </summary>
        /// <typeparam name="To">The type of to.</typeparam>
        /// <typeparam name="From">The type of from.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>List&lt;To&gt;.</returns>
        public static List<To> Map<To, From>(this IEnumerable<From> items, Func<From, To> converter)
        {
            if (items == null)
                return new List<To>();

            var list = new List<To>();
            foreach (var item in items)
            {
                list.Add(converter(item));
            }
            return list;
        }

        /// <summary>
        /// Maps the specified converter.
        /// </summary>
        /// <typeparam name="To">The type of to.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>List&lt;To&gt;.</returns>
        public static List<To> Map<To>(this System.Collections.IEnumerable items, Func<object, To> converter)
        {
            if (items == null)
                return new List<To>();

            var list = new List<To>();
            foreach (var item in items)
            {
                list.Add(converter(item));
            }
            return list;
        }



    }
}
