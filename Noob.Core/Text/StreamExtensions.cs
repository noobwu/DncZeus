// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="StreamExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Noob.Memory;
using Noob.Text;
using Noob.Text.Pools;

namespace Noob
{
    /// <summary>
    /// Class StreamExtensions.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Writes to.
        /// </summary>
        /// <param name="inStream">The in stream.</param>
        /// <param name="outStream">The out stream.</param>
        /// <returns>System.Int64.</returns>
        public static long WriteTo(this Stream inStream, Stream outStream)
        {
            if (inStream is MemoryStream memoryStream)
            {
                memoryStream.WriteTo(outStream);
                return memoryStream.Position;
            }

            var data = new byte[4096];
            long total = 0;
            int bytesRead;

            while ((bytesRead = inStream.Read(data, 0, data.Length)) > 0)
            {
                outStream.Write(data, 0, bytesRead);
                total += bytesRead;
            }

            return total;
        }

        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        /// <exception cref="ArgumentNullException">stream</exception>
        public static IEnumerable<string> ReadLines(this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// @jonskeet: Collection of utility methods which operate on streams.
        /// r285, February 26th 2009: http://www.yoda.arachsys.com/csharp/miscutil/
        /// </summary>
        public const int DefaultBufferSize = 8 * 1024;

        /// <summary>
        /// Reads the given stream up to the end, returning the data as a byte array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadFully(this Stream input) => ReadFully(input, DefaultBufferSize);

        /// <summary>
        /// Reads the given stream up to the end, returning the data as a byte
        /// array, using the given buffer size.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentOutOfRangeException">bufferSize</exception>
        public static byte[] ReadFully(this Stream input, int bufferSize)
        {
            if (bufferSize < 1)
                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            byte[] buffer = BufferPool.GetBuffer(bufferSize);
            try
            {
                return ReadFully(input, buffer);
            }
            finally
            {
                BufferPool.ReleaseBufferToPool(ref buffer);
            }
        }

        /// <summary>
        /// Reads the given stream up to the end, returning the data as a byte
        /// array, using the given buffer for transferring data. Note that the
        /// current contents of the buffer is ignored, so the buffer needn't
        /// be cleared beforehand.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentNullException">
        /// buffer
        /// or
        /// input
        /// </exception>
        /// <exception cref="ArgumentException">Buffer has length of 0</exception>
        public static byte[] ReadFully(this Stream input, byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (buffer.Length == 0)
                throw new ArgumentException("Buffer has length of 0");

            // We could do all our own work here, but using MemoryStream is easier
            // and likely to be just as efficient.
            using (var tempStream = MemoryStreamFactory.GetStream())
            {
                CopyTo(input, tempStream, buffer);
                // No need to copy the buffer if it's the right size
                if (tempStream.Length == tempStream.GetBuffer().Length)
                {
                    return tempStream.GetBuffer();
                }
                // Okay, make a copy that's the right size
                return tempStream.ToArray();
            }
        }

        /// <summary>
        /// Reads the given stream up to the end, returning the MemoryStream Buffer as ReadOnlyMemory&lt;byte&gt;.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ReadOnlyMemory&lt;System.Byte&gt;.</returns>
        public static ReadOnlyMemory<byte> ReadFullyAsMemory(this Stream input) => 
            ReadFullyAsMemory(input, DefaultBufferSize);

        /// <summary>
        /// Reads the given stream up to the end, returning the MemoryStream Buffer as ReadOnlyMemory&lt;byte&gt;.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>ReadOnlyMemory&lt;System.Byte&gt;.</returns>
        public static ReadOnlyMemory<byte> ReadFullyAsMemory(this Stream input, int bufferSize)
        {
            byte[] buffer = BufferPool.GetBuffer(bufferSize);
            try
            {
                return ReadFullyAsMemory(input, buffer);
            }
            finally
            {
                BufferPool.ReleaseBufferToPool(ref buffer);
            }
        }

        /// <summary>
        /// Reads the fully as memory.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns>ReadOnlyMemory&lt;System.Byte&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// buffer
        /// or
        /// input
        /// </exception>
        /// <exception cref="ArgumentException">Buffer has length of 0</exception>
        public static ReadOnlyMemory<byte> ReadFullyAsMemory(this Stream input, byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (buffer.Length == 0)
                throw new ArgumentException("Buffer has length of 0");

            var ms = new MemoryStream();
            CopyTo(input, ms, buffer);
            return ms.GetBufferAsMemory();
        }


        /// <summary>
        /// Copies all the data from one stream into another.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns>System.Int64.</returns>
        public static long CopyTo(this Stream input, Stream output)
        {
            return CopyTo(input, output, DefaultBufferSize);
        }

        /// <summary>
        /// Copies all the data from one stream into another, using a buffer
        /// of the given size.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="ArgumentOutOfRangeException">bufferSize</exception>
        public static long CopyTo(this Stream input, Stream output, int bufferSize)
        {
            if (bufferSize < 1)
                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            return CopyTo(input, output, new byte[bufferSize]);
        }

        /// <summary>
        /// Copies all the data from one stream into another, using the given
        /// buffer for transferring data. Note that the current contents of
        /// the buffer is ignored, so the buffer needn't be cleared beforehand.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="ArgumentNullException">
        /// buffer
        /// or
        /// input
        /// or
        /// output
        /// </exception>
        /// <exception cref="ArgumentException">Buffer has length of 0</exception>
        public static long CopyTo(this Stream input, Stream output, byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (buffer.Length == 0)
                throw new ArgumentException("Buffer has length of 0");

            long total = 0;
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
                total += read;
            }
            return total;
        }

        /// <summary>
        /// Reads exactly the given number of bytes from the specified stream.
        /// If the end of the stream is reached before the specified amount
        /// of data is read, an exception is thrown.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="bytesToRead">The bytes to read.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadExactly(this Stream input, int bytesToRead)
        {
            return ReadExactly(input, new byte[bytesToRead]);
        }

        /// <summary>
        /// Reads into a buffer, filling it completely.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadExactly(this Stream input, byte[] buffer)
        {
            return ReadExactly(input, buffer, buffer.Length);
        }

        /// <summary>
        /// Reads exactly the given number of bytes from the specified stream,
        /// into the given buffer, starting at position 0 of the array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bytesToRead">The bytes to read.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadExactly(this Stream input, byte[] buffer, int bytesToRead)
        {
            return ReadExactly(input, buffer, 0, bytesToRead);
        }

        /// <summary>
        /// Reads exactly the given number of bytes from the specified stream,
        /// into the given buffer, starting at position 0 of the array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="bytesToRead">The bytes to read.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentNullException">
        /// input
        /// or
        /// buffer
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// startIndex
        /// or
        /// bytesToRead
        /// </exception>
        public static byte[] ReadExactly(this Stream input, byte[] buffer, int startIndex, int bytesToRead)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (startIndex < 0 || startIndex >= buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (bytesToRead < 1 || startIndex + bytesToRead > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(bytesToRead));

            return ReadExactlyFast(input, buffer, startIndex, bytesToRead);
        }

        /// <summary>
        /// Same as ReadExactly, but without the argument checks.
        /// </summary>
        /// <param name="fromStream">From stream.</param>
        /// <param name="intoBuffer">The into buffer.</param>
        /// <param name="startAtIndex">The start at index.</param>
        /// <param name="bytesToRead">The bytes to read.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="EndOfStreamException">End of stream reached with {bytesToRead - index} byte{(bytesToRead - index == 1 ? "s" : "")} left to read.</exception>
        private static byte[] ReadExactlyFast(Stream fromStream, byte[] intoBuffer, int startAtIndex, int bytesToRead)
        {
            var index = 0;
            while (index < bytesToRead)
            {
                var read = fromStream.Read(intoBuffer, startAtIndex + index, bytesToRead - index);
                if (read == 0)
                    throw new EndOfStreamException
                        ($"End of stream reached with {bytesToRead - index} byte{(bytesToRead - index == 1 ? "s" : "")} left to read.");

                index += read;
            }
            return intoBuffer;
        }

        /// <summary>
        /// Collapses the whitespace.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string CollapseWhitespace(this string str)
        {
            if (str == null)
                return null;

            var sb = StringBuilderThreadStatic.Allocate();
            var lastChar = (char)0;
            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c < 32) continue; // Skip all these
                if (c == 32)
                {
                    if (lastChar == 32)
                        continue; // Only write one space character
                }
                sb.Append(c);
                lastChar = c;
            }

            return StringBuilderThreadStatic.ReturnAndFree(sb);
        }

        /// <summary>
        /// Combines the specified with bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="withBytes">The with bytes.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Combine(this byte[] bytes, params byte[][] withBytes)
        {
            var combinedLength = bytes.Length + withBytes.Sum(b => b.Length);
            var to = new byte[combinedLength];

            Buffer.BlockCopy(bytes, 0, to, 0, bytes.Length);
            var pos = bytes.Length;

            foreach (var b in withBytes)
            {
                Buffer.BlockCopy(b, 0, to, pos, b.Length);
                pos += b.Length;
            }

            return to;
        }

        /// <summary>
        /// The asynchronous buffer size
        /// </summary>
        public static int AsyncBufferSize = 81920; // CopyToAsync() default value

        /// <summary>
        /// Writes the asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task WriteAsync(this Stream stream, ReadOnlyMemory<byte> value, CancellationToken token = default) =>
            NetCoreMemory.Provider.WriteAsync(stream, value, token);

        /// <summary>
        /// Writes the asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="bytes">The bytes.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task WriteAsync(this Stream stream, byte[] bytes, CancellationToken token = default) =>
           NetCoreMemory.Provider.WriteAsync(stream, bytes, token);

        /// <summary>
        /// Copies to asynchronous.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task CopyToAsync(this Stream input, Stream output, CancellationToken token = default) => input.CopyToAsync(output, AsyncBufferSize, token);

        /// <summary>
        /// Writes the asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="text">The text.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task WriteAsync(this Stream stream, string text, CancellationToken token = default) =>
            NetCoreMemory.Provider.WriteAsync(stream, text.AsSpan(), token);

        /// <summary>
        /// Converts to md5hash.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.String.</returns>
        public static string ToMd5Hash(this Stream stream)
        {
            var hash = System.Security.Cryptography.MD5.Create().ComputeHash(stream);
            var sb = StringBuilderCache.Allocate();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return StringBuilderCache.ReturnAndFree(sb);
        }

        /// <summary>
        /// Converts to md5hash.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string ToMd5Hash(this byte[] bytes)
        {
            var hash = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            var sb = StringBuilderCache.Allocate();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return StringBuilderCache.ReturnAndFree(sb);
        }

        /// <summary>
        /// Returns bytes in publiclyVisible MemoryStream
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>MemoryStream.</returns>
        public static MemoryStream InMemoryStream(this byte[] bytes)
        {
            return new MemoryStream(bytes, 0, bytes.Length, writable: true, publiclyVisible: true);
        }

        /// <summary>
        /// Reads to end.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>System.String.</returns>
        public static string ReadToEnd(this MemoryStream ms) => ReadToEnd(ms, Encoding.UTF8);
        /// <summary>
        /// Reads to end.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string ReadToEnd(this MemoryStream ms, Encoding encoding)
        {
            ms.Position = 0;
            try
            {
                var ret = encoding.GetString(ms.GetBuffer(), 0, (int) ms.Length);
                return ret;
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");
                
                using (var reader = new StreamReader(ms, encoding, true, DefaultBufferSize, leaveOpen:true))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Gets the buffer as memory.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>ReadOnlyMemory&lt;System.Byte&gt;.</returns>
        public static ReadOnlyMemory<byte> GetBufferAsMemory(this MemoryStream ms)
        {
            try
            {
                return new ReadOnlyMemory<byte>(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream in GetBufferAsSpan() wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");
                return new ReadOnlyMemory<byte>(ms.ToArray());
            }
        }

        /// <summary>
        /// Gets the buffer as span.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>ReadOnlySpan&lt;System.Byte&gt;.</returns>
        public static ReadOnlySpan<byte> GetBufferAsSpan(this MemoryStream ms)
        {
            try
            {
                return new ReadOnlySpan<byte>(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream in GetBufferAsSpan() wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");
                return new ReadOnlySpan<byte>(ms.ToArray());
            }
        }

        /// <summary>
        /// Gets the buffer as bytes.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBufferAsBytes(this MemoryStream ms)
        {
            try
            {
                return ms.GetBuffer();
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream in GetBufferAsBytes() wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Reads to end asynchronous.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static Task<string> ReadToEndAsync(this MemoryStream ms) => ReadToEndAsync(ms, Encoding.UTF8);
        /// <summary>
        /// Reads to end asynchronous.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static Task<string> ReadToEndAsync(this MemoryStream ms, Encoding encoding)
        {
            ms.Position = 0;
            try
            {
                var ret = encoding.GetString(ms.GetBuffer(), 0, (int) ms.Length);
                return ret.InTask();
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream in ReadToEndAsync() wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");
                
                using (var reader = new StreamReader(ms, encoding, true, DefaultBufferSize, leaveOpen:true))
                {
                    return reader.ReadToEndAsync();
                }
            }
        }

        /// <summary>
        /// Reads to end.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.String.</returns>
        public static string ReadToEnd(this Stream stream) => ReadToEnd(stream, Encoding.UTF8);
        /// <summary>
        /// Reads to end.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string ReadToEnd(this Stream stream, Encoding encoding)
        {
            if (stream is MemoryStream ms)
                return ms.ReadToEnd();

            if (stream.CanSeek)
            {
                stream.Position = 0;
            }
  
            using (var reader = new StreamReader(stream, encoding, true, DefaultBufferSize, leaveOpen:true))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Reads to end asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static Task<string> ReadToEndAsync(this Stream stream) => ReadToEndAsync(stream, Encoding.UTF8);
        /// <summary>
        /// Reads to end asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static Task<string> ReadToEndAsync(this Stream stream, Encoding encoding)
        {
            if (stream is MemoryStream ms)
                return ms.ReadToEndAsync(encoding);

            if (stream.CanSeek)
            {
                stream.Position = 0;
            }
  
            using (var reader = new StreamReader(stream, encoding, true, DefaultBufferSize, leaveOpen:true))
            {
                return reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Writes to asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="output">The output.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public static Task WriteToAsync(this MemoryStream stream, Stream output, CancellationToken token=default(CancellationToken)) => 
            WriteToAsync(stream, output, Encoding.UTF8, token);

        /// <summary>
        /// write to as an asynchronous operation.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="output">The output.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public static async Task WriteToAsync(this MemoryStream stream, Stream output, Encoding encoding, CancellationToken token)
        {
            try
            {
                await output.WriteAsync(stream.GetBuffer(), 0, (int) stream.Length, token);
            }
            catch (UnauthorizedAccessException)
            {
                Tracer.Instance.WriteWarning("MemoryStream in WriteToAsync() wasn't created with a publiclyVisible:true byte[] bufffer, falling back to slow impl");

                var bytes = stream.ToArray();
                await output.WriteAsync(bytes, 0, bytes.Length, token);
            }
        }

        /// <summary>
        /// Writes to asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="output">The output.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public static Task WriteToAsync(this Stream stream, Stream output, CancellationToken token=default(CancellationToken)) => 
            WriteToAsync(stream, output, Encoding.UTF8, token);


        /// <summary>
        /// Writes to asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="output">The output.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public static Task WriteToAsync(this Stream stream, Stream output, Encoding encoding, CancellationToken token)
        {
            if (stream is MemoryStream ms)
                return ms.WriteToAsync(output, encoding, token);
            
            return stream.CopyToAsync(output, token);
        }

        /// <summary>
        /// Copies to new memory stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>MemoryStream.</returns>
        public static MemoryStream CopyToNewMemoryStream(this Stream stream)
        {
            var ms = MemoryStreamFactory.GetStream();
            stream.CopyTo(ms);
            ms.Position = 0;
            return ms;
        }

        /// <summary>
        /// copy to new memory stream as an asynchronous operation.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Task&lt;MemoryStream&gt;.</returns>
        public static async Task<MemoryStream> CopyToNewMemoryStreamAsync(this Stream stream)
        {
            var ms = MemoryStreamFactory.GetStream();
            await stream.CopyToAsync(ms);
            ms.Position = 0;
            return ms;
        }
    }
}