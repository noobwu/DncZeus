// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-06
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="PaggingResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// Class PaggingResult.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PaggingResult<T>  where T : ModelBase
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public Pagging Page { get; private set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("list")]
        public IEnumerable<T> List { get;private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaggingResult{T}" /> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="list">The list.</param>
        public PaggingResult(Pagging page, IEnumerable<T> list)
        {
            this.Page = page;
            this.List = list;
        }
    }
    /// <summary>
    /// Class Pagging.
    /// </summary>
    [Serializable]
    public class Pagging
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagging" /> class.
        /// </summary>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalCount">The total count.</param>
        public Pagging(int pageNo,int pageSize,int totalCount)
        {
            if (pageNo < 1) pageNo = 1;
            if (pageSize < 1) pageSize = 1;
            if (totalCount < 0) totalCount = 0;
            PageNo = pageNo;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPage = totalCount % pageSize == 0 ? totalCount / pageSize : (totalCount / pageSize) + 1;
            if (PageNo == 1) IsFirstPage = true;
            if (PageNo == TotalPage) IsLastPage = true;
        }
        /// <summary>
        /// Gets or sets the page no.
        /// </summary>
        /// <value>The page no.</value>
        [JsonProperty("page_no")]
        public int PageNo { get;private set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [JsonProperty("page_size")]
        public int PageSize { get; private set; }
        /// <summary>
        /// Gets or sets the total page.
        /// </summary>
        /// <value>The total page.</value>
        [JsonProperty("total_page")]
        public int TotalPage { get; private set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        [JsonProperty("total_count")]
        public int TotalCount { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is first page.
        /// </summary>
        /// <value><c>true</c> if this instance is first page; otherwise, <c>false</c>.</value>
        [JsonProperty("is_first_page")]
        public bool IsFirstPage { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is last page.
        /// </summary>
        /// <value><c>true</c> if this instance is last page; otherwise, <c>false</c>.</value>
        [JsonProperty("is_last_page")]
        public bool IsLastPage {  get; private set; }
    }
}
