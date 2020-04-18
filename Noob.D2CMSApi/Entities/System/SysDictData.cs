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
        /// 字典数据
        /// </summary>
        public SysDictData(SysDictData dict,byte dictValueType) : this(dict.Id) {
            DictTypeId = dict.DictTypeId;
            DictSort = dict.DictSort;
            DictLabel = dict.DictLabel;
            DictValue = dict.DictValue;
            DictNumber = dict.DictNumber;
            DictType = dict.DictType;
            DictValueType = dict.DictValueType;
            CssClass = dict.CssClass;
            ListClass = dict.ListClass;
            IsDefault = dict.IsDefault;
            Status = dict.Status;
            CreateBy = dict.CreateBy;
            CreatedAt = dict.CreatedAt;
            UpdateBy = dict.UpdateBy;
            UpdatedAt = dict.UpdatedAt;
            Remark = dict.Remark;

            DictValueType = dictValueType;
        }
        /// <summary>
        /// 字典数据
        /// </summary>
        public SysDictData(int id) : base(id)
        {
        }
        /// <summary>
        /// 字典类型Id
        /// </summary>
        public virtual int DictTypeId { get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        public virtual int DictSort { get; set; }
        /// <summary>
        /// 字典标签
        /// </summary>
        public virtual string DictLabel { get; set; }
        /// <summary>
        /// 字典键值(字符串)
        /// </summary>
        public virtual string DictValue { get; set; }
        /// <summary>
        /// 字典键值(数字)
        /// </summary>
        public virtual int DictNumber { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public virtual string DictType { get; set; }

        /// <summary>
        /// 字典值类型
        /// </summary>
        public virtual string CssClass { get; set; }
        /// <summary>
        /// 表格回显样式
        /// </summary>
        public virtual string ListClass { get; set; }
        /// <summary>
        /// 是否默认(1:是,2:否）
        /// </summary>
        public virtual byte IsDefault { get; set; }
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
        /// 字典值类型
        /// </summary>
        public virtual byte DictValueType { get; set; }
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
