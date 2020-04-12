// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="CryptUtils.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Noob.Text;
namespace Noob
{
    /// <summary>
    /// Enum RsaKeyLengths
    /// </summary>
    public enum RsaKeyLengths
    {
        /// <summary>
        /// The bit1024
        /// </summary>
        Bit1024 = 1024,
        /// <summary>
        /// The bit2048
        /// </summary>
        Bit2048 = 2048,
        /// <summary>
        /// The bit4096
        /// </summary>
        Bit4096 = 4096
    }

    /// <summary>
    /// Class RsaKeyPair.
    /// </summary>
    public class RsaKeyPair
    {
        /// <summary>
        /// Gets or sets the private key.
        /// </summary>
        /// <value>The private key.</value>
        public string PrivateKey { get; set; }
        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        /// <value>The public key.</value>
        public string PublicKey { get; set; }
    }

    /// <summary>
    /// Useful .NET Encryption Utils from:
    /// https://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider(v=vs.110).aspx
    /// </summary>
    public static class RsaUtils
    {
        /// <summary>
        /// The key length
        /// </summary>
        public static RsaKeyLengths KeyLength = RsaKeyLengths.Bit2048;
        /// <summary>
        /// The default key pair
        /// </summary>
        public static RsaKeyPair DefaultKeyPair;
        /// <summary>
        /// The do oaep padding
        /// </summary>
        public static bool DoOAEPPadding = true;

        /// <summary>
        /// Creates the RSA.
        /// </summary>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>RSA.</returns>
        private static RSA CreateRsa(RsaKeyLengths rsaKeyLength)
        {
            var rsa = RSA.Create();
            rsa.KeySize = (int)rsaKeyLength;
            return rsa;
        }

        /// <summary>
        /// Creates the public and private key pair.
        /// </summary>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>RsaKeyPair.</returns>
        public static RsaKeyPair CreatePublicAndPrivateKeyPair(RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                return new RsaKeyPair
                {
                    PrivateKey = rsa.ToXml(includePrivateParameters: true),
                    PublicKey = rsa.ToXml(includePrivateParameters: false),
                };
            }
        }

        /// <summary>
        /// Creates the private key parameters.
        /// </summary>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>RSAParameters.</returns>
        public static RSAParameters CreatePrivateKeyParams(RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                return rsa.ExportParameters(includePrivateParameters: true);
            }
        }

        /// <summary>
        /// Froms the private RSA parameters.
        /// </summary>
        /// <param name="privateKey">The private key.</param>
        /// <returns>System.String.</returns>
        public static string FromPrivateRSAParameters(this RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.ToXml(includePrivateParameters: true);
            }
        }

        /// <summary>
        /// Froms the public RSA parameters.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        /// <returns>System.String.</returns>
        public static string FromPublicRSAParameters(this RSAParameters publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                return rsa.ToXml(includePrivateParameters: false);
            }
        }

        /// <summary>
        /// Converts to privatersaparameters.
        /// </summary>
        /// <param name="privateKeyXml">The private key XML.</param>
        /// <returns>RSAParameters.</returns>
        public static RSAParameters ToPrivateRSAParameters(this string privateKeyXml)
        {
            using (var rsa = RSA.Create())
            {
                rsa.FromXml(privateKeyXml);
                return rsa.ExportParameters(includePrivateParameters: true);
            }
        }

        /// <summary>
        /// Converts to publicrsaparameters.
        /// </summary>
        /// <param name="publicKeyXml">The public key XML.</param>
        /// <returns>RSAParameters.</returns>
        public static RSAParameters ToPublicRSAParameters(this string publicKeyXml)
        {
            using (var rsa = RSA.Create())
            {
                rsa.FromXml(publicKeyXml);
                return rsa.ExportParameters(includePrivateParameters: false);
            }
        }

        /// <summary>
        /// Converts to publickeyxml.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        /// <returns>System.String.</returns>
        public static string ToPublicKeyXml(this RSAParameters publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                return rsa.ToXml(includePrivateParameters: false);
            }
        }

        /// <summary>
        /// Converts to publicrsaparameters.
        /// </summary>
        /// <param name="privateKey">The private key.</param>
        /// <returns>RSAParameters.</returns>
        public static RSAParameters ToPublicRsaParameters(this RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.ExportParameters(includePrivateParameters: false);
            }
        }

        /// <summary>
        /// Converts to privatekeyxml.
        /// </summary>
        /// <param name="privateKey">The private key.</param>
        /// <returns>System.String.</returns>
        public static string ToPrivateKeyXml(this RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.ToXml(includePrivateParameters: true);
            }
        }

        /// <summary>
        /// Encrypts the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">DefaultKeyPair - No KeyPair given for encryption in CryptUtils</exception>
        public static string Encrypt(this string text)
        {
            if (DefaultKeyPair != null)
                return Encrypt(text, DefaultKeyPair.PublicKey, KeyLength);

            throw new ArgumentNullException("DefaultKeyPair", "No KeyPair given for encryption in CryptUtils");
        }

        /// <summary>
        /// Decrypts the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">DefaultKeyPair - No KeyPair given for encryption in CryptUtils</exception>
        public static string Decrypt(this string text)
        {
            if (DefaultKeyPair != null)
                return Decrypt(text, DefaultKeyPair.PrivateKey, KeyLength);
            else
                throw new ArgumentNullException("DefaultKeyPair", "No KeyPair given for encryption in CryptUtils");
        }

        /// <summary>
        /// Encrypts the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="publicKeyXml">The public key XML.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(string text, string publicKeyXml, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var encryptedBytes = Encrypt(bytes, publicKeyXml, rsaKeyLength);
            string encryptedData = Convert.ToBase64String(encryptedBytes);
            return encryptedData;
        }

        /// <summary>
        /// Encrypts the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="publicKey">The public key.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(string text, RSAParameters publicKey, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var encryptedBytes = Encrypt(bytes, publicKey, rsaKeyLength);
            string encryptedData = Convert.ToBase64String(encryptedBytes);
            return encryptedData;
        }

        /// <summary>
        /// Encrypts the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="publicKeyXml">The public key XML.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Encrypt(byte[] bytes, string publicKeyXml, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.FromXml(publicKeyXml);
                return rsa.Encrypt(bytes);
            }
        }

        /// <summary>
        /// Encrypts the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="publicKey">The public key.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Encrypt(byte[] bytes, RSAParameters publicKey, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(bytes);
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="privateKeyXml">The private key XML.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.String.</returns>
        public static string Decrypt(string encryptedText, string privateKeyXml, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var bytes = Decrypt(encryptedBytes, privateKeyXml, rsaKeyLength);
            var data = Encoding.UTF8.GetString(bytes);
            return data;
        }

        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="privateKey">The private key.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.String.</returns>
        public static string Decrypt(string encryptedText, RSAParameters privateKey, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var bytes = Decrypt(encryptedBytes, privateKey, rsaKeyLength);
            var data = Encoding.UTF8.GetString(bytes);
            return data;
        }

        /// <summary>
        /// Decrypts the specified encrypted bytes.
        /// </summary>
        /// <param name="encryptedBytes">The encrypted bytes.</param>
        /// <param name="privateKeyXml">The private key XML.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Decrypt(byte[] encryptedBytes, string privateKeyXml, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.FromXml(privateKeyXml);
                byte[] bytes = rsa.Decrypt(encryptedBytes);
                return bytes;
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted bytes.
        /// </summary>
        /// <param name="encryptedBytes">The encrypted bytes.</param>
        /// <param name="privateKey">The private key.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Decrypt(byte[] encryptedBytes, RSAParameters privateKey, RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.ImportParameters(privateKey);
                byte[] bytes = rsa.Decrypt(encryptedBytes);
                return bytes;
            }
        }

        /// <summary>
        /// Authenticates the specified data to sign.
        /// </summary>
        /// <param name="dataToSign">The data to sign.</param>
        /// <param name="privateKey">The private key.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Authenticate(byte[] dataToSign, RSAParameters privateKey, string hashAlgorithm = "SHA512", RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.ImportParameters(privateKey);

                //.NET 4.5 doesn't let you specify padding, defaults to PKCS#1 v1.5 padding
                var signature = rsa.SignData(dataToSign, hashAlgorithm);
                return signature;
            }
        }

        /// <summary>
        /// Verifies the specified data to verify.
        /// </summary>
        /// <param name="dataToVerify">The data to verify.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="publicKey">The public key.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="rsaKeyLength">Length of the RSA key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Verify(byte[] dataToVerify, byte[] signature, RSAParameters publicKey, string hashAlgorithm = "SHA512", RsaKeyLengths rsaKeyLength = RsaKeyLengths.Bit2048)
        {
            using (var rsa = CreateRsa(rsaKeyLength))
            {
                rsa.ImportParameters(publicKey);
                var verified = rsa.VerifyData(dataToVerify, signature, hashAlgorithm);
                return verified;
            }
        }
    }
    /// <summary>
    /// Class HashUtils.
    /// </summary>
    public static class HashUtils
    {
        /// <summary>
        /// Gets the hash algorithm.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns>HashAlgorithm.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public static HashAlgorithm GetHashAlgorithm(string hashAlgorithm)
        {
            switch (hashAlgorithm)
            {
                case "SHA1":
                    return SHA1.Create();
                case "SHA256":
                    return SHA256.Create();
                case "SHA512":
                    return SHA512.Create();
                default:
                    throw new NotSupportedException(hashAlgorithm);
            }
        }
    }
    /// <summary>
    /// Class AesUtils.
    /// </summary>
    public static class AesUtils
    {
        /// <summary>
        /// The key size
        /// </summary>
        public const int KeySize = 256;
        /// <summary>
        /// The key size bytes
        /// </summary>
        public const int KeySizeBytes = 256 / 8;
        /// <summary>
        /// The block size
        /// </summary>
        public const int BlockSize = 128;
        /// <summary>
        /// The block size bytes
        /// </summary>
        public const int BlockSizeBytes = 128 / 8;

        /// <summary>
        /// Creates the symmetric algorithm.
        /// </summary>
        /// <returns>SymmetricAlgorithm.</returns>
        public static SymmetricAlgorithm CreateSymmetricAlgorithm()
        {
            var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.BlockSize = BlockSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }

        /// <summary>
        /// Creates the key.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        public static byte[] CreateKey()
        {
            using (var aes = CreateSymmetricAlgorithm())
            {
                return aes.Key;
            }
        }

        /// <summary>
        /// Creates the iv.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        public static byte[] CreateIv()
        {
            using (var aes = CreateSymmetricAlgorithm())
            {
                return aes.IV;
            }
        }

        /// <summary>
        /// Creates the key and iv.
        /// </summary>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="iv">The iv.</param>
        public static void CreateKeyAndIv(out byte[] cryptKey, out byte[] iv)
        {
            using (var aes = CreateSymmetricAlgorithm())
            {
                cryptKey = aes.Key;
                iv = aes.IV;
            }
        }

        /// <summary>
        /// Creates the crypt authentication keys and iv.
        /// </summary>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The authentication key.</param>
        /// <param name="iv">The iv.</param>
        public static void CreateCryptAuthKeysAndIv(out byte[] cryptKey, out byte[] authKey, out byte[] iv)
        {
            using (var aes = CreateSymmetricAlgorithm())
            {
                cryptKey = aes.Key;
                iv = aes.IV;
            }
            using (var aes = CreateSymmetricAlgorithm())
            {
                authKey = aes.Key;
            }
        }

        /// <summary>
        /// Encrypts the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(string text, byte[] cryptKey, byte[] iv)
        {
            var encBytes = Encrypt(text.ToUtf8Bytes(), cryptKey, iv);
            return Convert.ToBase64String(encBytes);
        }

        /// <summary>
        /// Encrypts the specified bytes to encrypt.
        /// </summary>
        /// <param name="bytesToEncrypt">The bytes to encrypt.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Encrypt(byte[] bytesToEncrypt, byte[] cryptKey, byte[] iv)
        {
            using (var aes = CreateSymmetricAlgorithm())
            using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
            using (var cipherStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                using (var binaryWriter = new BinaryWriter(cryptoStream))
                {
                    binaryWriter.Write(bytesToEncrypt);
                }
                return cipherStream.ToArray();
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted base64.
        /// </summary>
        /// <param name="encryptedBase64">The encrypted base64.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns>System.String.</returns>
        public static string Decrypt(string encryptedBase64, byte[] cryptKey, byte[] iv)
        {
            var bytes = Decrypt(Convert.FromBase64String(encryptedBase64), cryptKey, iv);
            return bytes.FromUtf8Bytes();
        }

        /// <summary>
        /// Decrypts the specified encrypted bytes.
        /// </summary>
        /// <param name="encryptedBytes">The encrypted bytes.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Decrypt(byte[] encryptedBytes, byte[] cryptKey, byte[] iv)
        {
            using (var aes = CreateSymmetricAlgorithm())
            using (var decryptor = aes.CreateDecryptor(cryptKey, iv))
            using (var ms = MemoryStreamFactory.GetStream(encryptedBytes))
            using (var cryptStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                return cryptStream.ReadFully();
            }
        }
    }
    /*
 * Original Source:
 * This work (Modern Encryption of a String C#, by James Tuley), 
 * identified by James Tuley, is free of known copyright restrictions.
 * https://gist.github.com/4336842
 * http://creativecommons.org/publicdomain/mark/1.0/ 
 */
    /// <summary>
    /// Class HmacUtils.
    /// </summary>
    public static class HmacUtils
    {
        /// <summary>
        /// The key size
        /// </summary>
        public const int KeySize = 256;
        /// <summary>
        /// The key size bytes
        /// </summary>
        public const int KeySizeBytes = 256 / 8;

        /// <summary>
        /// Creates the hash algorithm.
        /// </summary>
        /// <param name="authKey">The authentication key.</param>
        /// <returns>HMAC.</returns>
        public static HMAC CreateHashAlgorithm(byte[] authKey)
        {
            return new HMACSHA256(authKey);
        }

        /// <summary>
        /// Authenticates the specified encrypted bytes.
        /// </summary>
        /// <param name="encryptedBytes">The encrypted bytes.</param>
        /// <param name="authKey">The authentication key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Authenticate(byte[] encryptedBytes, byte[] authKey, byte[] iv)
        {
            using (var hmac = CreateHashAlgorithm(authKey))
            using (var ms = MemoryStreamFactory.GetStream())
            {
                using (var writer = new BinaryWriter(ms))
                {
                    //Prepend IV
                    writer.Write(iv);
                    //Write Ciphertext
                    writer.Write(encryptedBytes);
                    writer.Flush();

                    //Authenticate all data
                    var tag = hmac.ComputeHash(ms.GetBuffer(), 0, (int)ms.Length);
                    //Postpend tag
                    writer.Write(tag);

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Verifies the specified authentication encrypted bytes.
        /// </summary>
        /// <param name="authEncryptedBytes">The authentication encrypted bytes.</param>
        /// <param name="authKey">The authentication key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException">
        /// AuthKey needs to be {KeySize} bits - authKey
        /// or
        /// Encrypted Message Required! - authEncryptedBytes
        /// </exception>
        public static bool Verify(byte[] authEncryptedBytes, byte[] authKey)
        {
            if (authKey == null || authKey.Length != KeySizeBytes)
                throw new ArgumentException($"AuthKey needs to be {KeySize} bits", nameof(authKey));

            if (authEncryptedBytes == null || authEncryptedBytes.Length == 0)
                throw new ArgumentException("Encrypted Message Required!", nameof(authEncryptedBytes));

            using (var hmac = CreateHashAlgorithm(authKey))
            {
                var sentTag = new byte[KeySizeBytes];
                //Calculate Tag
                var calcTag = hmac.ComputeHash(authEncryptedBytes, 0, authEncryptedBytes.Length - sentTag.Length);
                const int ivLength = AesUtils.BlockSizeBytes;

                //return false if message length is too small
                if (authEncryptedBytes.Length < sentTag.Length + ivLength)
                    return false;

                //Grab Sent Tag
                Buffer.BlockCopy(authEncryptedBytes, authEncryptedBytes.Length - sentTag.Length, sentTag, 0, sentTag.Length);

                //Compare Tag with constant time comparison
                var compare = 0;
                for (var i = 0; i < sentTag.Length; i++)
                    compare |= sentTag[i] ^ calcTag[i];

                //return false if message doesn't authenticate
                if (compare != 0)
                    return false;
            }

            return true; //Haz Success!
        }

        /// <summary>
        /// Decrypts the authenticated.
        /// </summary>
        /// <param name="authEncryptedBytes">The authentication encrypted bytes.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentException">CryptKey needs to be {KeySize} bits - cryptKey</exception>
        public static byte[] DecryptAuthenticated(byte[] authEncryptedBytes, byte[] cryptKey)
        {
            if (cryptKey == null || cryptKey.Length != KeySizeBytes)
                throw new ArgumentException($"CryptKey needs to be {KeySize} bits", nameof(cryptKey));

            //Grab IV from message
            var iv = new byte[AesUtils.BlockSizeBytes];
            Buffer.BlockCopy(authEncryptedBytes, 0, iv, 0, iv.Length);

            using (var aes = AesUtils.CreateSymmetricAlgorithm())
            {
                using (var decrypter = aes.CreateDecryptor(cryptKey, iv))
                using (var decryptedStream = new MemoryStream())
                {
                    using (var decrypterStream = new CryptoStream(decryptedStream, decrypter, CryptoStreamMode.Write))
                    using (var writer = new BinaryWriter(decrypterStream))
                    {
                        //Decrypt Cipher Text from Message
                        writer.Write(
                            authEncryptedBytes,
                            iv.Length,
                            authEncryptedBytes.Length - iv.Length - KeySizeBytes);
                    }

                    return decryptedStream.ToArray();
                }
            }
        }
    }

    /// <summary>
    /// Class PlatformRsaUtils.
    /// </summary>
    public static class PlatformRsaUtils
    {

        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="xml">The XML.</param>
        public static void FromXml(this RSA rsa, string xml)
        {
            //Throws PlatformNotSupportedException
            var csp = ExtractFromXml(xml);
            rsa.ImportParameters(csp);
        }

        /// <summary>
        /// Converts to xml.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="includePrivateParameters">if set to <c>true</c> [include private parameters].</param>
        /// <returns>System.String.</returns>
        public static string ToXml(this RSA rsa, bool includePrivateParameters)
        {
            return ExportToXml(rsa.ExportParameters(includePrivateParameters), includePrivateParameters);
        }
        /// <summary>
        /// Converts to hashalgorithmname.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns>HashAlgorithmName.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HashAlgorithmName ToHashAlgorithmName(string hashAlgorithm)
        {
            switch (hashAlgorithm.ToUpper())
            {
                case "MD5":
                    return HashAlgorithmName.MD5;
                case "SHA1":
                    return HashAlgorithmName.SHA1;
                case "SHA256":
                    return HashAlgorithmName.SHA256;
                case "SHA384":
                    return HashAlgorithmName.SHA384;
                case "SHA512":
                    return HashAlgorithmName.SHA512;
                default:
                    throw new NotImplementedException(hashAlgorithm);
            }
        }
        /// <summary>
        /// Encrypts the specified bytes.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Encrypt(this RSA rsa, byte[] bytes)
        {
            return rsa.Encrypt(bytes, RSAEncryptionPadding.OaepSHA1);
        }
        /// <summary>
        /// Decrypts the specified bytes.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Decrypt(this RSA rsa, byte[] bytes)
        {
            return rsa.Decrypt(bytes, RSAEncryptionPadding.OaepSHA1);
        }
        /// <summary>
        /// Signs the data.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="bytes">The bytes.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] SignData(this RSA rsa, byte[] bytes, string hashAlgorithm)
        {
            return rsa.SignData(bytes, ToHashAlgorithmName(hashAlgorithm), RSASignaturePadding.Pkcs1);
        }

        /// <summary>
        /// Verifies the data.
        /// </summary>
        /// <param name="rsa">The RSA.</param>
        /// <param name="bytes">The bytes.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool VerifyData(this RSA rsa, byte[] bytes, byte[] signature, string hashAlgorithm)
        {
            return rsa.VerifyData(bytes, signature, ToHashAlgorithmName(hashAlgorithm), RSASignaturePadding.Pkcs1);
        }
        /// <summary>
        /// Extracts from XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>RSAParameters.</returns>
        public static RSAParameters ExtractFromXml(string xml)
        {
            var csp = new RSAParameters();
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;

                    var elName = reader.Name;
                    if (elName == "RSAKeyValue")
                        continue;

                    do
                    {
                        reader.Read();
                    } while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement);

                    if (reader.NodeType == XmlNodeType.EndElement)
                        continue;

                    var value = reader.Value;
                    switch (elName)
                    {
                        case "Modulus":
                            csp.Modulus = Convert.FromBase64String(value);
                            break;
                        case "Exponent":
                            csp.Exponent = Convert.FromBase64String(value);
                            break;
                        case "P":
                            csp.P = Convert.FromBase64String(value);
                            break;
                        case "Q":
                            csp.Q = Convert.FromBase64String(value);
                            break;
                        case "DP":
                            csp.DP = Convert.FromBase64String(value);
                            break;
                        case "DQ":
                            csp.DQ = Convert.FromBase64String(value);
                            break;
                        case "InverseQ":
                            csp.InverseQ = Convert.FromBase64String(value);
                            break;
                        case "D":
                            csp.D = Convert.FromBase64String(value);
                            break;
                    }
                }

                return csp;
            }
        }
        /// <summary>
        /// Exports to XML.
        /// </summary>
        /// <param name="csp">The CSP.</param>
        /// <param name="includePrivateParameters">if set to <c>true</c> [include private parameters].</param>
        /// <returns>System.String.</returns>
        public static string ExportToXml(RSAParameters csp, bool includePrivateParameters)
        {
            var sb = StringBuilderCache.Allocate();
            sb.Append("<RSAKeyValue>");

            sb.Append("<Modulus>").Append(Convert.ToBase64String(csp.Modulus)).Append("</Modulus>");
            sb.Append("<Exponent>").Append(Convert.ToBase64String(csp.Exponent)).Append("</Exponent>");

            if (includePrivateParameters)
            {
                sb.Append("<P>").Append(Convert.ToBase64String(csp.P)).Append("</P>");
                sb.Append("<Q>").Append(Convert.ToBase64String(csp.Q)).Append("</Q>");
                sb.Append("<DP>").Append(Convert.ToBase64String(csp.DP)).Append("</DP>");
                sb.Append("<DQ>").Append(Convert.ToBase64String(csp.DQ)).Append("</DQ>");
                sb.Append("<InverseQ>").Append(Convert.ToBase64String(csp.InverseQ)).Append("</InverseQ>");
                sb.Append("<D>").Append(Convert.ToBase64String(csp.D)).Append("</D>");
            }

            sb.Append("</RSAKeyValue>");
            var xml = StringBuilderCache.ReturnAndFree(sb);
            return xml;
        }
    }
}
