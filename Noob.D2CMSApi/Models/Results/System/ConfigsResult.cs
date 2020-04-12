// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="ConfigsResult.cs" company="Noob.D2CMSApi">
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
    /// 参数配置表
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    [Serializable]
    public class ConfigsResult : ModelBase
    {
        /// <summary>
        /// 参数主键
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        /// <value>The name of the configuration.</value>
        [JsonProperty("config_name")]
        public virtual string ConfigName { get; set; }
        /// <summary>
        /// 参数键名
        /// </summary>
        /// <value>The configuration key.</value>
        [JsonProperty("config_key")]
        public virtual string ConfigKey { get; set; }
        /// <summary>
        /// 参数键值
        /// </summary>
        /// <value>The configuration value.</value>
        [JsonProperty("config_value")]
        public virtual string ConfigValue { get; set; }
        /// <summary>
        /// 系统内置（1是 2否）
        /// </summary>
        /// <value>The type of the configuration.</value>
        [JsonProperty("config_type")]
        public virtual byte? ConfigType { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The created by.</value>
        [JsonProperty("created_by")]
        public virtual string CreatedBy { get; set; }
        /// <summary>
        /// 更新着
        /// </summary>
        /// <value>The updated by.</value>
        [JsonProperty("updated_by")]
        public virtual string UpdatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <value>The deleted at.</value>
        [JsonProperty("deleted_at")]
        public virtual string DeletedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }

    }
}
