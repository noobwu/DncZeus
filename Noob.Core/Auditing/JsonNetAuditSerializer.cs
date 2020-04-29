// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="JsonNetAuditSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Noob.DependencyInjection;

namespace Noob.Auditing
{
    //TODO: Rename to JsonAuditSerializer
    /// <summary>
    /// Class JsonNetAuditSerializer.
    /// Implements the <see cref="Noob.IAuditSerializer" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.IAuditSerializer" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class JsonNetAuditSerializer : IAuditSerializer, ITransientDependency
    {
        /// <summary>
        /// The options
        /// </summary>
        protected AuditingOptions Options;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetAuditSerializer"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public JsonNetAuditSerializer(IOptions<AuditingOptions> options)
        {
            Options = options.Value;
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, GetSharedJsonSerializerSettings());
        }

        /// <summary>
        /// The synchronize object
        /// </summary>
        private static readonly object SyncObj = new object();
        /// <summary>
        /// The shared json serializer settings
        /// </summary>
        private static JsonSerializerSettings _sharedJsonSerializerSettings;

        /// <summary>
        /// Gets the shared json serializer settings.
        /// </summary>
        /// <returns>JsonSerializerSettings.</returns>
        private JsonSerializerSettings GetSharedJsonSerializerSettings()
        {
            if (_sharedJsonSerializerSettings == null)
            {
                lock (SyncObj)
                {
                    if (_sharedJsonSerializerSettings == null)
                    {
                        _sharedJsonSerializerSettings = new JsonSerializerSettings
                        {
                            ContractResolver = new AuditingContractResolver(Options.IgnoredTypes)
                        };
                    }
                }
            }

            return _sharedJsonSerializerSettings;
        }
    }
}