// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-07
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-07
// ***********************************************************************
// <copyright file="ConfigsController.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;

namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class ConfigsController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class ConfigsController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigsController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ConfigsController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="initDatas"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<ConfigsResult> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysConfigs> insertDatas = new List<SysConfigs>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysConfigs.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysConfigs.AddRange(insertDatas.ToArray());
                    _dbContext.SaveChanges();
                    return Ok(response.Success("数据初始化成功", true));
                }
            }
        }
        /// <summary>
        /// Handles the request data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="list">The list.</param>
        [NonAction]
        private void HandleRequestData(ConfigsResult item, List<SysConfigs> list)
        {
            if (item == null)
            {
                return;
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new IntUtcTimeTypeConverter());
                cfg.CreateMap<DateTime, DateTime>().ConvertUsing(new UtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<ConfigsResult, SysConfigs>();
            });
            //mapConfig.AssertConfigurationIsValid();
            SysConfigs result = item.MapTo<ConfigsResult, SysConfigs>(mapConfig);
            list.Add(result);
        }
    }
}
