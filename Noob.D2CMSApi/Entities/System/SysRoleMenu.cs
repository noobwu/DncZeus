// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysRoleMenu.cs" company="Noob.D2CMSApi">
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
    /// 角色和菜单关联表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysRoleMenu:Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysRoleMenu"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysRoleMenu(int id) : base(id) {}

        /// <summary>
        /// 角色ID
        /// </summary>
        /// <value>The role identifier.</value>
        public virtual int RoleId { get;set;}
        /// <summary>
        /// 菜单ID
        /// </summary>
        /// <value>The menu identifier.</value>
        public virtual int MenuId { get;set;}



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
