// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="SharedPoolExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Text.Pools
{
    // Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class SharedPoolExtensions.
    /// </summary>
    internal static class SharedPoolExtensions
    {
        /// <summary>
        /// The threshold
        /// </summary>
        private const int Threshold = 512;

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;StringBuilder&gt;.</returns>
        public static PooledObject<StringBuilder> GetPooledObject(this ObjectPool<StringBuilder> pool)
        {
            return PooledObject<StringBuilder>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;Stack&lt;TItem&gt;&gt;.</returns>
        public static PooledObject<Stack<TItem>> GetPooledObject<TItem>(this ObjectPool<Stack<TItem>> pool)
        {
            return PooledObject<Stack<TItem>>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;Queue&lt;TItem&gt;&gt;.</returns>
        public static PooledObject<Queue<TItem>> GetPooledObject<TItem>(this ObjectPool<Queue<TItem>> pool)
        {
            return PooledObject<Queue<TItem>>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;HashSet&lt;TItem&gt;&gt;.</returns>
        public static PooledObject<HashSet<TItem>> GetPooledObject<TItem>(this ObjectPool<HashSet<TItem>> pool)
        {
            return PooledObject<HashSet<TItem>>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;Dictionary&lt;TKey, TValue&gt;&gt;.</returns>
        public static PooledObject<Dictionary<TKey, TValue>> GetPooledObject<TKey, TValue>(this ObjectPool<Dictionary<TKey, TValue>> pool)
        {
            return PooledObject<Dictionary<TKey, TValue>>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;List&lt;TItem&gt;&gt;.</returns>
        public static PooledObject<List<TItem>> GetPooledObject<TItem>(this ObjectPool<List<TItem>> pool)
        {
            return PooledObject<List<TItem>>.Create(pool);
        }

        /// <summary>
        /// Gets the pooled object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>PooledObject&lt;T&gt;.</returns>
        public static PooledObject<T> GetPooledObject<T>(this ObjectPool<T> pool) where T : class
        {
            return new PooledObject<T>(pool, p => p.Allocate(), (p, o) => p.Free(o));
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <param name="pool">The pool.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder AllocateAndClear(this ObjectPool<StringBuilder> pool)
        {
            var sb = pool.Allocate();
            sb.Clear();

            return sb;
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>Stack&lt;T&gt;.</returns>
        public static Stack<T> AllocateAndClear<T>(this ObjectPool<Stack<T>> pool)
        {
            var set = pool.Allocate();
            set.Clear();

            return set;
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>Queue&lt;T&gt;.</returns>
        public static Queue<T> AllocateAndClear<T>(this ObjectPool<Queue<T>> pool)
        {
            var set = pool.Allocate();
            set.Clear();

            return set;
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>HashSet&lt;T&gt;.</returns>
        public static HashSet<T> AllocateAndClear<T>(this ObjectPool<HashSet<T>> pool)
        {
            var set = pool.Allocate();
            set.Clear();

            return set;
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>Dictionary&lt;TKey, TValue&gt;.</returns>
        public static Dictionary<TKey, TValue> AllocateAndClear<TKey, TValue>(this ObjectPool<Dictionary<TKey, TValue>> pool)
        {
            var map = pool.Allocate();
            map.Clear();

            return map;
        }

        /// <summary>
        /// Allocates the and clear.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> AllocateAndClear<T>(this ObjectPool<List<T>> pool)
        {
            var list = pool.Allocate();
            list.Clear();

            return list;
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <param name="pool">The pool.</param>
        /// <param name="sb">The sb.</param>
        public static void ClearAndFree(this ObjectPool<StringBuilder> pool, StringBuilder sb)
        {
            if (sb == null)
            {
                return;
            }

            sb.Clear();

            if (sb.Capacity > Threshold)
            {
                sb.Capacity = Threshold;
            }

            pool.Free(sb);
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <param name="set">The set.</param>
        public static void ClearAndFree<T>(this ObjectPool<HashSet<T>> pool, HashSet<T> set)
        {
            if (set == null)
            {
                return;
            }

            var count = set.Count;
            set.Clear();

            if (count > Threshold)
            {
                set.TrimExcess();
            }

            pool.Free(set);
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <param name="set">The set.</param>
        public static void ClearAndFree<T>(this ObjectPool<Stack<T>> pool, Stack<T> set)
        {
            if (set == null)
            {
                return;
            }

            var count = set.Count;
            set.Clear();

            if (count > Threshold)
            {
                set.TrimExcess();
            }

            pool.Free(set);
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <param name="set">The set.</param>
        public static void ClearAndFree<T>(this ObjectPool<Queue<T>> pool, Queue<T> set)
        {
            if (set == null)
            {
                return;
            }

            var count = set.Count;
            set.Clear();

            if (count > Threshold)
            {
                set.TrimExcess();
            }

            pool.Free(set);
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="pool">The pool.</param>
        /// <param name="map">The map.</param>
        public static void ClearAndFree<TKey, TValue>(this ObjectPool<Dictionary<TKey, TValue>> pool, Dictionary<TKey, TValue> map)
        {
            if (map == null)
            {
                return;
            }

            // if map grew too big, don't put it back to pool
            if (map.Count > Threshold)
            {
                pool.ForgetTrackedObject(map);
                return;
            }

            map.Clear();
            pool.Free(map);
        }

        /// <summary>
        /// Clears the and free.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool">The pool.</param>
        /// <param name="list">The list.</param>
        public static void ClearAndFree<T>(this ObjectPool<List<T>> pool, List<T> list)
        {
            if (list == null)
            {
                return;
            }

            list.Clear();

            if (list.Capacity > Threshold)
            {
                list.Capacity = Threshold;
            }

            pool.Free(list);
        }
    }
}