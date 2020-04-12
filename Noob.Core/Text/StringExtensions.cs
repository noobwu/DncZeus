﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Text;
using Noob.Text.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noob
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts from base: 0 - 62
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception">Parameter: '{source}' is not valid integer (in base {@from}).
        /// or
        /// Parameter: '{source}' is not valid integer (in base {@from}).
        /// or
        /// Parameter: '{source}' is not valid integer (in base {@from}).</exception>
        /// <exception cref="System.Exception">Parameter: '{source}' is not valid integer (in base {@from}).
        /// or
        /// Parameter: '{source}' is not valid integer (in base {@from}).
        /// or
        /// Parameter: '{source}' is not valid integer (in base {@from}).</exception>
        public static string BaseConvert(this string source, int from, int to)
        {
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var len = source.Length;
            if (len == 0)
                throw new Exception($"Parameter: '{source}' is not valid integer (in base {@from}).");
            var minus = source[0] == '-' ? "-" : "";
            var src = minus == "" ? source : source.Substring(1);
            len = src.Length;
            if (len == 0)
                throw new Exception($"Parameter: '{source}' is not valid integer (in base {@from}).");

            var d = 0;
            for (int i = 0; i < len; i++) // Convert to decimal
            {
                int c = chars.IndexOf(src[i]);
                if (c >= from)
                    throw new Exception($"Parameter: '{source}' is not valid integer (in base {@from}).");
                d = d * from + c;
            }
            if (to == 10 || d == 0)
                return minus + d;

            var result = "";
            while (d > 0)   // Convert to desired
            {
                result = chars[d % to] + result;
                d /= to;
            }
            return minus + result;
        }

        /// <summary>
        /// Encodes the XML.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string EncodeXml(this string value)
        {
            return value.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
        }

        /// <summary>
        /// Encodes the json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string EncodeJson(this string value)
        {
            return string.Concat
            ("\"",
                value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n"),
                "\""
            );
        }
        /// <summary>
        /// 结尾增加斜线
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">path</exception>
        /// <exception cref="System.ArgumentNullException">path</exception>
        public static string WithTrailingSlash(this string path)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (path[path.Length - 1] != '/')
            {
                return path + "/";
            }
            return path;
        }
        /// <summary>
        /// 结尾增加反斜线
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">path</exception>
        /// <exception cref="System.ArgumentNullException">path</exception>
        public static string WithTrailingBackSlash(this string path)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (path[path.Length - 1] != '\\')
            {
                return path + "\\";
            }
            return path;
        }


        /// <summary>
        /// Safes the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.String.</returns>
        public static string SafeSubstring(this string value, int startIndex)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;
            return SafeSubstring(value, startIndex, value.Length);
        }

        /// <summary>
        /// Safes the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string SafeSubstring(this string value, int startIndex, int length)
        {
            if (String.IsNullOrEmpty(value) || length <= 0) return string.Empty;
            if (startIndex < 0) startIndex = 0;
            if (value.Length >= (startIndex + length))
                return value.Substring(startIndex, length);

            return value.Length > startIndex ? value.Substring(startIndex) : string.Empty;
        }
        /// <summary>
        /// To the specified default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>T.</returns>
        public static T To<T>(this object value, T defaultValue = default(T))
        {
            try
            {
                return value == null ? defaultValue : (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }

        }

        /// <summary>
        /// 将以“,”分割的字符串转为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ToList<T>(this string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var list = id.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (list == null || list.Length == 0)
            {
                return null;
            }
            var ret = new List<T>();
            if (list == null) return ret;

            try
            {
                foreach (var item in list)
                {
                    if (item == null) continue;

                    var arr = item as IEnumerable;
                    if (arr != null && !(item is string))
                    {
                        ret.AddRange(arr.Cast<T>());
                    }
                    else
                    {
                        ret.Add(item.To<T>());
                    }
                }
                return ret.Distinct().ToList();
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// Formats a string using the <paramref name="format" /> and <paramref name="args" />.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns>A string with the format placeholders replaced by the args.</returns>
        public static string Fmt(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        /// <summary>
        /// Froms the UTF8 bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string FromUtf8Bytes(this byte[] bytes)
        {
            return bytes == null ? null
                : bytes.Length > 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF
                    ? Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3)
                    : Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="intVal">The int value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this int intVal)
        {
            return FastToUtf8Bytes(intVal.ToString());
        }

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="longVal">The long value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this long longVal)
        {
            return FastToUtf8Bytes(longVal.ToString());
        }

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="ulongVal">The ulong value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this ulong ulongVal)
        {
            return FastToUtf8Bytes(ulongVal.ToString());
        }

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="doubleVal">The double value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this double doubleVal)
        {
            var doubleStr = doubleVal.ToString(CultureInfo.InvariantCulture.NumberFormat);

            if (doubleStr.IndexOf('E') != -1 || doubleStr.IndexOf('e') != -1)
                doubleStr = DoubleConverter.ToExactString(doubleVal);

            return FastToUtf8Bytes(doubleStr);
        }
        /// <summary>
        /// Skip the encoding process for 'safe strings' 
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        private static byte[] FastToUtf8Bytes(string strVal)
        {
            var bytes = new byte[strVal.Length];
            for (var i = 0; i < strVal.Length; i++)
                bytes[i] = (byte)strVal[i];

            return bytes;
        }
        /// <summary>
        /// Withouts the bom.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string WithoutBom(this string value)
        {
            return value.Length > 0 && value[0] == 65279
                ? value.Substring(1)
                : value;
        }
        /// <summary>
        /// Converts to md5hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string ToMD5Hash(this string input, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            encoding = encoding ?? Encoding.UTF8;
            // copied/pasted by adamfowleruk
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = encoding.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = StringBuilderCache.Allocate();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return StringBuilderCache.ReturnAndFree(sb).ToLower(); // The RFC requires the hex values are lowercase
        }
    }
}