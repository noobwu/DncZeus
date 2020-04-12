// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="SysMenu.cs" company="Noob.D2CMSApi">
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
    /// 菜单权限表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysMenu:Entity<int>
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysMenu(int id) : base(id) {}

        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value>The name of the menu.</value>
        public virtual string MenuName { get;set;}
        /// <summary>
        /// 父菜单ID
        /// </summary>
        /// <value>The parent identifier.</value>
        public virtual int? ParentId { get;set;}
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The order number.</value>
        public virtual int? OrderNum { get;set;}
        /// <summary>
        /// 请求地址
        /// </summary>
        /// <value>The URL.</value>
        public virtual string Url { get;set;}
        /// <summary>
        /// 菜单类型（1,目录 2,菜单 3,按钮）
        /// </summary>
        /// <value>The type of the menu.</value>
        public virtual byte? MenuType { get;set;}
        /// <summary>
        /// 菜单状态（0显示 1隐藏）
        /// </summary>
        /// <value>The visible.</value>
        public virtual byte Visible { get;set;}
        /// <summary>
        /// 权限标识
        /// </summary>
        /// <value>The perms.</value>
        public virtual string Perms { get;set;}
        /// <summary>
        /// 菜单图标
        /// </summary>
        /// <value>The icon.</value>
        public virtual string Icon { get;set;}
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
