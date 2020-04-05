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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Noob.D2CMSApi.Auth;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;

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
