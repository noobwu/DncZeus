// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysDictType.cs" company="Noob.D2CMSApi">
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
    /// 字典类型表
    /// </summary>
    [Serializable]
    public class SysDictType : Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysDictType(int id) : base(id) { }

        /// <summary>
        /// 字典名称
        /// </summary>
        public virtual string DictName { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public virtual string DictType { get; set; }
        /// <summary>
        /// 字典值类型
        /// </summary>
        public virtual byte DictValueType { get; set; }
        /// <summary>
        /// 状态(1:正常,2:停用)
        /// </summary>
        public virtual byte Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual int? CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public virtual string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual int? UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }



        /// <summary>
        /// 获取主键的属性名称
        /// </summary>
        /// <returns></returns>
        public virtual string GetPKPropertyName()
        {
            return "Id";
        }

    }

}
