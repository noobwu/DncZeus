﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="CharPool .cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Text.Pools
{
    /// <summary>
    /// Class CharPool. This class cannot be inherited.
    /// </summary>
    public sealed class CharPool
    {
        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public static void Flush()
        {
            lock (Pool)
            {
                for (var i = 0; i < Pool.Length; i++)
                    Pool[i] = null;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="CharPool"/> class from being created.
        /// </summary>
        private CharPool() { }
        /// <summary>
        /// The pool size
        /// </summary>
        private const int POOL_SIZE = 20;
        /// <summary>
        /// The buffer length
        /// </summary>
        public const int BUFFER_LENGTH = 1450; //<= MTU - DJB
        /// <summary>
        /// The pool
        /// </summary>
        private static readonly CachedBuffer[] Pool = new CachedBuffer[POOL_SIZE];

        /// <summary>
        /// Gets the buffer.
        /// </summary>
        /// <returns>System.Char[].</returns>
        public static char[] GetBuffer()
        {
            return GetBuffer(BUFFER_LENGTH);
        }

        /// <summary>
        /// Gets the buffer.
        /// </summary>
        /// <param name="minSize">The minimum size.</param>
        /// <returns>System.Char[].</returns>
        public static char[] GetBuffer(int minSize)
        {
            char[] cachedBuff = GetCachedBuffer(minSize);
            return cachedBuff ?? new char[minSize];
        }

        /// <summary>
        /// Gets the cached buffer.
        /// </summary>
        /// <param name="minSize">The minimum size.</param>
        /// <returns>System.Char[].</returns>
        public static char[] GetCachedBuffer(int minSize)
        {
            lock (Pool)
            {
                var bestIndex = -1;
                char[] bestMatch = null;
                for (var i = 0; i < Pool.Length; i++)
                {
                    var buffer = Pool[i];
                    if (buffer == null || buffer.Size < minSize)
                    {
                        continue;
                    }
                    if (bestMatch != null && bestMatch.Length < buffer.Size)
                    {
                        continue;
                    }

                    var tmp = buffer.Buffer;
                    if (tmp == null)
                    {
                        Pool[i] = null;
                    }
                    else
                    {
                        bestMatch = tmp;
                        bestIndex = i;
                    }
                }

                if (bestIndex >= 0)
                {
                    Pool[bestIndex] = null;
                }

                return bestMatch;
            }
        }

        /// <summary>
        /// The maxchar array size
        /// </summary>
        private const int MaxcharArraySize = int.MaxValue - 56;

        /// <summary>
        /// Resizes the and flush left.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="toFitAtLeastchars">To fit at leastchars.</param>
        /// <param name="copyFromIndex">Index of the copy from.</param>
        /// <param name="copychars">The copychars.</param>
        public static void ResizeAndFlushLeft(ref char[] buffer, int toFitAtLeastchars, int copyFromIndex, int copychars)
        {
            Helpers.DebugAssert(buffer != null);
            Helpers.DebugAssert(toFitAtLeastchars > buffer.Length);
            Helpers.DebugAssert(copyFromIndex >= 0);
            Helpers.DebugAssert(copychars >= 0);

            int newLength = buffer.Length * 2;
            if (newLength < 0)
            {
                newLength = MaxcharArraySize;
            }

            if (newLength < toFitAtLeastchars) newLength = toFitAtLeastchars;

            if (copychars == 0)
            {
                ReleaseBufferToPool(ref buffer);
            }

            var newBuffer = GetCachedBuffer(toFitAtLeastchars) ?? new char[newLength];

            if (copychars > 0)
            {
                Buffer.BlockCopy(buffer, copyFromIndex, newBuffer, 0, copychars);
                ReleaseBufferToPool(ref buffer);
            }

            buffer = newBuffer;
        }

        /// <summary>
        /// Releases the buffer to pool.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public static void ReleaseBufferToPool(ref char[] buffer)
        {
            if (buffer == null) return;

            lock (Pool)
            {
                var minIndex = 0;
                var minSize = int.MaxValue;
                for (var i = 0; i < Pool.Length; i++)
                {
                    var tmp = Pool[i];
                    if (tmp == null || !tmp.IsAlive)
                    {
                        minIndex = 0;
                        break;
                    }
                    if (tmp.Size < minSize)
                    {
                        minIndex = i;
                        minSize = tmp.Size;
                    }
                }

                Pool[minIndex] = new CachedBuffer(buffer);
            }

            buffer = null;
        }

        /// <summary>
        /// Class CachedBuffer.
        /// </summary>
        private class CachedBuffer
        {
            /// <summary>
            /// The reference
            /// </summary>
            private readonly WeakReference _reference;

            /// <summary>
            /// Gets the size.
            /// </summary>
            /// <value>The size.</value>
            public int Size { get; }

            /// <summary>
            /// Gets a value indicating whether this instance is alive.
            /// </summary>
            /// <value><c>true</c> if this instance is alive; otherwise, <c>false</c>.</value>
            public bool IsAlive => _reference.IsAlive;
            /// <summary>
            /// Gets the buffer.
            /// </summary>
            /// <value>The buffer.</value>
            public char[] Buffer => (char[])_reference.Target;

            /// <summary>
            /// Initializes a new instance of the <see cref="CachedBuffer"/> class.
            /// </summary>
            /// <param name="buffer">The buffer.</param>
            public CachedBuffer(char[] buffer)
            {
                Size = buffer.Length;
                _reference = new WeakReference(buffer);
            }
        }
    }
}