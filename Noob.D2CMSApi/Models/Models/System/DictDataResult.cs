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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        /// <value>The dictionary code.</value>
        [JsonProperty("dict_code")]
        public virtual int DictCode { get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        /// <value>The dictionary sort.</value>
        [JsonProperty("dict_sort")]
        public virtual int? DictSort { get; set; }
        /// <summary>
        /// 字典标签
        /// </summary>
        /// <value>The dictionary label.</value>
        [JsonProperty("dict_label")]
        public virtual String DictLabel { get; set; }
        /// <summary>
        /// 字典键值
        /// </summary>
        /// <value>The dictionary value.</value>
        [JsonProperty("dict_value")]
        public virtual String DictValue { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        /// <value>The type of the dictionary.</value>
        [JsonProperty("dict_type")]
        public virtual String DictType { get; set; }
        /// <summary>
        /// 样式属性（其他样式扩展）
        /// </summary>
        /// <value>The CSS class.</value>
        [JsonProperty("css_class")]
        public virtual String CssClass { get; set; }
        /// <summary>
        /// 表格回显样式
        /// </summary>
        /// <value>The list class.</value>
        [JsonProperty("list_class")]
        public virtual String ListClass { get; set; }
        /// <summary>
        /// 是否默认（Y是 N否）
        /// </summary>
        /// <value>The is default.</value>
        [JsonProperty("is_default")]
        public virtual byte IsDefault { get; set; }
        /// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public virtual byte Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The create by.</value>
        [JsonProperty("create_by")]
        public virtual String CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        /// <value>The update by.</value>
        [JsonProperty("update_by")]
        public virtual String UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("remark")]
        public virtual String Remark { get; set; }


    }
}
