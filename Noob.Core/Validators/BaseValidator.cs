// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="BaseValidator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.Validators
{
    /// <summary>
    /// Class BaseValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{TModel}" />
    /// </summary>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator{TModel}" />
    public abstract class BaseValidator<TModel> : AbstractValidator<TModel> where TModel : class
    {

    }
}
