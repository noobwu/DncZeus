// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-07
// ***********************************************************************
// <copyright file="DictDataController.cs" company="Noob.D2CMSApi">
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
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
using Noob.Expressions;
using Noob.Extensions;
namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class DictDataController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class DictDataController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictDataController" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public DictDataController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Initializes the specified initialize datas.
        /// </summary>
        /// <param name="initDatas">The initialize datas.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<DictDataModel> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysDictData> insertDatas = new List<SysDictData>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysDictData.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysDictData.AddRange(insertDatas.ToArray());
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
        private void HandleRequestData(DictDataModel item, List<SysDictData> list)
        {
            if (item == null)
            {
                return;
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new NullableIntUtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<DictDataModel, SysDictData>();
            });
            //mapConfig.AssertConfigurationIsValid();
            var result = item.MapTo<DictDataModel, SysDictData>(mapConfig);
            list.Add(result);
        }

        /// <summary>
        /// Indexes the specified request.
        /// </summary>
        /// <param name="model">The request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(DictDataQuery model)
        {
            var response = new ResponseResult<PaggingResult<DictDataModel>>();
            List<SysDictData> allDataList = null;
            var predicate= PredicateBuilder.True<SysDictData>();
            if (!string.IsNullOrEmpty(model.DictType))
            {
                predicate = predicate.And(a => a.DictType == model.DictType);
            }
            if (model.DictTypeId > 0)
            {
                predicate = predicate.And(a=>a.DictTypeId==model.DictTypeId);
            }
            if (!string.IsNullOrEmpty(model.DictLabel))
            {
                predicate = predicate.And(a => a.DictLabel == model.DictLabel);
            }
            if (!string.IsNullOrEmpty(model.DictValue))
            {
                predicate = predicate.And(a => a.DictValue == model.DictValue);
            }
            if (model.Status>0)
            {
                predicate = predicate.And(a => a.Status == model.Status);
            }
            using (_dbContext)
            {
                allDataList = (from dict in _dbContext.SysDictData
                         join dictType in _dbContext.SysDictType on dict.DictTypeId equals dictType.Id
                          select new SysDictData(dict, dictType.DictValueType)).Where(predicate).ToList();
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysDictData, DictDataModel>();
            });
            var datas = allDataList.MapTo<SysDictData, DictDataModel>(mapConfig);
            return Ok(response.Success("数据获取成功", new PaggingResult<DictDataModel>(new Pagging(model.Page, model.PageSize, allDataList.Count), datas)));
        }

        /// <summary>
        /// Updates the specified user model.
        /// </summary>
        /// <param name="dynamicModel">The user model.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Update(dynamic dynamicModel)
        {
            var response = new ResponseResult<DictDataModel>();
            if (dynamicModel == null || dynamicModel.id < 1)
            {
                return Ok(response.Error(ResponseCode.INVALID_PARAMS, "该数据不存在"));
            }
            int id = dynamicModel.id;
            SysDictData model = null;
            using (_dbContext)
            {
                (from dict in _dbContext.SysDictData
                 join dictType in _dbContext.SysDictType on dict.DictTypeId equals dictType.Id
                 where dict.Id == id
                 select new SysDictData(dict, dictType.DictValueType)).FirstOrDefault();
            }
            if (model == null)
            {
                return Ok(response.Error(ResponseCode.ERROR_CODE__DB__NO_ROW, "该数据不存在"));
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysDictData, DictDataModel>();
            });
            var data = model.MapTo<SysDictData, DictDataModel>(mapConfig);
            return Ok(response.Success("数据获取成功", data));
        }
    }
}
