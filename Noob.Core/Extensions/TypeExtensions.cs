// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="TypeExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using JetBrains.Annotations;
using Noob;

namespace System
{
    /// <summary>
    /// Class TypeExtensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the full name of the name with assembly.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetFullNameWithAssemblyName(this Type type)
        {
            return type.FullName + ", " + type.Assembly.GetName().Name;
        }

        /// <summary>
        /// Determines whether an instance of this type can be assigned to
        /// an instance of the <typeparamref name="TTarget"></typeparamref>.
        /// Internally uses <see cref="Type.IsAssignableFrom" />.
        /// </summary>
        /// <typeparam name="TTarget">Target type</typeparam>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is assignable to] [the specified type]; otherwise, <c>false</c>.</returns>
        /// (as reverse).
        public static bool IsAssignableTo<TTarget>([NotNull] this Type type)
        {
            Check.NotNull(type, nameof(type));

            return type.IsAssignableTo(typeof(TTarget));
        }

        /// <summary>
        /// Determines whether an instance of this type can be assigned to
        /// an instance of the <paramref name="targetType"></paramref>.
        /// Internally uses <see cref="Type.IsAssignableFrom" /> (as reverse).
        /// </summary>
        /// <param name="type">this type</param>
        /// <param name="targetType">Target type</param>
        /// <returns><c>true</c> if [is assignable to] [the specified target type]; otherwise, <c>false</c>.</returns>
        public static bool IsAssignableTo([NotNull] this Type type, [NotNull] Type targetType)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(targetType, nameof(targetType));

            return targetType.IsAssignableFrom(type);
        }

        /// <summary>
        /// Gets all base classes of this type.
        /// </summary>
        /// <param name="type">The type to get its base classes.</param>
        /// <param name="includeObject">True, to include the standard <see cref="object" /> type in the returned array.</param>
        /// <returns>Type[].</returns>
        public static Type[] GetBaseClasses([NotNull] this Type type, bool includeObject = true)
        {
            Check.NotNull(type, nameof(type));

            var types = new List<Type>();
            AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject);
            return types.ToArray();
        }

        /// <summary>
        /// Adds the type and base types recursively.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="type">The type.</param>
        /// <param name="includeObject">if set to <c>true</c> [include object].</param>
        private static void AddTypeAndBaseTypesRecursively(
            [NotNull] List<Type> types,
            [CanBeNull] Type type,
            bool includeObject)
        {
            Check.NotNull(types, nameof(types));

            if (type == null)
            {
                return;
            }

            if (!includeObject && type == typeof(object))
            {
                return;
            }

            AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject);
            types.Add(type);
        }
    }
}
