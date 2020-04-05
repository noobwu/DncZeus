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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noob.D2CMSApi.Auth;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;

namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class MenuController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
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
            sysMenus = sysMenus.DistinctBy(p => new { p.Id }).OrderBy(o=> new {o.Id }).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysMenu.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单已初始化"));
                }
                else
                {
                    _dbContext.SysMenu.AddRange(sysMenus.ToArray());
                    return Ok(response.Error((int)ResponseCode.ERROR, "菜单初始化成功"));
                }
            }
        }
        /// <summary>
        /// Handles the menu data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="sysMenus">The system menus.</param>
        private void HandleMenuData(MenuResult item, List<SysMenu> sysMenus)
        {
            if (item == null)
            {
                return;
            }
            if (item.ChildrenList.IsEmpty())
            {
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
            }
            else
            {
                item.ChildrenList.Each(a => {
                    HandleMenuData(a, sysMenus);
                });
            }
        }
    }
}
