// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models.Requests;
using Noob.D2CMSApi.Models.Responses;
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
        /// Initializes a new instance of the <see cref="DictDataController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public DictDataController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="initDatas"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<DictDataResult> initDatas)
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
        private void HandleRequestData(DictDataResult item, List<SysDictData> list)
        {
            if (item == null)
            {
                return;
            }
            list.Add(new SysDictData(item.Id)
            {
                DictCode = item.DictCode,
                DictSort = item.DictSort,
                DictLabel = item.DictLabel,
                DictValue = item.DictValue,
                DictType = item.DictType,
                CssClass = item.CssClass,
                ListClass = item.ListClass,
                IsDefault = item.IsDefault,
                Status = item.Status,
                CreateBy = item.CreateBy,
                CreatedAt = (int)item.CreatedAt?.UtcTimeToUnixTime(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = (int)item.UpdatedAt.UtcTimeToUnixTime(),
                Remark = item.Remark,
            });
        }

        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(DictDataQueryRequest request)
        {
            var response = new ResponseResult<PaggingResult<DictDataResult>>();
            List<SysDictData> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysDictData.ToList();
            }
            var datas = from item in allDataList
                        select new DictDataResult
                        {
                            Id = item.Id,
                            DictCode = item.DictCode,
                            DictSort = item.DictSort,
                            DictLabel = item.DictLabel,
                            DictValue = item.DictValue,
                            DictType = item.DictType,
                            CssClass = item.CssClass,
                            ListClass = item.ListClass,
                            IsDefault = item.IsDefault,
                            Status = item.Status,
                            CreateBy = item.CreateBy,
                            CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                            UpdateBy = item.UpdateBy,
                            UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                            Remark = item.Remark,
                        };
            return Ok(response.Success("数据获取成功", new PaggingResult<DictDataResult>(new Pagging(request.Page, request.PageSize, allDataList.Count), datas)));
        }
    }
}
