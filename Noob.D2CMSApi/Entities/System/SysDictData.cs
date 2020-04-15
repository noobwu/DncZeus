// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysDictData.cs" company="Noob.D2CMSApi">
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
    /// 字典数据表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysDictData:Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysDictData"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysDictData(int id) : base(id) {}

        /// <summary>
        /// ID
        /// </summary>
        /// <value>The dictionary code.</value>
        public virtual int DictCode { get;set;}
        /// <summary>
        /// 字典排序
        /// </summary>
        /// <value>The dictionary sort.</value>
        public virtual int? DictSort { get;set;}
        /// <summary>
        /// 字典标签
        /// </summary>
        /// <value>The dictionary label.</value>
        public virtual string DictLabel { get;set;}
        /// <summary>
        /// 字典键值
        /// </summary>
        /// <value>The dictionary value.</value>
        public virtual string DictValue { get;set;}
        /// <summary>
        /// 字典类型
        /// </summary>
        /// <value>The type of the dictionary.</value>
        public virtual string DictType { get;set;}
        /// <summary>
        /// 样式属性（其他样式扩展）
        /// </summary>
        /// <value>The CSS class.</value>
        public virtual string CssClass { get;set;}
        /// <summary>
        /// 表格回显样式
        /// </summary>
        /// <value>The list class.</value>
        public virtual string ListClass { get;set;}
        /// <summary>
        /// 是否默认（Y是 N否）
        /// </summary>
        /// <value>The is default.</value>
        public virtual byte IsDefault { get;set;}
        /// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        public virtual byte Status { get;set;}
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
