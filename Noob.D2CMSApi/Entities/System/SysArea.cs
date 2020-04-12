// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysArea.cs" company="Noob.D2CMSApi">
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
    /// 地区信息
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysArea:Entity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysArea"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysArea(long id) : base(id) {}

        /// <summary>
        /// Gets or sets the adcode.
        /// </summary>
        /// <value>The adcode.</value>
        public virtual string Adcode { get;set;}
        /// <summary>
        /// Gets or sets the citycode.
        /// </summary>
        /// <value>The citycode.</value>
        public virtual int Citycode { get;set;}
        /// <summary>
        /// Gets or sets the center.
        /// </summary>
        /// <value>The center.</value>
        public virtual string Center { get;set;}
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get;set;}
        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public virtual int ParentId { get;set;}
        /// <summary>
        /// Gets or sets the is end.
        /// </summary>
        /// <value>The is end.</value>
        public virtual byte? IsEnd { get;set;}



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
