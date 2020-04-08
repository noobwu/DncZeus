using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// 参数配置表
    /// </summary>
    [Serializable]
    public class ConfigsResult : ResultBase
    {
        /// <summary>
        /// 参数主键
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        [JsonProperty("config_name")]
        public virtual string ConfigName { get; set; }
        /// <summary>
        /// 参数键名
        /// </summary>
        [JsonProperty("config_key")]
        public virtual string ConfigKey { get; set; }
        /// <summary>
        /// 参数键值
        /// </summary>
        [JsonProperty("config_value")]
        public virtual string ConfigValue { get; set; }
        /// <summary>
        /// 系统内置（1是 2否）
        /// </summary>
        [JsonProperty("config_type")]
        public virtual byte? ConfigType { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("created_by")]
        public virtual string CreatedBy { get; set; }
        /// <summary>
        /// 更新着
        /// </summary>
        [JsonProperty("updated_by")]
        public virtual string UpdatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [JsonProperty("deleted_at")]
        public virtual string DeletedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }

    }
}
