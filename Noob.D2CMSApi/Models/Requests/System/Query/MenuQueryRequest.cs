// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="MenuQueryRequest.cs" company="Noob.D2CMSApi">
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
    /// Class MenuQueryRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.PaggingRequest" />
    public class MenuQueryRequest : PaggingRequest
    {

        /// <summary>
        /// menu_name
        /// </summary>
        /// <value>The name of the menu.</value>
        [JsonProperty("menu_name")]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单状态（0显示 1隐藏）
        /// </summary>
        /// <value>The visible.</value>
        [JsonProperty("visible")]
        public byte? Visible { get; set; }
    }
}
