// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkHelper.
    /// </summary>
    public static class UnitOfWorkHelper
    {
        /// <summary>
        /// Determines whether [is unit of work type] [the specified implementation type].
        /// </summary>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns><c>true</c> if [is unit of work type] [the specified implementation type]; otherwise, <c>false</c>.</returns>
        public static bool IsUnitOfWorkType(TypeInfo implementationType)
        {
            //Explicitly defined UnitOfWorkAttribute
            if (HasUnitOfWorkAttribute(implementationType) || AnyMethodHasUnitOfWorkAttribute(implementationType))
            {
                return true;
            }

            //Conventional classes
            if (typeof(IUnitOfWorkEnabled).GetTypeInfo().IsAssignableFrom(implementationType))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is unit of work method] [the specified method information].
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="unitOfWorkAttribute">The unit of work attribute.</param>
        /// <returns><c>true</c> if [is unit of work method] [the specified method information]; otherwise, <c>false</c>.</returns>
        public static bool IsUnitOfWorkMethod([NotNull] MethodInfo methodInfo, [CanBeNull] out UnitOfWorkAttribute unitOfWorkAttribute)
        {
            Check.NotNull(methodInfo, nameof(methodInfo));

            //Method declaration
            var attrs = methodInfo.GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
            if (attrs.Any())
            {
                unitOfWorkAttribute = attrs.First();
                return !unitOfWorkAttribute.IsDisabled;
            }

            if (methodInfo.DeclaringType != null)
            {
                //Class declaration
                attrs = methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
                if (attrs.Any())
                {
                    unitOfWorkAttribute = attrs.First();
                    return !unitOfWorkAttribute.IsDisabled;
                }

                //Conventional classes
                if (typeof(IUnitOfWorkEnabled).GetTypeInfo().IsAssignableFrom(methodInfo.DeclaringType))
                {
                    unitOfWorkAttribute = null;
                    return true;
                }
            }

            unitOfWorkAttribute = null;
            return false;
        }

        /// <summary>
        /// Gets the unit of work attribute or null.
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <returns>UnitOfWorkAttribute.</returns>
        public static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MethodInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
            if (attrs.Length > 0)
            {
                return attrs[0];
            }

            attrs = methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
            if (attrs.Length > 0)
            {
                return attrs[0];
            }
            
            return null;
        }

        /// <summary>
        /// Anies the method has unit of work attribute.
        /// </summary>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool AnyMethodHasUnitOfWorkAttribute(TypeInfo implementationType)
        {
            return implementationType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Any(HasUnitOfWorkAttribute);
        }

        /// <summary>
        /// Determines whether [has unit of work attribute] [the specified method information].
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <returns><c>true</c> if [has unit of work attribute] [the specified method information]; otherwise, <c>false</c>.</returns>
        private static bool HasUnitOfWorkAttribute(MemberInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }
    }
}
