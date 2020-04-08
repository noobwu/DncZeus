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
using Noob.D2CMSApi.Models.Responses.System;
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
        /// Initializes a new instance of the <see cref="DictDataController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RoleController(D2CmsDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="initDatas"></param>
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
            list.Add(new SysRole(item.Id)
            {
                RoleName = item.RoleName,
                RoleKey = item.RoleKey,
                RoleSort = item.RoleSort,
                DataScope = item.DataScope,
                Status = item.Status,
                DelFlag = item.DelFlag,
                CreateBy = item.CreateBy,
                CreatedAt = (int)item.CreatedAt?.UtcTimeToUnixTime(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = (int)item.UpdatedAt?.UtcTimeToUnixTime(),
                Remark = item.Remark,
            });
        }

        /// <summary>
        /// Indexes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(RoleQueryRequest request)
        {
            var response = new ResponseResult<PaggingResult<RoleResult>>();
            List<SysRole> allDataList = null;
            using (_dbContext)
            {
                allDataList = _dbContext.SysRole.ToList();
            }
            var datas = from item in allDataList
                        select new RoleResult
                        {
                            Id = item.Id,
                            RoleName = item.RoleName,
                            RoleKey = item.RoleKey,
                            RoleSort = item.RoleSort,
                            DataScope = item.DataScope,
                            Status = item.Status,
                            DelFlag = item.DelFlag,
                            CreateBy = item.CreateBy,
                            CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                            UpdateBy = item.UpdateBy,
                            UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                            Remark = item.Remark,
                        };
            return Ok(response.Success("数据获取成功", new PaggingResult<RoleResult>(new Pagging(request.Page, request.PageSize, allDataList.Count), datas)));
        }
    }
}
