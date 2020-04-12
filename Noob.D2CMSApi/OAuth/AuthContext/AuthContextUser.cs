// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="AuthContextUser.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.OAuth.AuthContext
{
    /// <summary>
    /// 登录用户上下文
    /// </summary>
    public class AuthContextUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        /// <value>The name of the login.</value>
        public string LoginName { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        /// <value>The type of the user.</value>
        public UserType UserType { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        /// <value>The avator.</value>
        public string Avator { get; set; }
    }
}