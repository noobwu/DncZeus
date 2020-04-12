// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysPost.cs" company="Noob.D2CMSApi">
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
    /// 岗位信息表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysPost:Entity<int>
    {
        /// <summary>
        /// 岗位ID
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysPost(int id) : base(id) {}

        /// <summary>
        /// 岗位编码
        /// </summary>
        /// <value>The post code.</value>
        public virtual string PostCode { get;set;}
        /// <summary>
        /// 岗位名称
        /// </summary>
        /// <value>The name of the post.</value>
        public virtual string PostName { get;set;}
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The post sort.</value>
        public virtual int PostSort { get;set;}
        /// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        public virtual string Status { get;set;}
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
