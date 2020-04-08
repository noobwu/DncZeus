// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="UserRequest.cs" company="Noob.D2CMSApi">
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
    /// Class UserRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    public class UserQueryRequest:PaggingRequest
    {
        /// <summary>
        ///user_name
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        /// <summary>
        ///phone
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        ///status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
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
        ///dept_id
        /// </summary>
        [JsonProperty("dept_id")]
        public string DeptId { get; set; }
    }
}
