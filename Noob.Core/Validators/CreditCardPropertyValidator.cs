// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="CreditCardPropertyValidator.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using FluentValidation.Validators;

namespace Noob.Validators
{
    /// <summary>
    /// Credit card validator
    /// Implements the <see cref="FluentValidation.Validators.PropertyValidator" />
    /// </summary>
    /// <seealso cref="FluentValidation.Validators.PropertyValidator" />
    public class CreditCardPropertyValidator : PropertyValidator
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CreditCardPropertyValidator()
            : base("Credit card number is not valid")
        {

        }

        /// <summary>
        /// Is valid?
        /// </summary>
        /// <param name="context">Validation context</param>
        /// <returns>Result</returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var ccValue = context.PropertyValue as string;
            if (string.IsNullOrWhiteSpace(ccValue))
                return false;

            ccValue = ccValue.Replace(" ", string.Empty);
            ccValue = ccValue.Replace("-", string.Empty);

            var checksum = 0;
            var evenDigit = false;

            //http://www.beachnet.com/~hstiles/cardtype.html
            foreach (var digit in ccValue.Reverse())
            {
                if (!char.IsDigit(digit))
                    return false;

                var digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }
    }
}
