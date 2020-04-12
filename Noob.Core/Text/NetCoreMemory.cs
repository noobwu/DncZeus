// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="NetCoreMemory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Noob.Text;
using Noob.Text.Pools;
using System;
using System.Buffers.Text;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Noob.Extensions;
namespace Noob.Memory
{
    /// <summary>
    /// Class NetCoreMemory. This class cannot be inherited.
    /// </summary>
    public sealed class NetCoreMemory 
    {
        /// <summary>
        /// The provider
        /// </summary>
        private static NetCoreMemory provider;
        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetCoreMemory Provider => provider ?? (provider = new NetCoreMemory());
        /// <summary>
        /// Prevents a default instance of the <see cref="NetCoreMemory"/> class from being created.
        /// </summary>
        private NetCoreMemory() { }


        /// <summary>
        /// Parses the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ParseBoolean(ReadOnlySpan<char> value) => bool.Parse(value);

        /// <summary>
        /// Tries the parse boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryParseBoolean(ReadOnlySpan<char> value, out bool result) =>
            bool.TryParse(value, out result);

        /// <summary>
        /// Tries the parse decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryParseDecimal(ReadOnlySpan<char> value, out decimal result) =>
            decimal.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);

        /// <summary>
        /// Parses the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="allowThousands">if set to <c>true</c> [allow thousands].</param>
        /// <returns>System.Decimal.</returns>
        public decimal ParseDecimal(ReadOnlySpan<char> value, bool allowThousands) =>
            decimal.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        /// <summary>
        /// Tries the parse float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryParseFloat(ReadOnlySpan<char> value, out float result) =>
            float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);

        /// <summary>
        /// Tries the parse double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryParseDouble(ReadOnlySpan<char> value, out double result) =>
            double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);

        /// <summary>
        /// Parses the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Decimal.</returns>
        public decimal ParseDecimal(ReadOnlySpan<char> value) =>
            decimal.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        /// <summary>
        /// Parses the float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public float ParseFloat(ReadOnlySpan<char> value) =>
            float.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        /// <summary>
        /// Parses the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Double.</returns>
        public double ParseDouble(ReadOnlySpan<char> value) =>
            double.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        /// <summary>
        /// Parses the s byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.SByte.</returns>
        public sbyte ParseSByte(ReadOnlySpan<char> value) => sbyte.Parse(value);

        /// <summary>
        /// Parses the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte.</returns>
        public byte ParseByte(ReadOnlySpan<char> value) => byte.Parse(value);

        /// <summary>
        /// Parses the int16.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int16.</returns>
        public short ParseInt16(ReadOnlySpan<char> value) => short.Parse(value);

        /// <summary>
        /// Parses the u int16.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.UInt16.</returns>
        public ushort ParseUInt16(ReadOnlySpan<char> value) => ushort.Parse(value);

        /// <summary>
        /// Parses the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public int ParseInt32(ReadOnlySpan<char> value) => int.Parse(value);

        /// <summary>
        /// Parses the u int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.UInt32.</returns>
        public uint ParseUInt32(ReadOnlySpan<char> value) => uint.Parse(value);

        /// <summary>
        /// Parses the u int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="style">The style.</param>
        /// <returns>System.UInt32.</returns>
        public uint ParseUInt32(ReadOnlySpan<char> value, NumberStyles style) => uint.Parse(value.ToString(), NumberStyles.HexNumber);

        /// <summary>
        /// Parses the int64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int64.</returns>
        public long ParseInt64(ReadOnlySpan<char> value) => long.Parse(value);

        /// <summary>
        /// Parses the u int64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.UInt64.</returns>
        public ulong ParseUInt64(ReadOnlySpan<char> value) => ulong.Parse(value);

        /// <summary>
        /// Parses the unique identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Guid.</returns>
        public Guid ParseGuid(ReadOnlySpan<char> value) => Guid.Parse(value);

        /// <summary>
        /// Parses the base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] ParseBase64(ReadOnlySpan<char> value)
        {
            byte[] bytes = BufferPool.GetBuffer(Base64.GetMaxDecodedFromUtf8Length(value.Length));
            try
            {
                if (Convert.TryFromBase64Chars(value, bytes, out var bytesWritten))
                {
                    var ret = new byte[bytesWritten];
                    Buffer.BlockCopy(bytes, 0, ret, 0, bytesWritten);
                    return ret;
                }
                else
                {
                    var chars = value.ToArray();
                    return Convert.FromBase64CharArray(chars, 0, chars.Length);
                }
            }
            finally 
            {
                BufferPool.ReleaseBufferToPool(ref bytes);
            }
        }

        /// <summary>
        /// Converts to base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string ToBase64(ReadOnlyMemory<byte> value)
        {
            return Convert.ToBase64String(value.Span);
        }

        /// <summary>
        /// Writes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        public void Write(Stream stream, ReadOnlyMemory<char> value)
        {
            var utf8 = ToUtf8(value.Span);
            if (stream is MemoryStream ms)
                ms.Write(utf8.Span);
            else
                stream.Write(utf8.Span);
        }

        /// <summary>
        /// Writes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        public void Write(Stream stream, ReadOnlyMemory<byte> value)
        {
            if (stream is MemoryStream ms)
                ms.Write(value.Span);
            else
                stream.Write(value.Span);
        }

        /// <summary>
        /// Writes the asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public Task WriteAsync(Stream stream, ReadOnlyMemory<char> value, CancellationToken token = default) =>
            WriteAsync(stream, value.Span, token);

        /// <summary>
        /// Writes the asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public Task WriteAsync(Stream stream, ReadOnlySpan<char> value, CancellationToken token=default)
        {
            var utf8 = ToUtf8(value);
            if (stream is MemoryStream ms)
                ms.Write(utf8.Span);
            else
                return Task.FromResult(stream.WriteAsync(utf8, token));
            
            return TypeConstants.EmptyTask;
        }

        /// <summary>
        /// write as an asynchronous operation.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public async Task WriteAsync(Stream stream, ReadOnlyMemory<byte> value, CancellationToken token = default)
        {
            if (stream is MemoryStream ms)
                ms.Write(value.Span);
            else
                await stream.WriteAsync(value, token);
        }

        /// <summary>
        /// Appends the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <returns>StringBuilder.</returns>
        public StringBuilder Append(StringBuilder sb, ReadOnlySpan<char> value)
        {
            return sb.Append(value);
        }

        /// <summary>
        /// Gets the UTF8 character count.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Int32.</returns>
        public int GetUtf8CharCount(ReadOnlySpan<byte> bytes) => Encoding.UTF8.GetCharCount(bytes);

        /// <summary>
        /// Gets the UTF8 byte count.
        /// </summary>
        /// <param name="chars">The chars.</param>
        /// <returns>System.Int32.</returns>
        public int GetUtf8ByteCount(ReadOnlySpan<char> chars) => Encoding.UTF8.GetByteCount(chars);

        /// <summary>
        /// Converts to utf8.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>ReadOnlyMemory&lt;System.Byte&gt;.</returns>
        public ReadOnlyMemory<byte> ToUtf8(ReadOnlySpan<char> source)
        {
            Memory<byte> bytes = new byte[Encoding.UTF8.GetByteCount(source)];
            var bytesWritten = Encoding.UTF8.GetBytes(source, bytes.Span);
            return bytes.Slice(0, bytesWritten);
        }

        /// <summary>
        /// Froms the UTF8.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>ReadOnlyMemory&lt;System.Char&gt;.</returns>
        public ReadOnlyMemory<char> FromUtf8(ReadOnlySpan<byte> source)
        {
            source = source.WithoutBom();
            Memory<char> chars = new char[Encoding.UTF8.GetCharCount(source)];
            var charsWritten = Encoding.UTF8.GetChars(source, chars.Span);
            return chars.Slice(0, charsWritten);
        }

        /// <summary>
        /// Converts to utf8.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>System.Int32.</returns>
        public int ToUtf8(ReadOnlySpan<char> source, Span<byte> destination) => Encoding.UTF8.GetBytes(source, destination);

        /// <summary>
        /// Froms the UTF8.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>System.Int32.</returns>
        public int FromUtf8(ReadOnlySpan<byte> source, Span<char> destination) => Encoding.UTF8.GetChars(source.WithoutBom(), destination);

        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] ToUtf8Bytes(ReadOnlySpan<char> source) => ToUtf8(source).ToArray();

        /// <summary>
        /// Froms the UTF8 bytes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        public string FromUtf8Bytes(ReadOnlySpan<byte> source) => FromUtf8(source.WithoutBom()).ToString();

        /// <summary>
        /// Converts to memorystream.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>MemoryStream.</returns>
        public MemoryStream ToMemoryStream(ReadOnlySpan<byte> source)
        {
            var ms = MemoryStreamFactory.GetStream(source.Length);
            ms.Write(source);
            return ms;
        }
    }    
}
