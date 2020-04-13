// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysUserRole.cs" company="Noob.D2CMSApi">
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
    /// 用户和角色关联表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysUserRole:Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysUserRole"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysUserRole(int id) : base(id) {}

        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The user identifier.</value>
        public virtual int UserId { get;set;}
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <value>The role identifier.</value>
        public virtual int RoleId { get;set;}

         /*
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <value>The post identifier.</value>
        public virtual SysUser User { get; set; }
        */

        /// <summary>
        /// 获取主键的属性名称
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetPKPropertyName()
        {
            return "Id";
        }
	  
    }	
   
}
