using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models
{
    /// <summary>
    /// 字典类型表
    /// </summary>
    [Serializable]
    public class DictTypeModel : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 字典主键
        /// </summary>
        [JsonProperty("dict_id")]
        public virtual int DictId { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        [JsonProperty("dict_name")]
        public virtual string DictName { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        [JsonProperty("dict_type")]
        public virtual string DictType { get; set; }
        /// <summary>
        /// 状态(1:正常,2:停用)
        /// </summary>
        [JsonProperty("status")]
        public virtual byte? Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("create_by")]
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual int? CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("update_by")]
        public virtual string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual int? UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }

    }
}
