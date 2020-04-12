// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="LoginResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// Class LoginResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />

    [Serializable]
    public class LoginResult : ModelBase
    {
        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        /// <value>The nickname.</value>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty("userName")]
        public string UserName { get; set; }

    }
}
