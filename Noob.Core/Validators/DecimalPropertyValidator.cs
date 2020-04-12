// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="DecimalPropertyValidator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using FluentValidation.Validators;

namespace Noob.Validators
{
    /// <summary>
    /// Decimal validator
    /// Implements the <see cref="FluentValidation.Validators.PropertyValidator" />
    /// </summary>
    /// <seealso cref="FluentValidation.Validators.PropertyValidator" />
    public class DecimalPropertyValidator : PropertyValidator
    {
        /// <summary>
        /// The maximum value
        /// </summary>
        private readonly decimal _maxValue;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="maxValue">Maximum value</param>
        public DecimalPropertyValidator(decimal maxValue) :
            base("Decimal value is out of range")
        {
            _maxValue = maxValue;
        }

        /// <summary>
        /// Is valid?
        /// </summary>
        /// <param name="context">Validation context</param>
        /// <returns>Result</returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (decimal.TryParse(context.PropertyValue.ToString(), out decimal value))
                return Math.Round(value, 3) < _maxValue;

            return false;
        }
    }
}