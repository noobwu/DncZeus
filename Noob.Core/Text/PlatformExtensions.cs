// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="PlatformExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Noob
{
    /// <summary>
    /// Class PlatformExtensions.
    /// </summary>
    public static class PlatformExtensions
    {
        //Should only register Runtime Attributes on StartUp, So using non-ThreadSafe Dictionary is OK
        /// <summary>
        /// The property attributes map
        /// </summary>
        static Dictionary<string, List<Attribute>> propertyAttributesMap
            = new Dictionary<string, List<Attribute>>();
        /// <summary>
        /// The type attributes map
        /// </summary>
        static Dictionary<Type, List<Attribute>> typeAttributesMap
        = new Dictionary<Type, List<Attribute>>();
        /// <summary>
        /// Clears the runtime attributes.
        /// </summary>
        public static void ClearRuntimeAttributes()
        {
            propertyAttributesMap = new Dictionary<string, List<Attribute>>();
            typeAttributesMap = new Dictionary<Type, List<Attribute>>();
        }

        /// <summary>
        /// Uniques the key.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">Property '{0}' has no DeclaringType".Fmt(pi.Name)</exception>
        internal static string UniqueKey(this PropertyInfo pi)
        {
            if (pi.DeclaringType == null)
                throw new ArgumentException("Property '{0}' has no DeclaringType".Fmt(pi.Name));

            return pi.DeclaringType.Namespace + "." + pi.DeclaringType.Name + "." + pi.Name;
        }
        /// <summary>
        /// Adds the attributes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attrs">The attrs.</param>
        /// <returns>Type.</returns>
        public static Type AddAttributes(this Type type, params Attribute[] attrs)
        {
            if (!typeAttributesMap.TryGetValue(type, out var typeAttrs))
                typeAttributesMap[type] = typeAttrs = new List<Attribute>();

            typeAttrs.AddRange(attrs);
            return type;
        }
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>List&lt;TAttr&gt;.</returns>
        public static List<TAttr> GetAttributes<TAttr>(this PropertyInfo propertyInfo)
        {
            return !propertyAttributesMap.TryGetValue(propertyInfo.UniqueKey(), out var propertyAttrs)
                ? new List<TAttr>()
                : propertyAttrs.OfType<TAttr>().ToList();
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>List&lt;Attribute&gt;.</returns>
        public static List<Attribute> GetAttributes(this PropertyInfo propertyInfo)
        {
            return !propertyAttributesMap.TryGetValue(propertyInfo.UniqueKey(), out var propertyAttrs)
                ? new List<Attribute>()
                : propertyAttrs.ToList();
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>List&lt;Attribute&gt;.</returns>
        public static List<Attribute> GetAttributes(this PropertyInfo propertyInfo, Type attrType)
        {
            return !propertyAttributesMap.TryGetValue(propertyInfo.UniqueKey(), out var propertyAttrs)
                ? new List<Attribute>()
                : propertyAttrs.Where(x => attrType.IsInstanceOf(x.GetType())).ToList();
        }
        /// <summary>
        /// Firsts the attribute.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>TAttr.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr FirstAttribute<TAttr>(this Type type) where TAttr : class
        {
            return (TAttr)type.GetCustomAttributes(typeof(TAttr), true)
                       .FirstOrDefault()
                   ?? type.GetRuntimeAttributes<TAttr>().FirstOrDefault();
        }

        /// <summary>
        /// Firsts the attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
        /// <param name="memberInfo">The member information.</param>
        /// <returns>TAttribute.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttribute FirstAttribute<TAttribute>(this MemberInfo memberInfo)
        {
            return memberInfo.AllAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Firsts the attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
        /// <param name="paramInfo">The parameter information.</param>
        /// <returns>TAttribute.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttribute FirstAttribute<TAttribute>(this ParameterInfo paramInfo)
        {
            return paramInfo.AllAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Firsts the attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>TAttribute.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttribute FirstAttribute<TAttribute>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.AllAttributes<TAttribute>().FirstOrDefault();
        }
        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>System.Object[].</returns>
        public static object[] AllAttributes(this PropertyInfo propertyInfo)
        {
            var attrs = propertyInfo.GetCustomAttributes(true);
            var runtimeAttrs = propertyInfo.GetAttributes();
            if (runtimeAttrs.Count == 0)
                return attrs;

            runtimeAttrs.AddRange(attrs.Cast<Attribute>());
            return runtimeAttrs.Cast<object>().ToArray();
        }

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>System.Object[].</returns>
        public static object[] AllAttributes(this PropertyInfo propertyInfo, Type attrType)
        {
            var attrs = propertyInfo.GetCustomAttributes(attrType, true);
            var runtimeAttrs = propertyInfo.GetAttributes(attrType);
            if (runtimeAttrs.Count == 0)
                return attrs;

            runtimeAttrs.AddRange(attrs.Cast<Attribute>());
            return runtimeAttrs.Cast<object>().ToArray();
        }

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="paramInfo">The parameter information.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this ParameterInfo paramInfo) => paramInfo.GetCustomAttributes(true);

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="fieldInfo">The field information.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this FieldInfo fieldInfo) => fieldInfo.GetCustomAttributes(true);

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this MemberInfo memberInfo) => memberInfo.GetCustomAttributes(true);

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="paramInfo">The parameter information.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this ParameterInfo paramInfo, Type attrType) => paramInfo.GetCustomAttributes(attrType, true);

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this MemberInfo memberInfo, Type attrType)
        {
            var prop = memberInfo as PropertyInfo;
            return prop != null
                ? prop.AllAttributes(attrType)
                : memberInfo.GetCustomAttributes(attrType, true);
        }

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="fieldInfo">The field information.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this FieldInfo fieldInfo, Type attrType) => fieldInfo.GetCustomAttributes(attrType, true);

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this Type type) => type.GetCustomAttributes(true).Union(type.GetRuntimeAttributes()).ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this Type type, Type attrType) =>
            type.GetCustomAttributes(attrType, true).Union(type.GetRuntimeAttributes(attrType)).ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>System.Object[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] AllAttributes(this Assembly assembly) => assembly.GetCustomAttributes(true).ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="pi">The pi.</param>
        /// <returns>TAttr[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr[] AllAttributes<TAttr>(this ParameterInfo pi) => pi.AllAttributes(typeof(TAttr)).Cast<TAttr>().ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="mi">The mi.</param>
        /// <returns>TAttr[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr[] AllAttributes<TAttr>(this MemberInfo mi) => mi.AllAttributes(typeof(TAttr)).Cast<TAttr>().ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="fi">The fi.</param>
        /// <returns>TAttr[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr[] AllAttributes<TAttr>(this FieldInfo fi) => fi.AllAttributes(typeof(TAttr)).Cast<TAttr>().ToArray();

        /// <summary>
        /// Alls the attributes.
        /// </summary>
        /// <typeparam name="TAttr">The type of the t attribute.</typeparam>
        /// <param name="pi">The pi.</param>
        /// <returns>TAttr[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr[] AllAttributes<TAttr>(this PropertyInfo pi) => pi.AllAttributes(typeof(TAttr)).Cast<TAttr>().ToArray();
        /// <summary>
        /// Gets the runtime attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IEnumerable<T> GetRuntimeAttributes<T>(this Type type) => typeAttributesMap.TryGetValue(type, out var attrs)
            ? attrs.OfType<T>()
            : new List<T>();

        /// <summary>
        /// Gets the runtime attributes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attrType">Type of the attribute.</param>
        /// <returns>IEnumerable&lt;Attribute&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IEnumerable<Attribute> GetRuntimeAttributes(this Type type, Type attrType = null) => typeAttributesMap.TryGetValue(type, out var attrs)
            ? attrs.Where(x => attrType == null || attrType.IsInstanceOf(x.GetType()))
            : new List<Attribute>();
    }
}
