// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="DictTypeModelValidator.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace Noob.D2CMSApi.Models.Validators
{
    /// <summary>
    /// 字典类型表验证
    /// Implements the <see cref="Noob.Validators.BaseValidator{Noob.D2CMSApi.Models.DictTypeModel}" />
    /// </summary>
    /// <seealso cref="Noob.Validators.BaseValidator{Noob.D2CMSApi.Models.DictTypeModel}" />
    public class DictTypeModelValidator : BaseValidator<DictTypeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictTypeModelValidator"/> class.
        /// </summary>
        public DictTypeModelValidator()
        {
            RuleFor(a => a.DictName).NotEmpty().WithMessage("字典名称不能为空");
            RuleFor(a => a.DictName).Length(1, 100).WithMessage("字典名称长度不能大于100");
            RuleFor(a => a.DictType).NotEmpty().WithMessage("字典类型不能为空");
            RuleFor(a => a.DictType).Length(1, 100).WithMessage("字典类型长度不能大于100");

            RuleFor(a => a.CreateBy).Length(0, 64).WithMessage("创建者长度不能大于64");

            RuleFor(a => a.UpdateBy).Length(0, 64).WithMessage("更新者长度不能大于64");

            RuleFor(a => a.Remark).Length(0, 500).WithMessage("备注长度不能大于500");

        }
    }
}
