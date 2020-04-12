// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="LoginRequest.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Noob.D2CMSApi.Models.Requests
{
    /// <summary>
    /// Class LoginRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    [Serializable]
    public class LoginRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
