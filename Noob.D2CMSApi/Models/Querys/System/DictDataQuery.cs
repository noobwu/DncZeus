// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="DictDataQueryRequest.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Requests
{
    /// <summary>
    /// Class DictDataQuery.
    /// Implements the <see cref="Noob.D2CMSApi.Models.PaggingBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.PaggingBase" />
    public class DictDataQuery : PaggingBase
    {

        /// <summary>
        ///字典类型
        /// </summary>
        [JsonProperty("dict_type")]
        public string DictType { get; set; }
        /// <summary>
        ///字典类型Id
        /// </summary>
        [JsonProperty("dict_id")]
        public int DictTypeId { get; set; }
        /// <summary>
        ///字典标签
        /// </summary>
        [JsonProperty("dict_label")]
        public string DictLabel { get; set; }
        /// <summary>
        ///字典值
        /// </summary>
        [JsonProperty("dict_value")]
        public string DictValue { get; set; }
        /// <summary>
        ///  状态
        /// </summary>
        [JsonProperty("status")]
        public byte Status { get; set; }
    }
}
