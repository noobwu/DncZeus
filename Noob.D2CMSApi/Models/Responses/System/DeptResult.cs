// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="DeptResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// Class DeptResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    public class DeptResult  : ModelBase
    {
        /// <summary>
        /// 部门id
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 父部门id
        /// </summary>
        /// <value>The parent identifier.</value>
        [JsonProperty("parent_id")]
        public virtual int? ParentId { get; set; }
        /// <summary>
        /// 祖级列表
        /// </summary>
        /// <value>The ancestors.</value>
        [JsonProperty("ancestors")]
        public virtual String Ancestors { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <value>The name of the dept.</value>
        [JsonProperty("dept_name")]
        public virtual String DeptName { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The order number.</value>
        [JsonProperty("order_num")]
        public virtual int? OrderNum { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <value>The leader.</value>
        [JsonProperty("leader")]
        public virtual String Leader { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public virtual String Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public virtual String Email { get; set; }
        /// <summary>
        /// 部门状态（0正常 1停用）
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public virtual String Status { get; set; }
        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        /// <value>The delete flag.</value>
        [JsonProperty("del_flag")]
        public virtual String DelFlag { get; set; }
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
        /// <summary>
        /// 下级部门
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("children_list")]
        public virtual IEnumerable<DeptResult> ChildrenList { get; set; }
    }
}
