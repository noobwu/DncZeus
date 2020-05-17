// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="NewtonsoftJsonSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Noob.DependencyInjection;

namespace Noob.Json.Newtonsoft
{
    /// <summary>
    /// Class NewtonsoftJsonSerializer.
    /// Implements the <see cref="Noob.Json.IJsonSerializer" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Json.IJsonSerializer" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class NewtonsoftJsonSerializer : IJsonSerializer, ITransientDependency
    {
        /// <summary>
        /// The date time converter
        /// </summary>
        private readonly JsonIsoDateTimeConverter _dateTimeConverter;

        /// <summary>
        /// The shared camel case except dictionary keys resolver
        /// </summary>
        private static readonly CamelCaseExceptDictionaryKeysResolver SharedCamelCaseExceptDictionaryKeysResolver =
            new CamelCaseExceptDictionaryKeysResolver();

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonSerializer"/> class.
        /// </summary>
        /// <param name="dateTimeConverter">The date time converter.</param>
        public NewtonsoftJsonSerializer(JsonIsoDateTimeConverter dateTimeConverter)
        {
            _dateTimeConverter = dateTimeConverter;
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <param name="indented">if set to <c>true</c> [indented].</param>
        /// <returns>System.String.</returns>
        public string Serialize(object obj, bool camelCase = true, bool indented = false)
        {
            return JsonConvert.SerializeObject(obj, CreateSerializerSettings(camelCase, indented));
        }

        /// <summary>
        /// Deserializes the specified json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <returns>T.</returns>
        public T Deserialize<T>(string jsonString, bool camelCase = true)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, CreateSerializerSettings(camelCase));
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="jsonString">The json string.</param>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <returns>System.Object.</returns>
        public object Deserialize(Type type, string jsonString, bool camelCase = true)
        {
            return JsonConvert.DeserializeObject(jsonString, type, CreateSerializerSettings(camelCase));
        }

        /// <summary>
        /// Creates the serializer settings.
        /// </summary>
        /// <param name="camelCase">if set to <c>true</c> [camel case].</param>
        /// <param name="indented">if set to <c>true</c> [indented].</param>
        /// <returns>JsonSerializerSettings.</returns>
        protected virtual JsonSerializerSettings CreateSerializerSettings(bool camelCase = true, bool indented = false)
        {
            var settings = new JsonSerializerSettings();

            settings.Converters.Insert(0, _dateTimeConverter);
            
            if (camelCase)
            {
                settings.ContractResolver = SharedCamelCaseExceptDictionaryKeysResolver;
            }

            if (indented)
            {
                settings.Formatting = Formatting.Indented;
            }
            
            return settings;
        }

        /// <summary>
        /// Class CamelCaseExceptDictionaryKeysResolver.
        /// Implements the <see cref="Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" />
        /// </summary>
        /// <seealso cref="Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" />
        private class CamelCaseExceptDictionaryKeysResolver : CamelCasePropertyNamesContractResolver
        {
            /// <summary>
            /// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonDictionaryContract" /> for the given type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>A <see cref="T:Newtonsoft.Json.Serialization.JsonDictionaryContract" /> for the given type.</returns>
            protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
            {
                var contract = base.CreateDictionaryContract(objectType);

                contract.DictionaryKeyResolver = propertyName => propertyName;

                return contract;
            }
        }
    }
}