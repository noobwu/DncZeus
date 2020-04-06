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
    /// Class DictDataQueryRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    public class DictDataQueryRequest : PaggingRequest
    {
        /// <summary>
        /// Gets or sets the type of the dictionary.
        /// </summary>
        /// <value>The type of the dictionary.</value>
        [JsonProperty("dict_type")]
        public string DictType { get; set; }
    }
}
