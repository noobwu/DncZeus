// ***********************************************************************
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
using Noob.D2CMSApi.OAuth;
using Noob.D2CMSApi.OAuth.AuthContext;
using Noob.Extensions;
namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class UserController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class UserController : OAuthControllerBase
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly AppAuthenticationSettings _appSettings;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="dbContext">The database context.</param>
        public UserController(IOptions<AppAuthenticationSettings> appSettings, D2CmsDbContext dbContext):base(dbContext)
        {
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(UserQueryRequest request)
        {
            var response = new ResponseResult<PaggingResult<UserResult>>();
            List<SysUser> sysUsers = null;
            using (_dbContext)
            {
                sysUsers = _dbContext.SysUser.ToList();
            }
            var users = from item in sysUsers select new UserResult {
                Id = item.Id,
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
                LoginDate = item.LoginDate?.ToUtcDateTimeString(),
                CreateBy = item.CreateBy,
                CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                DeletedAt = item.DeletedAt?.ToString(DateTimeExtensions.UtcDateTimeFormat),
                Remark = item.Remark,

            };
            return Ok(response.Success("数据获取成功",new PaggingResult<UserResult>(new Pagging(request.Page,request.PageSize,sysUsers.Count), users)));
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="list">The menus.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<UserResult> list)
        {
            var response = new ResponseResult<bool>();
            if (list.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
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
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysUser.AddRange(insertList.ToArray());
                    _dbContext.SaveChanges();
                    return Ok(response.Success("数据初始化成功",true));
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
                LoginName = item.UserName,
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
        /// <param name="request"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest request)
        {
            var response = new ResponseResult<LoginResult>();
            if (!ModelState.IsValid)
            {
                return Ok(response.Error(ResponseCode.INVALID_PARAMS, GetErrorMsgFromModelState()));
            }
            SysUser user;
            using (_dbContext)
            {
                user = _dbContext.SysUser.FirstOrDefault(x => x.UserName == request.UserName);
                if (user == null || (user.DelFlag.HasValue && user.DelFlag.Value == 1))
                {
                    return Ok(response.Error(ResponseCode.USER_NOT_EXIST, "用户不存在"));
                }
                if (user.Password?.ToLower() != (request.Password + user.Salt).ToMD5Hash())
                {
                    return Ok(response.Error(ResponseCode.USER_NOT_EXIST, "密码错误"));
                }
            }
            var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.LoginName??string.Empty),
                    new Claim(ClaimTypes.Email, user.Email??string.Empty),
                    new Claim(ClaimTypes.Name, user.UserName??string.Empty),
                    new Claim(ClaimTypes.Role,user.UserType.ToString()),
                    new Claim("Avatar",user.Avatar??string.Empty),
                });
            var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_appSettings, claimsIdentity);

            return Ok(response.Success("登录成功", new LoginResult()
            {
                Nickname = user.UserName,
                Token = token,
                UserId = user.Id,
                UserName = user.LoginName
            }));
        }
        /// <summary>
        /// Checks the token.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/user/check_token")]
        [AllowAnonymous]
        //[Authorize]
        public IActionResult CheckToken()
        {
            var response = new ResponseResult<CheckTokenResult>();
            SysUser user;
            using (_dbContext)
            {
                user = _dbContext.SysUser.FirstOrDefault(x => x.Id == AuthContextService.CurrentUser.UserId);
            }
            if (user == null || (user.DelFlag.HasValue && user.DelFlag.Value == 1))
            {
                user = new SysUser(0)
                {
                    LoginName = "D2Cms"
                };
            }
            return Ok(response.Success("登录成功", new CheckTokenResult()
            {
                UserId = user.Id,
                UserName = user.LoginName
            }));
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logout()
        {
            var response = new ResponseResult<bool>();
            return Ok(response.Success("注销成功", true));
        }
    }
}
