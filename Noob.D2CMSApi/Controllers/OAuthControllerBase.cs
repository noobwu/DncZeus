﻿// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="OAuthControllerBase.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noob.D2CMSApi.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class OAuthControllerBase.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class OAuthControllerBase : ControllerBase
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly D2CmsDbContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthControllerBase"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public OAuthControllerBase(D2CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
