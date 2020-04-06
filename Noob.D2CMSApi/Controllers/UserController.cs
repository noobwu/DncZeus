﻿// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="UserController.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Noob.D2CMSApi.Auth;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;
namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class UserController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly AppAuthenticationSettings _appSettings;
        /// <summary>
        /// The database context
        /// </summary>
        private readonly D2CmsDbContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="dbContext">The database context.</param>
        public UserController(IOptions<AppAuthenticationSettings> appSettings, D2CmsDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="list">The menus.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<UserResult> list)
        {
            var response = new ResponseResult<UserResult>();
            if (list.IsEmpty())
            {
                return Ok(response.Error((int)ResponseCode.ERROR, "菜单数据不能为空"));
            }
            List<SysUser> insertList = new List<SysUser>();
            list.Each(a =>
            {
                HandleData(a, insertList);
            });
            insertList = insertList.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysUser.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error((int)ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysUser.AddRange(insertList.ToArray());
                    _dbContext.SaveChanges();
                    return Ok(response.Error((int)ResponseCode.ERROR, "数据初始化成功"));
                }
            }
        }
        /// <summary>
        /// Handles the data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="list">The list.</param>
        [NonAction]
        private void HandleData(UserResult item, List<SysUser> list)
        {
            if (item == null)
            {
                return;
            }
            list.Add(new SysUser(item.Id)
            {
                LoginName = item.LoginName,
                UserName = item.UserName,
                UserType = item.UserType,
                Email = item.Email,
                Phone = item.Phone,
                Phonenumber = item.Phonenumber,
                Sex = item.Sex,
                Avatar = item.Avatar,
                Password = item.Password,
                Salt = item.Salt,
                Status = item.Status,
                DelFlag = item.DelFlag,
                LoginIp = item.LoginIp,
                LoginDate = (int)item.LoginDate.UtcTimeToUnixTime(),
                CreateBy = item.CreateBy,
                CreatedAt = (int)item.CreatedAt.UtcTimeToUnixTime(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = (int)item.UpdatedAt.UtcTimeToUnixTime(),
                DeletedAt = item.DeletedAt.UtcTimeToNullableDateTime(),
                Remark = item.Remark,
            });
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var response = new ResponseResult<LoginResult>();
            SysUser user;
            using (_dbContext)
            {
                user = _dbContext.SysUser.FirstOrDefault(x => x.UserName == loginRequest.UserName);
                if (user == null || (user.DelFlag.HasValue && user.DelFlag.Value == 1))
                {
                    return Ok(response.Error((int)ResponseCode.USER_NOT_EXIST, "用户不存在"));
                }
            }
            var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.LoginName??string.Empty),
                    new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
                    new Claim("avatar",user.Avatar??string.Empty),
                });
            var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_appSettings, claimsIdentity);

            return Ok(response.Success("登录成功", new LoginResult()
            {
                Nickname=user.UserName,
                Token=token,
                UserId=user.Id,
                UserName=user.LoginName
            }));
        }
    }
}
