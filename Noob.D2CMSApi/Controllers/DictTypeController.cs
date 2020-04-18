using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noob.D2CMSApi.Entities;
using Noob.D2CMSApi.EntityFrameworkCore;
using Noob.D2CMSApi.Models;
using Noob.D2CMSApi.Models.Querys;
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;
using Z.EntityFramework.Plus;

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
            var mapConfig = new MapperConfiguration(cfg =>
            {
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
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysDictType, DictTypeModel>();
            });
            var datas = allDataList.MapTo<SysDictType, DictTypeModel>(mapConfig);
            return Ok(response.Success("数据获取成功", new PaggingResult<DictTypeModel>(new Pagging(model.Page, model.PageSize, allDataList.Count), datas)));
        }

        /// <summary>
        /// Updates the specified user model.
        /// </summary>
        /// <param name="dynamicModel">The user model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/dict/update")]
        public IActionResult Get(dynamic dynamicModel)
        {
            var response = new ResponseResult<DictTypeModel>();
            if (dynamicModel == null || dynamicModel.id < 1)
            {
                return Ok(response.Error(ResponseCode.INVALID_PARAMS, "该数据不存在"));
            }
            int id = dynamicModel.id;
            SysDictType model = null;
            using (_dbContext)
            {
                model = _dbContext.SysDictType.SingleOrDefault(a => a.Id == id);
            }
            if (model == null)
            {
                return Ok(response.Error(ResponseCode.ERROR_CODE__DB__NO_ROW, "该数据不存在"));
            }
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<int?, string>().ConvertUsing(new UtcStringTimeTypeConverter());
                cfg.CreateMap<DateTime?, string>().ConvertUsing(new UtcDateTimeTypeConverter());
                cfg.CreateMap<SysDictType, DictTypeModel>();
            });
            var data = model.MapTo<SysDictType, DictTypeModel>(mapConfig);
            return Ok(response.Success("数据获取成功", data));
        }
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut("/api/dict/update")]
        public IActionResult Update(DictTypeModel model)
        {
            var response = new ResponseResult<bool>();
            using (_dbContext)
            {
                if (_dbContext.SysDictType.Count(a => a.DictName == model.DictName && a.Id != model.Id) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "该名称已存在"));
                }
                if (_dbContext.SysDictType.Count(a => a.DictType == model.DictType && a.Id != model.Id) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "该标识已存在"));
                }
                var mapConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<string, int?>().ConvertUsing(new NullableIntUtcTimeTypeConverter());
                    cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                    cfg.CreateMap<DictTypeModel, SysDictType>();
                });
                //mapConfig.AssertConfigurationIsValid();
                var entity = model.MapTo<DictTypeModel, SysDictType>(mapConfig);
                _dbContext.Entry(entity).State = EntityState.Modified;
                int result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(response.Success("数据更新成功", true));
                }
                else
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据更新失败"));
                }
            }
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut("/api/dict/create")]
        public IActionResult Create(DictTypeModel model)
        {
            var response = new ResponseResult<bool>();
            using (_dbContext)
            {
                if (_dbContext.SysDictType.Count(a => a.DictName == model.DictName) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "该名称已存在"));
                }
                if (_dbContext.SysDictType.Count(a => a.DictType == model.DictType) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "该标识已存在"));
                }
                var mapConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<string, int?>().ConvertUsing(new NullableIntUtcTimeTypeConverter());
                    cfg.CreateMap<string, DateTime?>().ConvertUsing(new NullableUtcTimeTypeConverter());
                    cfg.CreateMap<DictTypeModel, SysDictType>();
                });
                //mapConfig.AssertConfigurationIsValid();
                var entity = model.MapTo<DictTypeModel, SysDictType>(mapConfig);
                _dbContext.Add(entity);
                int result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(response.Success("数据提交成功", true));
                }
                else
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据提交失败"));
                }
            }
        }

        /// <summary>
        /// Deletes the specified dynamic model.
        /// </summary>
        /// <param name="dynamicModel">The dynamic model.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("/api/dict/delete")]
        public IActionResult Delete(dynamic dynamicModel)
        {
            var response = new ResponseResult<bool>();
            if (dynamicModel == null || dynamicModel.id < 1)
            {
                return Ok(response.Error(ResponseCode.INVALID_PARAMS, "该数据不存在"));
            }
            int id = dynamicModel.id;
            using (_dbContext)
            {
                var entity = _dbContext.SysDictType.SingleOrDefault(a=>a.Id==id);
                if (entity == null)
                {
                    return Ok(response.Error(ResponseCode.INVALID_PARAMS, "该数据不存在"));
                }
                _dbContext.SysDictType.Remove(entity);
                int result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(response.Success("数据提交成功", true));
                }
                else
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据提交失败"));
                }
                //int result= _dbContext.Set<SysDictType>().Where(a=>a.Id==id).Delete();
            }
               
        }
    }
}
