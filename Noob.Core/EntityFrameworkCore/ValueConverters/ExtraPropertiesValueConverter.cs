// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="ExtraPropertiesValueConverter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Noob.ObjectExtending;

namespace Noob.EntityFrameworkCore.ValueConverters
{
    /// <summary>
    /// Class ExtraPropertiesValueConverter.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter{System.Collections.Generic.Dictionary{System.String, System.Object}, System.String}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter{System.Collections.Generic.Dictionary{System.String, System.Object}, System.String}" />
    public class ExtraPropertiesValueConverter : ValueConverter<Dictionary<string, object>, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraPropertiesValueConverter"/> class.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        public ExtraPropertiesValueConverter(Type entityType)
            : base(
                d => SerializeObject(d, entityType),
                s => DeserializeObject(s))
        {

        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="extraProperties">The extra properties.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>System.String.</returns>
        private static string SerializeObject(Dictionary<string, object> extraProperties, Type entityType)
        {
            var copyDictionary = new Dictionary<string, object>(extraProperties);

            if (entityType != null)
            {
                var objectExtension = ObjectExtensionManager.Instance.GetOrNull(entityType);
                if (objectExtension != null)
                {
                    foreach (var property in objectExtension.GetProperties())
                    {
                        if (property.IsMappedToFieldForEfCore())
                        {
                            copyDictionary.Remove(property.Name);
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(copyDictionary, Formatting.None);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="extraPropertiesAsJson">The extra properties as json.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        private static Dictionary<string, object> DeserializeObject(string extraPropertiesAsJson)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(extraPropertiesAsJson);
        }
    }
}