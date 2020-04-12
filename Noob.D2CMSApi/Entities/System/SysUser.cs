// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="SysUser.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// Class SysUser.
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysUser:Entity<int>
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysUser(int id) : base(id) {}
        /// <summary>
        /// 登录账号
        /// </summary>
        /// <value>The name of the user.</value>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        /// <value>The name of the login.</value>
        public virtual string Nickname { get;set;}
 
        /// <summary>
        /// 用户类型（1系统用户）
        /// </summary>
        /// <value>The type of the user.</value>
        public virtual byte? UserType { get;set;}
        /// <summary>
        /// 用户邮箱
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get;set;}
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>The phone.</value>
        public virtual string Phone { get;set;}
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <value>The phonenumber.</value>
        public virtual string Phonenumber { get;set;}
        /// <summary>
        /// 用户性别（1男 2女 3未知）
        /// </summary>
        /// <value>The sex.</value>
        public virtual byte? Sex { get;set;}
        /// <summary>
        /// 头像路径
        /// </summary>
        /// <value>The avatar.</value>
        public virtual string Avatar { get;set;}
        /// <summary>
        /// 密码
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get;set;}
        /// <summary>
        /// 盐加密
        /// </summary>
        /// <value>The salt.</value>
        public virtual string Salt { get;set;}
        /// <summary>
        /// 帐号状态（1正常 2禁用）
        /// </summary>
        /// <value>The status.</value>
        public virtual byte? Status { get;set;}
        /// <summary>
        /// 删除标志（1代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        public virtual byte? DelFlag { get;set;}
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        /// <value>The login ip.</value>
        public virtual string LoginIp { get;set;}
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        /// <value>The login date.</value>
        public virtual int? LoginDate { get;set;}
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The create by.</value>
        public virtual string CreateBy { get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        public virtual int? CreatedAt { get;set;}
        /// <summary>
        /// 更新者
        /// </summary>
        /// <value>The update by.</value>
        public virtual string UpdateBy { get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        public virtual int? UpdatedAt { get;set;}
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <value>The deleted at.</value>
        public virtual DateTime? DeletedAt { get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        public virtual string Remark { get;set;}


        /// <summary>
        /// 获取主键的属性名称
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetPKPropertyName()
        {
            return "Id";
        }
	  
    }
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdministrator = 1,
    }

}
