// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-08
// ***********************************************************************
// <copyright file="SysConfigs.cs" company="Noob.D2CMSApi">
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
    /// 参数配置表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysConfigs:Entity<int>
    {
        /// <summary>
        /// 参数主键
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysConfigs(int id) : base(id) {}

        /// <summary>
        /// 参数名称
        /// </summary>
        /// <value>The name of the configuration.</value>
        public virtual string ConfigName { get;set;}
        /// <summary>
        /// 参数键名
        /// </summary>
        /// <value>The configuration key.</value>
        public virtual string ConfigKey { get;set;}
        /// <summary>
        /// 参数键值
        /// </summary>
        /// <value>The configuration value.</value>
        public virtual string ConfigValue { get;set;}
        /// <summary>
        /// 系统内置（1是 2否）
        /// </summary>
        /// <value>The type of the configuration.</value>
        public virtual byte? ConfigType { get;set;}
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The created by.</value>
        public virtual int? CreatedBy { get;set;}
        /// <summary>
        /// 更新着
        /// </summary>
        /// <value>The updated by.</value>
        public virtual int? UpdatedBy { get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        public virtual int? CreatedAt { get;set;}
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
   
}
