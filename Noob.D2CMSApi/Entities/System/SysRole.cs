// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-07
// ***********************************************************************
// <copyright file="SysRole.cs" company="Noob.D2CMSApi">
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
    /// 角色信息表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysRole:Entity<int>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysRole(int id) : base(id) {}

        /// <summary>
        /// 角色名称
        /// </summary>
        /// <value>The name of the role.</value>
        public virtual string RoleName { get;set;}
        /// <summary>
        /// 角色权限字符串
        /// </summary>
        /// <value>The role key.</value>
        public virtual string RoleKey { get;set;}
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The role sort.</value>
        public virtual int RoleSort { get;set;}
        /// <summary>
        /// 数据范围（1：全部数据权限 2：自定数据权限）
        /// </summary>
        /// <value>The data scope.</value>
        public virtual byte DataScope { get;set;}
        /// <summary>
        /// 角色状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        public virtual byte Status { get;set;}
        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        public virtual byte DelFlag { get;set;}
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
   
}
