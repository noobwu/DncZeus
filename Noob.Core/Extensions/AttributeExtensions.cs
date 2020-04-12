// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="AttributeExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;

namespace Noob.Extensions
{
    /// <summary>
    /// Class AttributeExtensions.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this Type type)
        {
            var componentDescAttr = type.FirstAttribute<System.ComponentModel.DescriptionAttribute>();
            if (componentDescAttr != null)
                return componentDescAttr.Description;
            return null;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="mi">The mi.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this MemberInfo mi)
        {
            var componentDescAttr = mi.FirstAttribute<System.ComponentModel.DescriptionAttribute>();
            if (componentDescAttr != null)
                return componentDescAttr.Description;
            return null;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this ParameterInfo pi)
        {
            var componentDescAttr = pi.FirstAttribute<System.ComponentModel.DescriptionAttribute>();
            if (componentDescAttr != null)
                return componentDescAttr.Description;
            return null;
        }
    }
}
