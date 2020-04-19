// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DbContextHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Noob.Domain.Entities;
using Noob.Reflection;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class DbContextHelper.
    /// </summary>
    internal static class DbContextHelper
    {
        /// <summary>
        /// Gets the entity types.
        /// </summary>
        /// <param name="dbContextType">Type of the database context.</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public static IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return
                from property in dbContextType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where
                    ReflectionHelper.IsAssignableToGenericType(property.PropertyType, typeof(DbSet<>)) &&
                    typeof(IEntity).IsAssignableFrom(property.PropertyType.GenericTypeArguments[0])
                select property.PropertyType.GenericTypeArguments[0];
        }
    }
}