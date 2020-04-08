// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-07
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-07
// ***********************************************************************
// <copyright file="RoleQueryRequest.cs" company="Noob.D2CMSApi">
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
    /// Class RoleQueryRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    public class RoleQueryRequest:PaggingRequest
    {
        /// <summary>
        /// role_name
        /// </summary>
        /// <value>The name of the role.</value>
        [JsonProperty("role_name")]
        public string RoleName { get; set; }
        /// <summary>
        /// role_key
        /// </summary>
        /// <value>The role key.</value>
        [JsonProperty("role_key")]
        public string RoleKey { get; set; }
        /// <summary>
        /// status
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// start_time
        /// </summary>
        /// <value>The start time.</value>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        /// <summary>
        /// end_time
        /// </summary>
        /// <value>The end time.</value>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
    }
}
