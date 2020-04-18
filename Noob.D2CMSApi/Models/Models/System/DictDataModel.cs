// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="DictDataResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models
{
    /// <summary>
    /// 字典数据表
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    [Serializable]
    public class DictDataModel : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 字典类型Id
        /// </summary>
        [JsonProperty("dict_id")]
        public virtual int DictTypeId { get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        [JsonProperty("dict_sort")]
        public virtual int DictSort { get; set; }
        /// <summary>
        /// 字典标签
        /// </summary>
        [JsonProperty("dict_label")]
        public virtual string DictLabel { get; set; }
        /// <summary>
        /// 字典键值(字符串)
        /// </summary>
        [JsonProperty("dict_value")]
        public virtual string DictValue { get; set; }
        /// <summary>
        /// 字典键值(数字)
        /// </summary>
        [JsonProperty("dict_number")]
        public virtual int DictNumber { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        [JsonProperty("dict_type")]
        public virtual string DictType { get; set; }
        /// <summary>
        /// 字典值类型
        /// </summary>
        [JsonProperty("dict_value_type")]
        public virtual byte DictValueType { get; set; }
        /// <summary>
        /// 字典值类型
        /// </summary>
        [JsonProperty("css_class")]
        public virtual string CssClass { get; set; }
        /// <summary>
        /// 表格回显样式
        /// </summary>
        [JsonProperty("list_class")]
        public virtual string ListClass { get; set; }
        /// <summary>
        /// 是否默认(1:是,2:否）
        /// </summary>
        [JsonProperty("is_default")]
        public virtual byte IsDefault { get; set; }
        /// <summary>
        /// 状态(1:正常,2:停用)
        /// </summary>
        [JsonProperty("status")]
        public virtual byte Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("create_by")]
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("update_by")]
        public virtual string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }

    }
}
