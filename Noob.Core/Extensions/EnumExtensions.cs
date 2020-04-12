﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="EnumExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noob.Extensions
{
    /// <summary>
    /// Class EnumUtils.
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>();
    }

    /// <summary>
    /// Class EnumExtensions.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the textual description of the enum if it has one. e.g.
        /// <code>
        /// enum UserColors
        /// {
        /// [Description("Bright Red")]
        /// BrightRed
        /// }
        /// UserColors.BrightRed.ToDescription();
        /// </code>
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns>System.String.</returns>
        public static string ToDescription(this Enum @enum)
        {
            var type = @enum.GetType();

            var memInfo = type.GetMember(@enum.ToString());

            if (memInfo.Length > 0)
            {
                var description = memInfo[0].GetDescription();

                if (description != null)
                    return description;
            }

            return @enum.ToString();
        }

        /// <summary>
        /// Converts to keyvaluepairs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enums">The enums.</param>
        /// <returns>List&lt;KeyValuePair&lt;System.String, System.String&gt;&gt;.</returns>
        public static List<KeyValuePair<string, string>> ToKeyValuePairs<T>(this IEnumerable<T> enums) where T : Enum
            => enums.Map(x => new KeyValuePair<string, string>(
                x.ToString(),
                x.ToDescription()));

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> ToList(this Enum @enum)
        {
            return new List<string>(Enum.GetNames(@enum.GetType()));
        }

        /// <summary>
        /// Gets the type code.
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns>TypeCode.</returns>
        public static TypeCode GetTypeCode(this Enum @enum)
        {
            return Enum.GetUnderlyingType(@enum.GetType()).GetTypeCode();
        }

        /// <summary>
        /// Determines whether [has] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum">The enum.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [has] [the specified value]; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">Enums of type {@enum.GetType().Name}</exception>
        public static bool Has<T>(this Enum @enum, T value)
        {
            var typeCode = @enum.GetTypeCode();
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return (((byte)(object)@enum & (byte)(object)value) == (byte)(object)value);
                case TypeCode.Int16:
                    return (((short)(object)@enum & (short)(object)value) == (short)(object)value);
                case TypeCode.Int32:
                    return (((int)(object)@enum & (int)(object)value) == (int)(object)value);
                case TypeCode.Int64:
                    return (((long)(object)@enum & (long)(object)value) == (long)(object)value);
                default:
                    throw new NotSupportedException($"Enums of type {@enum.GetType().Name}");
            }
        }

        /// <summary>
        /// Determines whether [is] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum">The enum.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is] [the specified value]; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">Enums of type {@enum.GetType().Name}</exception>
        public static bool Is<T>(this Enum @enum, T value)
        {
            var typeCode = @enum.GetTypeCode();
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return (byte)(object)@enum == (byte)(object)value;
                case TypeCode.Int16:
                    return (short)(object)@enum == (short)(object)value;
                case TypeCode.Int32:
                    return (int)(object)@enum == (int)(object)value;
                case TypeCode.Int64:
                    return (long)(object)@enum == (long)(object)value;
                default:
                    throw new NotSupportedException($"Enums of type {@enum.GetType().Name}");
            }
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum">The enum.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="NotSupportedException">Enums of type {@enum.GetType().Name}</exception>
        public static T Add<T>(this Enum @enum, T value)
        {
            var typeCode = @enum.GetTypeCode();
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return (T)(object)((byte)(object)@enum | (byte)(object)value);
                case TypeCode.Int16:
                    return (T)(object)((short)(object)@enum | (short)(object)value);
                case TypeCode.Int32:
                    return (T)(object)((int)(object)@enum | (int)(object)value);
                case TypeCode.Int64:
                    return (T)(object)((long)(object)@enum | (long)(object)value);
                default:
                    throw new NotSupportedException($"Enums of type {@enum.GetType().Name}");
            }
        }
        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum">The enum.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="NotSupportedException">Enums of type {@enum.GetType().Name}</exception>
        public static T Remove<T>(this Enum @enum, T value)
        {
            var typeCode = @enum.GetTypeCode();
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return (T)(object)((byte)(object)@enum & ~(byte)(object)value);
                case TypeCode.Int16:
                    return (T)(object)((short)(object)@enum & ~(short)(object)value);
                case TypeCode.Int32:
                    return (T)(object)((int)(object)@enum & ~(int)(object)value);
                case TypeCode.Int64:
                    return (T)(object)((long)(object)@enum & ~(long)(object)value);
                default:
                    throw new NotSupportedException($"Enums of type {@enum.GetType().Name}");
            }
        }

    }

}