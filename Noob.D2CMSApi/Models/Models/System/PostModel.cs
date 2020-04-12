using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models
{
    /// <summary>
    /// 岗位信息表
    /// </summary>
    [Serializable]
    public class PostModel : ModelBase
    {
        /// <summary>
        /// 岗位ID
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 岗位编码
        /// </summary>
        [JsonProperty("post_code")]
        public virtual string PostCode { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        [JsonProperty("post_name")]
        public virtual string PostName { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [JsonProperty("post_sort")]
        public virtual int PostSort { get; set; }
        /// <summary>
        /// 状态（1:正常,2:停用）
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
