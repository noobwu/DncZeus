// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="PostController.cs" company="Noob.D2CMSApi">
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
using Noob.D2CMSApi.Models;
using Noob.D2CMSApi.Models.Requests.System.Query;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;

namespace Noob.D2CMSApi.Controllers
{

    /// <summary>
    /// Class PostController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class PostController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigsController" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PostController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="initDatas">The initialize datas.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<PostModel> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysPost> insertDatas = new List<SysPost>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysPost.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysPost.AddRange(insertDatas.ToArray());
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
        private void HandleRequestData(PostModel item, List<SysPost> list)
        {
            if (item == null)
            {
                return;
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new IntUtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<PostModel, SysPost>();
            });
            //mapConfig.AssertConfigurationIsValid();
            var result = item.MapTo<PostModel, SysPost>(mapConfig);
            list.Add(result);
        }

        /// <summary>
        /// Indexes the specified query model.
        /// </summary>
        /// <param name="model">The query model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(PostQuery model)
        {
            var response = new ResponseResult<PaggingResult<PostModel>>();
            List<SysPost> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysPost.ToList();
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysPost, PostModel>();
            });
            var datas = allDataList.MapTo<SysPost, PostModel>(mapConfig);
            return Ok(response.Success("数据获取成功", new PaggingResult<PostModel>(new Pagging(model.Page, model.PageSize, allDataList.Count), datas)));
        }
    }
}
