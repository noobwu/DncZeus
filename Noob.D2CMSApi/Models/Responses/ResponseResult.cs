// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="ResponseResult.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// Class ResponseResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Responses.ResponseBase{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Noob.D2CMSApi.Models.Responses.ResponseBase{T}" />
    public class ResponseResult<T>:ResponseBase<T> where T:ResultBase
    {
    }
}
