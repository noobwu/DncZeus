// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysUserPost.cs" company="Noob.D2CMSApi">
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
    /// 用户与岗位关联表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysUserPost:Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysUserPost"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysUserPost(int id) : base(id) {}

        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The user identifier.</value>
        public virtual int UserId { get;set;}
        /// <summary>
        /// 岗位ID
        /// </summary>
        /// <value>The post identifier.</value>
        public virtual int PostId { get;set;}



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
