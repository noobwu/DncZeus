// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="PaggingRequest.cs" company="Noob.D2CMSApi">
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
    /// Class PaggingRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    public class PaggingRequest : RequestBase
    {
        /// <summary>
        /// page
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        /// page_size
        /// </summary>
        /// <value>The size of the page.</value>
        [JsonProperty("page_size")]
        public int PageSize { get; set; }
        /// <summary>
        /// order_column_name
        /// </summary>
        /// <value>The name of the order column.</value>
        [JsonProperty("order_column_name")]
        public string OrderColumnName { get; set; }
        /// <summary>
        /// order_type
        /// </summary>
        /// <value>The type of the order.</value>
        [JsonProperty("order_type")]
        public string OrderType { get; set; }
    }
}
