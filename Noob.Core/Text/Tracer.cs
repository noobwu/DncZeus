// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="Tracer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Text
{
    /// <summary>
    /// Class Tracer.
    /// </summary>
    public class Tracer
    {
        /// <summary>
        /// The instance
        /// </summary>
        public static ITracer Instance = new NullTracer();

        /// <summary>
        /// Class NullTracer.
        /// Implements the <see cref="Noob.Text.ITracer" />
        /// </summary>
        /// <seealso cref="Noob.Text.ITracer" />
        public class NullTracer :ITracer
        {
            /// <summary>
            /// Writes the debug.
            /// </summary>
            /// <param name="error">The error.</param>
            public void WriteDebug(string error) { }

            /// <summary>
            /// Writes the debug.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            public void WriteDebug(string format, params object[] args) { }

            /// <summary>
            /// Writes the warning.
            /// </summary>
            /// <param name="warning">The warning.</param>
            public void WriteWarning(string warning) { }

            /// <summary>
            /// Writes the warning.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            public void WriteWarning(string format, params object[] args) { }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="ex">The ex.</param>
            public void WriteError(Exception ex)
            {
                    throw ex;
            }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="error">The error.</param>
            /// <exception cref="Exception"></exception>
            public void WriteError(string error)
            {
                    throw new Exception(error);
            }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            /// <exception cref="Exception"></exception>
            public void WriteError(string format, params object[] args)
            {
                    throw new Exception(string.Format(format, args));
            }
        }

        /// <summary>
        /// Class ConsoleTracer.
        /// Implements the <see cref="Noob.Text.ITracer" />
        /// </summary>
        /// <seealso cref="Noob.Text.ITracer" />
        public class ConsoleTracer : ITracer
        {
            /// <summary>
            /// Writes the debug.
            /// </summary>
            /// <param name="error">The error.</param>
            public void WriteDebug(string error)
            {
               Console.WriteLine(error);
            }

            /// <summary>
            /// Writes the debug.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            public void WriteDebug(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }

            /// <summary>
            /// Writes the warning.
            /// </summary>
            /// <param name="warning">The warning.</param>
            public void WriteWarning(string warning)
            {
                Console.WriteLine(warning);
            }

            /// <summary>
            /// Writes the warning.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            public void WriteWarning(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="ex">The ex.</param>
            public void WriteError(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="error">The error.</param>
            public void WriteError(string error)
            {
                Console.WriteLine(error);
            }

            /// <summary>
            /// Writes the error.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="args">The arguments.</param>
            public void WriteError(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }
        }
    }

    /// <summary>
    /// Class TracerExceptions.
    /// </summary>
    public static class TracerExceptions
    {
        /// <summary>
        /// Traces the specified ex.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex">The ex.</param>
        /// <returns>T.</returns>
        public static T Trace<T>(this T ex) where T : Exception
        {
            Tracer.Instance.WriteError(ex);
            return ex;
        }
    }
}