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
