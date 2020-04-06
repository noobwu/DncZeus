// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="AuthContextService.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Noob.D2CMSApi.Entities;
using Noob.Extensions;
using System;
using System.Security.Claims;

namespace Noob.D2CMSApi.OAuth.AuthContext
{
    /// <summary>
    /// Class AuthContextService.
    /// </summary>
    public static class AuthContextService
    {
        /// <summary>
        /// The context
        /// </summary>
        private static IHttpContextAccessor _context;
        /// <summary>
        /// Configures the specified HTTP context accessor.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public static HttpContext Current => _context.HttpContext;
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        public static AuthContextUser CurrentUser
        {
            get
            {
                var user = new AuthContextUser
                {
                    UserId= Current.User.FindFirstValue(ClaimTypes.PrimarySid).To(0),
                    LoginName = Current.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    UserName = Current.User.FindFirstValue(ClaimTypes.Name),
                    Email = Current.User.FindFirstValue(ClaimTypes.Email),
                    UserType = (UserType)Current.User.FindFirstValue(ClaimTypes.Role).To(0),
                    Avator= Current.User.FindFirstValue("Avator")
                };
                return user;
            }
        }

        /// <summary>
        /// 是否已授权
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        public static bool IsAuthenticated
        {
            get
            {
                return Current.User.Identity.IsAuthenticated;
            }
        }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        /// <value><c>true</c> if this instance is supper administator; otherwise, <c>false</c>.</value>
        public static bool IsSupperAdministator
        {
            get
            {
                return CurrentUser.UserType == UserType.SuperAdministrator;
            }
        }
    }
}
