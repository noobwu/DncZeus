using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// 字典数据表
    /// </summary>
    [Serializable]
    public class DictDataResult : ResultBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("dict_code")]
        public virtual int DictCode { get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        [JsonProperty("dict_sort")]
        public virtual int? DictSort { get; set; }
        /// <summary>
        /// 字典标签
        /// </summary>
        [JsonProperty("dict_label")]
        public virtual String DictLabel { get; set; }
        /// <summary>
        /// 字典键值
        /// </summary>
        [JsonProperty("dict_value")]
        public virtual String DictValue { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        [JsonProperty("dict_type")]
        public virtual String DictType { get; set; }
        /// <summary>
        /// 样式属性（其他样式扩展）
        /// </summary>
        [JsonProperty("css_class")]
        public virtual String CssClass { get; set; }
        /// <summary>
        /// 表格回显样式
        /// </summary>
        [JsonProperty("list_class")]
        public virtual String ListClass { get; set; }
        /// <summary>
        /// 是否默认（Y是 N否）
        /// </summary>
        [JsonProperty("is_default")]
        public virtual String IsDefault { get; set; }
        /// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
        [JsonProperty("status")]
        public virtual String Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("create_by")]
        public virtual String CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("update_by")]
        public virtual String UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual String Remark { get; set; }


    }
}
