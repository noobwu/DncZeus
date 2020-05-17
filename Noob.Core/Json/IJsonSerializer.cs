// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="IJsonSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Json
{
    /// <summary>
    /// Interface IJsonSerializer
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <param name="indented">if set to <c>true</c> [indented].</param>
        /// <returns>System.String.</returns>
        string Serialize(object obj, bool camelCase = true, bool indented = false);

        /// <summary>
        /// Deserializes the specified json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <returns>T.</returns>
        T Deserialize<T>(string jsonString, bool camelCase = true);

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="jsonString">The json string.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <returns>System.Object.</returns>
        object Deserialize(Type type, string jsonString, bool camelCase = true);
    }
}