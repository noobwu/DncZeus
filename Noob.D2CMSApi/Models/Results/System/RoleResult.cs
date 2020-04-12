// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="RoleResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Results
{
    /// <summary>
    /// 角色
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    [Serializable]
    public class RoleResult : ModelBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        /// <value>The name of the role.</value>
        [JsonProperty("role_name")]
        public virtual String RoleName { get; set; }
        /// <summary>
        /// 角色权限字符串
        /// </summary>
        /// <value>The role key.</value>
        [JsonProperty("role_key")]
        public virtual String RoleKey { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The role sort.</value>
        [JsonProperty("role_sort")]
        public virtual int RoleSort { get; set; }
        /// <summary>
        /// 数据范围（1：全部数据权限 2：自定数据权限）
        /// </summary>
        /// <value>The data scope.</value>
        [JsonProperty("data_scope")]
        public virtual byte DataScope { get; set; }
        /// <summary>
        /// 角色状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public virtual byte Status { get; set; }
        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        [JsonProperty("del_flag")]
        public virtual byte DelFlag { get; set; }
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
        public virtual String CreatedAt { get; set; }
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
        public virtual String UpdatedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("remark")]
        public virtual String Remark { get; set; }
    }
}
