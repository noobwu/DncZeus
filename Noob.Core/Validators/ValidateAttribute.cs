// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="ValidateAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using FluentValidation.AspNetCore;

namespace Noob.Validators
{
    /// <summary>
    /// Represents attribute that used to mark model for the forced validation.
    /// Without this attribute, the model passed in the parameter will not be validated. It's used to prevent auto-validation of child models.
    /// Implements the <see cref="FluentValidation.AspNetCore.CustomizeValidatorAttribute" />
    /// </summary>
    /// <seealso cref="FluentValidation.AspNetCore.CustomizeValidatorAttribute" />
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ValidateAttribute : CustomizeValidatorAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateAttribute"/> class.
        /// </summary>
        public ValidateAttribute()
        {
            //specify rule set
            RuleSet = ValidatorDefaults.ValidationRuleSet;
        }
    }
}