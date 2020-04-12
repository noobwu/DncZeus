// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="SysDept.cs" company="Noob.D2CMSApi">
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
    /// 部门表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysDept:Entity<int>
    {
        /// <summary>
        /// 部门id
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysDept(int id) : base(id) {}

        /// <summary>
        /// 父部门id
        /// </summary>
        /// <value>The parent identifier.</value>
        public virtual int? ParentId { get;set;}
        /// <summary>
        /// 祖级列表
        /// </summary>
        /// <value>The ancestors.</value>
        public virtual string Ancestors { get;set;}
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <value>The name of the dept.</value>
        public virtual string DeptName { get;set;}
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The order number.</value>
        public virtual int? OrderNum { get;set;}
        /// <summary>
        /// 负责人
        /// </summary>
        /// <value>The leader.</value>
        public virtual string Leader { get;set;}
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <value>The phone.</value>
        public virtual string Phone { get;set;}
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get;set;}
        /// <summary>
        /// 部门状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        public virtual string Status { get;set;}
        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        public virtual string DelFlag { get;set;}
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
