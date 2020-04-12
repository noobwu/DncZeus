// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-08
// ***********************************************************************
// <copyright file="DeptController.cs" company="Noob.D2CMSApi">
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
using Noob.D2CMSApi.Models.Responses;
using Noob.Extensions;
namespace Noob.D2CMSApi.Controllers
{
    /// <summary>
    /// Class DeptController.
    /// Implements the <see cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Controllers.OAuthControllerBase" />
    public class DeptController : OAuthControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public DeptController(D2CmsDbContext dbContext) : base(dbContext) { }
        /// <summary>
        /// Initializes the specified initialize datas.
        /// </summary>
        /// <param name="initDatas">The initialize datas.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Init(IEnumerable<DeptResult> initDatas)
        {
            var response = new ResponseResult<bool>();
            if (initDatas.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR, "数据不能为空"));
            }
            List<SysDept> insertDatas = new List<SysDept>();
            initDatas.Each(a =>
            {
                HandleRequestData(a, insertDatas);
            });
            insertDatas = insertDatas.DistinctBy(p => new { p.Id }).OrderBy(a => a.Id).ToList();
            using (_dbContext)
            {
                if (_dbContext.SysDept.Count(a => a.Id > 0) > 0)
                {
                    return Ok(response.Error(ResponseCode.ERROR, "数据已初始化"));
                }
                else
                {
                    _dbContext.SysDept.AddRange(insertDatas.ToArray());
                    _dbContext.SaveChanges();
                    return Ok(response.Success("数据初始化成功",true));
                }
            }
        }
        /// <summary>
        /// Handles the request data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="list">The list.</param>
        [NonAction]
        private void HandleRequestData(DeptResult item, List<SysDept> list)
        {
            if (item == null)
            {
                return;
            }
            list.Add(new SysDept(item.Id)
            {
                ParentId = item.ParentId,
                Ancestors = item.Ancestors,
                DeptName = item.DeptName,
                OrderNum = item.OrderNum,
                Leader = item.Leader,
                Phone = item.Phone,
                Email = item.Email,
                Status = item.Status,
                DelFlag = item.DelFlag,
                CreateBy = item.CreateBy,
                CreatedAt = (int)item.CreatedAt?.UtcTimeToUnixTime(),
                UpdateBy = item.UpdateBy,
                UpdatedAt = (int)item.UpdatedAt?.UtcTimeToUnixTime(),
                Remark = item.Remark,
            });
            if (item.ChildrenList.IsAny())
            {
                item.ChildrenList.Each(a =>
                {
                    HandleRequestData(a, list);
                });
            }
        }

        /// <summary>
        /// Checks the token.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpPost("/api/dept/findall")]
        public IActionResult GetAllDepts()
        {
            var response = new ResponseResult<IEnumerable<DeptResult>>();
            List<SysDept> dataList = null;
            using (_dbContext)
            {
                dataList = _dbContext.SysDept.ToList();
            }
            if (dataList.IsEmpty())
            {
                return Ok(response.Error(ResponseCode.ERROR_CODE__DB__NO_ROW, "请先添加数据"));
            }
            var menuResults = from item in dataList.Where(a => a.ParentId == 0).OrderBy(a => a.OrderNum)
                              select new DeptResult
                              {
                                  Id = item.Id,
                                  ParentId = item.ParentId,
                                  Ancestors = item.Ancestors,
                                  DeptName = item.DeptName,
                                  OrderNum = item.OrderNum,
                                  Leader = item.Leader,
                                  Phone = item.Phone,
                                  Email = item.Email,
                                  Status = item.Status,
                                  DelFlag = item.DelFlag,
                                  CreateBy = item.CreateBy,
                                  CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                                  UpdateBy = item.UpdateBy,
                                  UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                                  Remark = item.Remark,
                                  ChildrenList = GetChildDatas(item.Id, dataList)
                              };
            return Ok(response.Success("数据获取成功", menuResults));
        }

        /// <summary>
        /// Gets the child menus.
        /// </summary>
        /// <param name="id">The menu identifier.</param>
        /// <param name="allDatas">The system menus.</param>
        /// <returns>IEnumerable&lt;MenuResult&gt;.</returns>
        [NonAction]
        private IEnumerable<DeptResult> GetChildDatas(int id, List<SysDept> allDatas)
        {
            if (allDatas.IsEmpty() || !allDatas.Exists(a => a.ParentId == id))
            {
                return new DeptResult[] { };
            }
            return from item in allDatas.Where(a => a.ParentId == id).OrderBy(a => a.OrderNum)
                   select new DeptResult
                   {
                       Id = item.Id,
                       ParentId = item.ParentId,
                       Ancestors = item.Ancestors,
                       DeptName = item.DeptName,
                       OrderNum = item.OrderNum,
                       Leader = item.Leader,
                       Phone = item.Phone,
                       Email = item.Email,
                       Status = item.Status,
                       DelFlag = item.DelFlag,
                       CreateBy = item.CreateBy,
                       CreatedAt = item.CreatedAt?.ToUtcDateTimeString(),
                       UpdateBy = item.UpdateBy,
                       UpdatedAt = item.UpdatedAt?.ToUtcDateTimeString(),
                       Remark = item.Remark,
                       ChildrenList = GetChildDatas(item.Id, allDatas),
                   };
        }
    }
}
