﻿// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="MenuResult.cs" company="Noob.D2CMSApi">
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
    /// Class MenuResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.ModelBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.ModelBase" />
    [Serializable]
    public class MenuResult : ModelBase
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value>The name of the menu.</value>
        [JsonProperty("menu_name")]
        public virtual string MenuName { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
        /// <value>The parent identifier.</value>
        [JsonProperty("parent_id")]
        public virtual int? ParentId { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <value>The order number.</value>
        [JsonProperty("order_num")]
        public virtual int? OrderNum { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public virtual string Url { get; set; }
        /// <summary>
        /// 菜单类型（1,目录 2,菜单 3,按钮）
        /// </summary>
        /// <value>The type of the menu.</value>
        [JsonProperty("menu_type")]
        public virtual byte? MenuType { get; set; }
        /// <summary>
        /// 菜单状态（0显示 1隐藏）
        /// </summary>
        /// <value>The visible.</value>
        [JsonProperty("visible")]
        public virtual byte Visible { get; set; }
        /// <summary>
        /// 权限标识
        /// </summary>
        /// <value>The perms.</value>
        [JsonProperty("perms")]
        public virtual string Perms { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        /// <value>The icon.</value>
        [JsonProperty("icon")]
        public virtual string Icon { get; set; }
        /// <summary>
        /// Gets or sets the is frame.(2)
        /// </summary>
        /// <value>The is frame.</value>
        [JsonProperty("is_frame")]
        public virtual byte IsFrame { get; set; }
        /// <summary>
        /// Gets or sets the is frame.(2)
        /// </summary>
        /// <value>The is frame.</value>
        [JsonProperty("component")]
        public virtual string Component { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The create by.</value>
        [JsonProperty("create_by")]
        public virtual string CreateBy { get; set; }
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
        public virtual string UpdateBy { get; set; }
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
        public virtual string Remark { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("route_name")]
        public virtual string RouteName { get; set; }
        /// <summary>
        /// 路由路径
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("route_path")]
        public virtual string RoutePath { get; set; }
        /// <summary>
        /// 路由缓存
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("route_cache")]
        public virtual byte RouteCache { get; set; }
        /// <summary>
        /// 路由缓存
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("route_component")]
        public virtual string RouteComponent { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        /// <value>The remark.</value>
        [JsonProperty("children_list")]
        public virtual IEnumerable<MenuResult> ChildrenList { get; set; }
    }
}
