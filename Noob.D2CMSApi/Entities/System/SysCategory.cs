// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysCategory.cs" company="Noob.D2CMSApi">
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
    /// 分类表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysCategory:Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysCategory"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysCategory(int id) : base(id) {}

        /// <summary>
        /// 父ID
        /// </summary>
        /// <value>The pid.</value>
        public virtual int Pid { get;set;}
        /// <summary>
        /// 栏目类型
        /// </summary>
        /// <value>The type.</value>
        public virtual byte Type { get;set;}
        /// <summary>
        /// 栏目名称
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get;set;}
        /// <summary>
        /// 别名
        /// </summary>
        /// <value>The nickname.</value>
        public virtual string Nickname { get;set;}
        /// <summary>
        /// 0,1火,2首页,3推荐
        /// </summary>
        /// <value>The flag.</value>
        public virtual byte Flag { get;set;}
        /// <summary>
        /// 外链
        /// </summary>
        /// <value>The href.</value>
        public virtual string Href { get;set;}
        /// <summary>
        /// 是否是导航
        /// </summary>
        /// <value>The is nav.</value>
        public virtual byte IsNav { get;set;}
        /// <summary>
        /// 图片
        /// </summary>
        /// <value>The image.</value>
        public virtual string Image { get;set;}
        /// <summary>
        /// 关键字
        /// </summary>
        /// <value>The keywords.</value>
        public virtual string Keywords { get;set;}
        /// <summary>
        /// 描述
        /// </summary>
        /// <value>The description.</value>
        public virtual string Description { get;set;}
        /// <summary>
        /// 内容
        /// </summary>
        /// <value>The content.</value>
        public virtual string Content { get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        public virtual int CreatedAt { get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        public virtual int UpdatedAt { get;set;}
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <value>The deleted at.</value>
        public virtual byte[] DeletedAt { get;set;}
        /// <summary>
        /// 权重
        /// </summary>
        /// <value>The weigh.</value>
        public virtual int Weigh { get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        /// <value>The status.</value>
        public virtual byte Status { get;set;}
        /// <summary>
        /// 模板文件
        /// </summary>
        /// <value>The TPL.</value>
        public virtual string Tpl { get;set;}



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
