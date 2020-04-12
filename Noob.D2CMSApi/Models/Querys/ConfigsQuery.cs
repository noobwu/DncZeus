// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-08
// ***********************************************************************
// <copyright file="ConfigsQueryRequest.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Querys
{
    /// <summary>
    /// Class ConfigsQuery.
    /// Implements the <see cref="Noob.D2CMSApi.Models.PaggingBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.PaggingBase" />
    public class ConfigsQuery : PaggingBase
    {
        /// <summary>
        /// config_name
        /// </summary>
        /// <value>The name of the configuration.</value>
        [JsonProperty("config_name")]
        public string ConfigName { get; set; }
        /// <summary>
        /// config_key
        /// </summary>
        /// <value>The configuration key.</value>
        [JsonProperty("config_key")]
        public string ConfigKey { get; set; }
        /// <summary>
        /// config_value
        /// </summary>
        /// <value>The configuration value.</value>
        [JsonProperty("config_value")]
        public string ConfigValue { get; set; }
        /// <summary>
        /// config_type
        /// </summary>
        /// <value>The type of the configuration.</value>
        [JsonProperty("config_type")]
        public string ConfigType { get; set; }
    }
}
