// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-07
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-07
// ***********************************************************************
// <copyright file="RoleController.cs" company="Noob.D2CMSApi">
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
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
using Noob.D2CMSApi.Models.Results;
using Noob.Extensions;
namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class RoleController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class RoleController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictDataController" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RoleController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="initDatas">The initialize datas.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<RoleResult> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysRole> insertDatas = new List<SysRole>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysRole.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysRole.AddRange(insertDatas.ToArray());
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
        private void HandleRequestData(RoleResult item, List<SysRole> list)
        {
            if (item == null)
            {
                return;
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new NullableIntUtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<RoleResult, SysRole>();
            });
            //mapConfig.AssertConfigurationIsValid();
            var result = item.MapTo<RoleResult, SysRole>(mapConfig);
            list.Add(result);
        }

        /// <summary>
        /// Indexes the specified request.
        /// </summary>
        /// <param name="model">The request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(RoleQuery model)
        {
            var response = new ResponseResult<PaggingResult<RoleResult>>();
            List<SysRole> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysRole.ToList();
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysRole, RoleResult>();
            });
            var datas = allDataList.MapTo<SysRole, RoleResult
                >(mapConfig);
            return Ok(response.Success("数据获取成功", new PaggingResult<RoleResult>(new Pagging(model.Page, model.PageSize, allDataList.Count), datas)));
        }
    }
}
