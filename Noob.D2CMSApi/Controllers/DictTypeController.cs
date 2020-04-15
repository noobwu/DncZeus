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
using Noob.D2CMSApi.Models.Querys;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;

namespace Noob.D2CMSApi.Controllers
{

    /// <summary>
    /// Class DictController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class DictTypeController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictTypeController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public DictTypeController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Initializes the specified initialize datas.
        /// </summary>
        /// <param name="initDatas">The initialize datas.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/dict/init")]
        public IActionResult Init(IEnumerable<DictTypeModel> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysDictType> insertDatas = new List<SysDictType>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysDictType.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysDictType.AddRange(insertDatas.ToArray());
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
        private void HandleRequestData(DictTypeModel item, List<SysDictType> list)
        {
            if (item == null)
            {
                return;
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int?>().ConvertUsing(new NullableIntUtcTimeTypeConverter());
                cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                cfg.CreateMap<DictTypeModel, SysDictType>();
            });
            //mapConfig.AssertConfigurationIsValid();
            var result = item.MapTo<DictTypeModel, SysDictType>(mapConfig);
            list.Add(result);
        }

        /// <summary>
        /// Indexes the specified request.
        /// </summary>
        /// <param name="model">The request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/dict/index")]
        public IActionResult Index(DictTypeQuery model)
        {
            var response = new ResponseResult<PaggingResult<DictTypeModel>>();
            List<SysDictType> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysDictType.ToList();
            }
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysDictType, DictTypeModel>();
            });
            var datas = allDataList.MapTo<SysDictType, DictTypeModel>(mapConfig);
            return Ok(response.Success("数据获取成功", new PaggingResult<DictTypeModel>(new Pagging(model.Page, model.PageSize, allDataList.Count), datas)));
        }
    }
}
