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
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
using Noob.D2CMSApi.Models.Results;
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
        /// <param name="initDatas">The menus.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<UserResult> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysUser> insertList = new List<SysUser>();
            initDatas.Each(a =>
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
                    return Ok(response.Success("数据初始化成功", true));
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
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new IntUtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<UserResult, SysUser>();
            });
            //mapConfig.AssertConfigurationIsValid();
            var result = item.MapTo<UserResult, SysUser>(mapConfig);
            list.Add(result);
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(UserQuery model)
        {
            var response = new ResponseResult<PaggingResult<UserResult>>();
            List<SysUser> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysUser.ToList();
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysUser, UserResult>();
            });
            var datas = allDataList.MapTo<SysUser, UserResult>(mapConfig);
            return Ok(response.Success("数据获取成功",new PaggingResult<UserResult>(new Pagging(model.Page,model.PageSize,allDataList.Count), datas)));
        }
        /// <summary>
        /// Updates the specified user model.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Update(dynamic userModel)
        {
            var response = new ResponseResult<UserResult>();
            if (userModel==null||userModel.id < 1)
            {
                return Ok(response.Error(ResponseCode.INVALID_PARAMS, "该用户不存在"));
            }
            int userId = userModel.id;
            SysUser model = null;
            using (_dbContext)
            {
                model = _dbContext.SysUser.FirstOrDefault(a=>a.Id== userId);
            }
            if (model == null)
            {
                return Ok(response.Error(ResponseCode.USER_NOT_EXIST, "该用户不存在"));
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysUser, UserResult>();
            });
            var data = model.MapTo<SysUser, UserResult>(mapConfig);
            data.UserPost = model.PostId;
            data.UserRole = model.RoleId;
            return Ok(response.Success("数据获取成功", data));
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            var response = new ResponseResult<LoginResult>();
            //if (!ModelState.IsValid)
            //{
            //    return Ok(response.Error(ResponseCode.INVALID_PARAMS, GetErrorMsgFromModelState()));
            //}
            SysUser user;
            using (_dbContext)
            {
                user = _dbContext.SysUser.FirstOrDefault(x => x.UserName == model.UserName);
                if (user == null || (user.DelFlag.HasValue && user.DelFlag.Value == 1))
                {
                    return Ok(response.Error(ResponseCode.USER_NOT_EXIST, "用户不存在"));
                }
                if (user.Password?.ToLower() != (model.Password + user.Salt).ToMD5Hash())
                {
                    return Ok(response.Error(ResponseCode.USER_NOT_EXIST, "密码错误"));
                }
            }
            var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName??string.Empty),
                    new Claim(ClaimTypes.Email, user.Email??string.Empty),
                    new Claim(ClaimTypes.Name, user.Nickname??string.Empty),
                    new Claim(ClaimTypes.Role,user.UserType.ToString()),
                    new Claim("Avatar",user.Avatar??string.Empty),
                });
            var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_appSettings, claimsIdentity);

            return Ok(response.Success("登录成功", new LoginResult()
            {
                Nickname = user.Nickname,
                Token = token,
                UserId = user.Id,
                UserName = user.UserName
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
                    UserName = "D2Cms"
                };
            }
            return Ok(response.Success("登录成功", new CheckTokenResult()
            {
                UserId = user.Id,
                UserName = user.UserName
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
