using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses.System
{
    /// <summary>
    /// 角色
    /// </summary>
    [Serializable]
    public class RoleResult : ResultBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [JsonProperty("role_name")]
        public virtual String RoleName { get; set; }
        /// <summary>
        /// 角色权限字符串
        /// </summary>
        [JsonProperty("role_key")]
        public virtual String RoleKey { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [JsonProperty("role_sort")]
        public virtual int RoleSort { get; set; }
        /// <summary>
        /// 数据范围（1：全部数据权限 2：自定数据权限）
        /// </summary>
        [JsonProperty("data_scope")]
        public virtual byte DataScope { get; set; }
        /// <summary>
        /// 角色状态（0正常 1停用）
        /// </summary>
        [JsonProperty("status")]
        public virtual byte Status { get; set; }
        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        [JsonProperty("del_flag")]
        public virtual byte DelFlag { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("create_by")]
        public virtual String CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual String CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("update_by")]
        public virtual String UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual String UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual String Remark { get; set; }
    }
}
