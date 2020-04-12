// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysAdminLog.cs" company="Noob.D2CMSApi">
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
    /// 后台用户日志
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysAdminLog:Entity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysAdminLog"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysAdminLog(long id) : base(id) {}

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        public virtual string Route { get;set;}
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public virtual string Method { get;set;}
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public virtual string Description { get;set;}
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public virtual int UserId { get;set;}
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public virtual string Ip { get;set;}
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public virtual int CreatedAt { get;set;}
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        public virtual int UpdatedAt { get;set;}
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>The deleted at.</value>
        public virtual byte[] DeletedAt { get;set;}



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
