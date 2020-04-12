// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="TypeConstants.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Noob
{
    /// <summary>
    /// Class TypeConstants.
    /// </summary>
    public static class TypeConstants
    {
        /// <summary>
        /// Initializes static members of the <see cref="TypeConstants"/> class.
        /// </summary>
        static TypeConstants()
        {
            ZeroTask = InTask(0);
            TrueTask = InTask(true);
            FalseTask = InTask(false);
            EmptyTask = InTask((object)null);
        }
        /// <summary>
        /// Ins the task.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        private static Task<T> InTask<T>(this T result)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs.Task;
        }

        /// <summary>
        /// The zero task
        /// </summary>
        public static readonly Task<int> ZeroTask;
        /// <summary>
        /// The true task
        /// </summary>
        public static readonly Task<bool> TrueTask;
        /// <summary>
        /// The false task
        /// </summary>
        public static readonly Task<bool> FalseTask;
        /// <summary>
        /// The empty task
        /// </summary>
        public static readonly Task<object> EmptyTask;

        /// <summary>
        /// The empty object
        /// </summary>
        public static readonly object EmptyObject = new object();

        /// <summary>
        /// The non width white space
        /// </summary>
        public const char NonWidthWhiteSpace = (char)0x200B; //Use zero-width space marker to capture empty string
        /// <summary>
        /// The non width white space chars
        /// </summary>
        public static char[] NonWidthWhiteSpaceChars = { (char)0x200B };

        /// <summary>
        /// Gets the null string span.
        /// </summary>
        /// <value>The null string span.</value>
        public static ReadOnlySpan<char> NullStringSpan => default;
        /// <summary>
        /// Gets the empty string span.
        /// </summary>
        /// <value>The empty string span.</value>
        public static ReadOnlySpan<char> EmptyStringSpan => new ReadOnlySpan<char>(NonWidthWhiteSpaceChars);

        /// <summary>
        /// Gets the null string memory.
        /// </summary>
        /// <value>The null string memory.</value>
        public static ReadOnlyMemory<char> NullStringMemory => default;
        /// <summary>
        /// Gets the empty string memory.
        /// </summary>
        /// <value>The empty string memory.</value>
        public static ReadOnlyMemory<char> EmptyStringMemory => "".AsMemory();
    }
}
