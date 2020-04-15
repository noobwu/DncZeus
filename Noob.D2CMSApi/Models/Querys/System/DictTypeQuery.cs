// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-14
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-14
// ***********************************************************************
// <copyright file="DictTypeQuery.cs" company="Noob.D2CMSApi">
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
    /// Class DictTypeQuery.
    /// Implements the <see cref="Noob.D2CMSApi.Models.PaggingBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.PaggingBase" />
    public class DictTypeQuery : PaggingBase
    {
        /// <summary>
        ///dict_name
        /// </summary>
        [JsonProperty("dict_name")]
        public string DictName { get; set; }
        /// <summary>
        ///dict_type
        /// </summary>
        [JsonProperty("dict_type")]
        public string DictType { get; set; }
        /// <summary>
        ///start_time
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        /// <summary>
        ///end_time
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
        /// <summary>
        ///status
        /// </summary>
        [JsonProperty("status")]
        public byte Status { get; set; }
    }
}
