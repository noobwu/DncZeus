// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="UserModel.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models
{
    /// <summary>
    /// Class UserModel.
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    [Serializable]
    public class UserModel:ModelBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty("user_name")]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 用户类型（1系统用户）
        /// </summary>
        /// <value>The type of the user.</value>
        [JsonProperty("user_type")]
        public virtual byte? UserType { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public virtual string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <value>The phonenumber.</value>
        [JsonProperty("phonenumber")]
        public virtual string Phonenumber { get; set; }
        /// <summary>
        /// 用户性别（1男 2女 3未知）
        /// </summary>
        /// <value>The sex.</value>
        [JsonProperty("sex")]
        public virtual byte? Sex { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        /// <value>The avatar.</value>
        [JsonProperty("avatar")]
        public virtual string Avatar { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value>The password.</value>
        [JsonProperty("password")]
        public virtual string Password { get; set; }
        /// <summary>
        /// 帐号状态（1正常 2禁用）
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public virtual byte? Status { get; set; }
        /// <summary>
        /// 删除标志（1代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        [JsonProperty("del_flag")]
        public virtual byte? DelFlag { get; set; }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        /// <value>The login ip.</value>
        [JsonProperty("login_ip")]
        public virtual string LoginIp { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        /// <value>The login date.</value>
        [JsonProperty("login_date")]
        public virtual string LoginDate { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The create by.</value>
        [JsonProperty("create_by")]
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        /// <value>The update by.</value>
        [JsonProperty("update_by")]
        public virtual string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <value>The deleted at.</value>
        [JsonProperty("deleted_at")]
        public virtual string DeletedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }
    }
}
