// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="UserResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Results
{
    /// <summary>
    /// Class UserResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// Implements the <see cref="Noob.D2CMSApi.Models.UserModel" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.UserModel" />
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    public class UserResult : UserModel
    {
        /// <summary>
        /// Gets or sets the user post.
        /// </summary>
        /// <value>The user post.</value>
        [JsonProperty("user_post")]
        public virtual string UserPost { get; set; }
        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>The user role.</value>
        [JsonProperty("user_role")]
        public virtual string UserRole { get; set; }
        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        [JsonProperty("new_password")]
        public virtual string NewPassword { get; set; }
    }
}
