// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="JsonValueConverter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Noob.Data;

namespace Noob.EntityFrameworkCore.ValueConverters
{
    /// <summary>
    /// Class JsonValueConverter.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter{TPropertyType, System.String}" />
    /// </summary>
    /// <typeparam name="TPropertyType">The type of the t property type.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter{TPropertyType, System.String}" />
    public class JsonValueConverter<TPropertyType> : ValueConverter<TPropertyType, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonValueConverter{TPropertyType}"/> class.
        /// </summary>
        public JsonValueConverter()
            : base(
                d => SerializeObject(d),
                s => DeserializeObject(s))
        {

        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns>System.String.</returns>
        private static string SerializeObject(TPropertyType d)
        {
            return JsonConvert.SerializeObject(d, Formatting.None);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>TPropertyType.</returns>
        private static TPropertyType DeserializeObject(string s)
        {
            return JsonConvert.DeserializeObject<TPropertyType>(s);
        }
    }
}
