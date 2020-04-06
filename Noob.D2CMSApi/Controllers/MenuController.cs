// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="MenuController.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Responses;
using Noob.D2CMSApi.OAuth.AuthContext;
using Noob.Extensions;

namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class MenuController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class MenuController : OAuthControllerBase
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly D2CmsDbContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public MenuController(D2CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult GetList()
        {
            var response = new ResponseResult<MenuResult>();
            using (_dbContext)
            {
                if (_dbContext.SysMenu.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单已初始化"));
                }
                else
                {
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单初始化成功"));
                }
            }
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="menus">The menus.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<MenuResult> menus)
        {
            var response = new ResponseResult<MenuResult>();
            if (menus.IsEmpty())
            {
                return Ok(response.Error((int)ResponseCode.ERROR, "菜单数据不能为空"));
            }
            List<SysMenu> sysMenus = new List<SysMenu>();
            menus.Each(a =>
            {
                HandleMenuData(a, sysMenus);
            });
            sysMenus = sysMenus.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysMenu.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单已初始化"));
                }
                else
                {
                    _dbContext.SysMenu.AddRange(sysMenus.ToArray());
                    _dbContext.SaveChanges();
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单初始化成功"));
                }
            }
        }
        /// <summary>
        /// Handles the menu data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="sysMenus">The system menus.</param>
        [NonAction]
        private void HandleMenuData(MenuResult item, List<SysMenu> sysMenus)
        {
            if (item == null)
            {
                return;
            }
            sysMenus.Add(new SysMenu(item.Id)
            {
                MenuName = item.MenuName,
                ParentId = item.ParentId,
                OrderNum = item.OrderNum,
                Url = item.Url,
                MenuType = item.MenuType,
                Visible = item.Visible,
                Perms = item.Perms,
                Icon = item.Icon,
                CreateBy = item.CreateBy,
                CreatedAt = (int)item.CreatedAt.UtcTimeToUnixTime(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = (int)item.UpdatedAt.UtcTimeToUnixTime(),
                Remark = item.Remark,
            });
            if (item.ChildrenList.IsAny())
            {
                item.ChildrenList.Each(a =>
                {
                    HandleMenuData(a, sysMenus);
                });
            }
        }
        /// <summary>
        /// Checks the token.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/menu/find_all_menu")]
        [AllowAnonymous]
        public IActionResult GetAllMenus()
        {
            var response = new ResponseResult<IEnumerable<MenuResult>>();
            List<SysMenu> sysMenus = null;
            using (_dbContext)
            {
                sysMenus = _dbContext.SysMenu.ToList();
            }
            if (sysMenus.IsEmpty())
            {
                return Ok(response.Error((int)ResponseCode.ERROR_CODE__DB__NO_ROW, "请先添加菜单"));
            }
            var menuResults = from item in sysMenus.Where(a => a.ParentId == 0).OrderBy(a=>a.OrderNum)
                              select new MenuResult
                              {
                                  Id = item.Id,
                                  MenuName = item.MenuName,
                                  ParentId = item.ParentId,
                                  OrderNum = item.OrderNum,
                                  Url = item.Url,
                                  MenuType = item.MenuType,
                                  Visible = item.Visible,
                                  Perms = item.Perms,
                                  Icon = item.Icon,
                                  IsFrame=(byte)(item.MenuType==1?2:0),
                                  Component=string.Empty,
                                  CreateBy = item.CreateBy,
                                  CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                                  UpdateBy = item.UpdateBy,
                                  UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                                  Remark = item.Remark,
                                  ChildrenList = GetChildMenus(item.Id, sysMenus),
                                  RouteCache= (byte)(item.MenuType == 1 ? 2 : 0),
                                  RouteComponent=string.Empty,
                                  RouteName=string.Empty,
                                  RoutePath=string.Empty,
                              };
            return Ok(response.Success("数据获取成功",menuResults));
            //return Ok("{\"code\":0,\"data\":[{\"id\":53,\"menu_name\":\"系统管理\",\"parent_id\":0,\"order_num\":1,\"url\":\"\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"cog\",\"is_frame\":2,\"component\":\"\",\"create_by\":0,\"created_at\":\"2019-10-23T14:07:28+08:00\",\"update_by\":81,\"updated_at\":\"2020-02-21T17:24:17+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":2,\"route_component\":\"\",\"children_list\":[{\"id\":111,\"menu_name\":\"用户管理\",\"parent_id\":53,\"order_num\":1,\"url\":\"/management/user\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"user-circle\",\"is_frame\":2,\"component\":\"management/user\",\"create_by\":77,\"created_at\":\"2019-12-09T21:28:22+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-24T17:06:42+08:00\",\"remark\":\"\",\"route_name\":\"management-user\",\"route_path\":\"management/user\",\"route_cache\":2,\"route_component\":\"management/user\",\"children_list\":[{\"id\":133,\"menu_name\":\"用户新增\",\"parent_id\":111,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:user:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:12:10+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:12:10+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":132,\"menu_name\":\"用户查询\",\"parent_id\":111,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:user:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:11:39+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-24T17:09:55+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":135,\"menu_name\":\"用户删除\",\"parent_id\":111,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:user:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:12:43+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:12:43+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":134,\"menu_name\":\"用户修改\",\"parent_id\":111,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:user:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:12:30+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:12:30+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":85,\"menu_name\":\"角色管理\",\"parent_id\":53,\"order_num\":2,\"url\":\"/management/role\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"users\",\"is_frame\":2,\"component\":\"management/role\",\"create_by\":0,\"created_at\":\"2019-10-25T00:05:07+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-21T19:22:08+08:00\",\"remark\":\"\",\"route_name\":\"management-role\",\"route_path\":\"management/role\",\"route_cache\":2,\"route_component\":\"management/role\",\"children_list\":[{\"id\":123,\"menu_name\":\"角色删除\",\"parent_id\":85,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:role:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:02:27+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:02:27+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":122,\"menu_name\":\"角色修改\",\"parent_id\":85,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:role:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:02:12+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:02:12+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":121,\"menu_name\":\"角色新增\",\"parent_id\":85,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:role:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:01:49+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:01:49+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":120,\"menu_name\":\"角色查询\",\"parent_id\":85,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:role:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:01:29+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:01:29+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":148,\"menu_name\":\"角色修改 - 数据权限\",\"parent_id\":85,\"order_num\":1,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:role:editData\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-29T15:24:52+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-29T15:29:57+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":81,\"menu_name\":\"菜单管理\",\"parent_id\":53,\"order_num\":3,\"url\":\"/management/menu\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"navicon\",\"is_frame\":2,\"component\":\"management/menu\",\"create_by\":0,\"created_at\":\"2019-10-24T22:26:57+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-21T19:22:01+08:00\",\"remark\":\"\",\"route_name\":\"management-menu\",\"route_path\":\"management/menu\",\"route_cache\":2,\"route_component\":\"management/menu\",\"children_list\":[{\"id\":119,\"menu_name\":\"菜单删除\",\"parent_id\":81,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:menu:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T17:59:38+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T17:59:38+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":118,\"menu_name\":\"菜单修改\",\"parent_id\":81,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:menu:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T17:59:19+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T17:59:19+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":117,\"menu_name\":\"菜单新增\",\"parent_id\":81,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:menu:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T17:58:58+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T17:58:58+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":116,\"menu_name\":\"菜单查询\",\"parent_id\":81,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:menu:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T16:55:34+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T17:57:50+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":112,\"menu_name\":\"部门管理\",\"parent_id\":53,\"order_num\":4,\"url\":\"/management/dept\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"bank\",\"is_frame\":2,\"component\":\"management/dept\",\"create_by\":77,\"created_at\":\"2019-12-10T08:51:52+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T18:49:41+08:00\",\"remark\":\"\",\"route_name\":\"management-dept\",\"route_path\":\"management/dept\",\"route_cache\":2,\"route_component\":\"management/dept\",\"children_list\":[{\"id\":137,\"menu_name\":\"部门新增\",\"parent_id\":112,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dept:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:13:29+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:13:29+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":136,\"menu_name\":\"部门查询\",\"parent_id\":112,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dept:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:13:14+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:13:14+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":139,\"menu_name\":\"部门删除\",\"parent_id\":112,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dept:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:13:54+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:13:54+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":138,\"menu_name\":\"部门修改\",\"parent_id\":112,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dept:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:13:42+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:13:42+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":113,\"menu_name\":\"岗位管理\",\"parent_id\":53,\"order_num\":5,\"url\":\"/management/post\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"briefcase\",\"is_frame\":2,\"component\":\"management/post\",\"create_by\":77,\"created_at\":\"2019-12-10T08:52:27+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T18:49:56+08:00\",\"remark\":\"\",\"route_name\":\"management-post\",\"route_path\":\"management/post\",\"route_cache\":2,\"route_component\":\"management/post\",\"children_list\":[{\"id\":143,\"menu_name\":\"岗位删除\",\"parent_id\":113,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:post:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:15:21+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:15:21+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":142,\"menu_name\":\"岗位修改\",\"parent_id\":113,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:post:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:15:07+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:15:07+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":141,\"menu_name\":\"岗位新增\",\"parent_id\":113,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:post:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:14:48+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:14:48+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":140,\"menu_name\":\"岗位查询\",\"parent_id\":113,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:post:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:14:28+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:14:28+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":88,\"menu_name\":\"字典管理\",\"parent_id\":53,\"order_num\":6,\"url\":\"/management/dict\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"book\",\"is_frame\":2,\"component\":\"management/dict\",\"create_by\":0,\"created_at\":\"2019-10-25T00:05:36+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T18:50:03+08:00\",\"remark\":\"\",\"route_name\":\"management-dict\",\"route_path\":\"management/dict\",\"route_cache\":2,\"route_component\":\"management/dict\",\"children_list\":[{\"id\":127,\"menu_name\":\"字典删除\",\"parent_id\":88,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:04:56+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:04:56+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":126,\"menu_name\":\"字典修改\",\"parent_id\":88,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:04:38+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:04:38+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":125,\"menu_name\":\"字典新增\",\"parent_id\":88,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:04:20+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:04:20+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":124,\"menu_name\":\"字典查询\",\"parent_id\":88,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:04:05+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:04:05+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":149,\"menu_name\":\"字典详情\",\"parent_id\":88,\"order_num\":1,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict:detail\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-29T15:41:16+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-29T15:41:16+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":115,\"menu_name\":\"字典数据\",\"parent_id\":53,\"order_num\":7,\"url\":\"/management/dict-data\",\"menu_type\":1,\"visible\":2,\"perms\":\"\",\"icon\":\"\",\"is_frame\":2,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T14:17:55+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T18:50:14+08:00\",\"remark\":\"\",\"route_name\":\"management-dict-data\",\"route_path\":\"management/dict-data\",\"route_cache\":2,\"route_component\":\"management/dict-data\",\"children_list\":[{\"id\":145,\"menu_name\":\"字典数据新增\",\"parent_id\":115,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict-data:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:16:41+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:16:41+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":144,\"menu_name\":\"字典数据查询\",\"parent_id\":115,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict-data:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:16:20+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:16:20+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":147,\"menu_name\":\"字典数据删除\",\"parent_id\":115,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict-data:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:17:15+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:17:15+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":146,\"menu_name\":\"字典数据修改\",\"parent_id\":115,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:dict-data:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:16:59+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:16:59+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]},{\"id\":94,\"menu_name\":\"参数设置\",\"parent_id\":53,\"order_num\":8,\"url\":\"/management/config\",\"menu_type\":1,\"visible\":1,\"perms\":\"\",\"icon\":\"cubes\",\"is_frame\":2,\"component\":\"management/config\",\"create_by\":0,\"created_at\":\"2019-10-28T20:26:04+08:00\",\"update_by\":1,\"updated_at\":\"2019-12-22T18:50:27+08:00\",\"remark\":\"\",\"route_name\":\"management-config\",\"route_path\":\"management/config\",\"route_cache\":2,\"route_component\":\"management/config\",\"children_list\":[{\"id\":131,\"menu_name\":\"参数删除\",\"parent_id\":94,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:config:remove\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:07:37+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:07:37+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":130,\"menu_name\":\"参数修改\",\"parent_id\":94,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:config:edit\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:06:46+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:06:46+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":129,\"menu_name\":\"参数新增\",\"parent_id\":94,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:config:add\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:06:30+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:06:30+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]},{\"id\":128,\"menu_name\":\"参数查询\",\"parent_id\":94,\"order_num\":0,\"url\":\"\",\"menu_type\":2,\"visible\":1,\"perms\":\"system:config:query\",\"icon\":\"\",\"is_frame\":0,\"component\":\"\",\"create_by\":1,\"created_at\":\"2019-12-22T18:06:01+08:00\",\"update_by\":0,\"updated_at\":\"2019-12-22T18:06:01+08:00\",\"remark\":\"\",\"route_name\":\"\",\"route_path\":\"\",\"route_cache\":0,\"route_component\":\"\",\"children_list\":[]}]}]}],\"msg\":\"OK\",\"time_stamp\":\"2020-04-06T14:12:28.909935396+08:00\"}");
        }
        /// <summary>
        /// Gets the child menus.
        /// </summary>
        /// <param name="menuId">The menu identifier.</param>
        /// <param name="sysMenus">The system menus.</param>
        /// <returns>IEnumerable&lt;MenuResult&gt;.</returns>
        [NonAction]
        private IEnumerable<MenuResult> GetChildMenus(int menuId, List<SysMenu> sysMenus)
        {
            if (sysMenus.IsEmpty() || !sysMenus.Exists(a => a.ParentId == menuId))
            {
                return new MenuResult[] { };
            }
           return from item in sysMenus.Where(a => a.ParentId == menuId).OrderBy(a=>a.OrderNum)
                                      select new MenuResult
                                      {
                                          Id = item.Id,
                                          MenuName = item.MenuName,
                                          ParentId = item.ParentId,
                                          OrderNum = item.OrderNum,
                                          Url = item.Url,
                                          MenuType = item.MenuType,
                                          Visible = item.Visible,
                                          IsFrame = (byte)(item.MenuType == 1 ? 2 : 0),
                                          Component =item.MenuType==1?item.Url?.Trim('/'):string.Empty,
                                          Perms = item.Perms,
                                          Icon = item.Icon,
                                          CreateBy = item.CreateBy,
                                          CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                                          UpdateBy = item.UpdateBy,
                                          UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                                          Remark = item.Remark,
                                          ChildrenList = GetChildMenus(item.Id, sysMenus),
                                          RouteCache = (byte)(item.MenuType == 1 ? 2 : 0),
                                          RouteComponent = item.MenuType == 1 ? item.Url?.Trim('/') : string.Empty,
                                          RouteName = item.MenuType == 1 ? item.Url?.Trim('/').Replace("/","-") : string.Empty,
                                          RoutePath = item.MenuType == 1 ? item.Url?.Trim('/') : string.Empty,
                                      };
        }
    }
}
