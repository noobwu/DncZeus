﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    public class ResponseResult<T>:ResponseBase<T> where T:ResultBase
    {
    }
}