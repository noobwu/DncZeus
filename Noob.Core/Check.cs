// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="Check.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Noob
{
    /// <summary>
    /// Class Check.
    /// </summary>
    [DebuggerStepThrough]
    public static class Check
    {
        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>(
            T value, 
            [InvokerParameterName] [NotNull] string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>(
            T value, 
            [InvokerParameterName] [NotNull] string parameterName, 
            string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, message);
            }

            return value;
        }

        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        [ContractAnnotation("value:null => halt")]
        public static string NotNull(
            string value,
            [InvokerParameterName] [NotNull] string parameterName,
            int maxLength = int.MaxValue,
            int minLength = 0)
        {
            if (value == null)
            {
                throw new ArgumentException($"{parameterName} can not be null!", parameterName);
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);
            }

            if (minLength > 0 && value.Length < minLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        [ContractAnnotation("value:null => halt")]
        public static string NotNullOrWhiteSpace(
            string value,
            [InvokerParameterName] [NotNull] string parameterName,
            int maxLength = int.MaxValue,
            int minLength = 0)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName);
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);
            }

            if (minLength > 0 && value.Length < minLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        [ContractAnnotation("value:null => halt")]
        public static string NotNullOrEmpty(
            string value,
            [InvokerParameterName] [NotNull] string parameterName,
            int maxLength = int.MaxValue,
            int minLength = 0)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName);
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);
            }

            if (minLength > 0 && value.Length < minLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        /// <exception cref="ArgumentException"></exception>
        [ContractAnnotation("value:null => halt")]
        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException(parameterName + " can not be null or empty!", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Assignables to.
        /// </summary>
        /// <typeparam name="TBaseType">The type of the t base type.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>Type.</returns>
        /// <exception cref="ArgumentException"></exception>
        [ContractAnnotation("type:null => halt")]
        public static Type AssignableTo<TBaseType>(
            Type type,
            [InvokerParameterName] [NotNull] string parameterName)
        {
            NotNull(type, parameterName);

            if (!type.IsAssignableTo<TBaseType>())
            {
                throw new ArgumentException($"{parameterName} (type of {type.AssemblyQualifiedName}) should be assignable to the {typeof(TBaseType).GetFullNameWithAssemblyName()}!");
            }

            return type;
        }

        /// <summary>
        /// Lengthes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static string Length(
            [CanBeNull] string value,
            [InvokerParameterName] [NotNull] string parameterName, 
            int maxLength, 
            int minLength = 0)
        {
            if (minLength > 0)
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(parameterName + " can not be null or empty!", parameterName);
                }

                if (value.Length < minLength)
                {
                    throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);
                }
            }

            if (value != null && value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);
            }

            return value;
        }
    }
}
