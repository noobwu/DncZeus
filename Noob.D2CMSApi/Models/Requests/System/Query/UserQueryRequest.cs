// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="UserQueryRequest.cs" company="Noob.D2CMSApi">
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
        /// user_name
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// phone
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }
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
        /// <summary>
        /// dept_id
        /// </summary>
        /// <value>The dept identifier.</value>
        [JsonProperty("dept_id")]
        public string DeptId { get; set; }
    }
}
