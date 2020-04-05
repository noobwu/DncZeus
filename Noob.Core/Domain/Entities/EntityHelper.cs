// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 04-05-2020
//
// Last Modified By : Administrator
// Last Modified On : 04-05-2020
// ***********************************************************************
// <copyright file="EntityHelper.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace Noob.Domain.Entities
{
    /// <summary>
    /// Some helper methods for entities.
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// Determines whether the specified type is entity.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is entity; otherwise, <c>false</c>.</returns>
        public static bool IsEntity([NotNull] Type type)
        {
            return typeof(IEntity).IsAssignableFrom(type);
        }

        /// <summary>
        /// Determines whether [is entity with identifier] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is entity with identifier] [the specified type]; otherwise, <c>false</c>.</returns>
        public static bool IsEntityWithId([NotNull] Type type)
        {
            foreach (var interfaceType in type.GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether [has default identifier] [the specified entity].
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [has default identifier] [the specified entity]; otherwise, <c>false</c>.</returns>
        public static bool HasDefaultId<TKey>(IEntity<TKey> entity)
        {
            if (EqualityComparer<TKey>.Default.Equals(entity.Id, default))
            {
                return true;
            }

            //Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if (typeof(TKey) == typeof(int))
            {
                return Convert.ToInt32(entity.Id) <= 0;
            }

            if (typeof(TKey) == typeof(long))
            {
                return Convert.ToInt64(entity.Id) <= 0;
            }

            return false;
        }

        /// <summary>
        /// Tries to find the primary key type of the given entity type.
        /// May return null if given type does not implement <see cref="IEntity{TKey}" />
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <returns>Type.</returns>
        [CanBeNull]
        public static Type FindPrimaryKeyType<TEntity>()
            where TEntity : IEntity
        {
            return FindPrimaryKeyType(typeof(TEntity));
        }

        /// <summary>
        /// Tries to find the primary key type of the given entity type.
        /// May return null if given type does not implement <see cref="IEntity{TKey}" />
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>Type.</returns>
        /// <exception cref="Exception">Given {nameof(entityType)} is not an entity. It should implement {typeof(IEntity).AssemblyQualifiedName}!</exception>
        [CanBeNull]
        public static Type FindPrimaryKeyType([NotNull] Type entityType)
        {
            if (!typeof(IEntity).IsAssignableFrom(entityType))
            {
                throw new Exception($"Given {nameof(entityType)} is not an entity. It should implement {typeof(IEntity).AssemblyQualifiedName}!");
            }

            foreach (var interfaceType in entityType.GetTypeInfo().GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the equality expression for identifier.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId<TEntity, TKey>(TKey id)
            where TEntity : IEntity<TKey>
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");
            var idValue = Convert.ChangeType(id, typeof(TKey));
            Expression<Func<object>> closure = () => idValue;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);
            var lambdaBody = Expression.Equal(leftExpression, rightExpression);
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        /// <summary>
        /// Tries the set identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="idFactory">The identifier factory.</param>
        /// <param name="checkForDisableGuidGenerationAttribute">if set to <c>true</c> [check for disable unique identifier generation attribute].</param>
        public static void TrySetId<TKey>(
            IEntity<TKey> entity,
            Func<TKey> idFactory,
            bool checkForDisableGuidGenerationAttribute = false)
        {
            //TODO: Can be optimized (by caching per entity type)?
            var entityType = entity.GetType();
            var idProperty = entityType.GetProperty(
                nameof(entity.Id)
            );

            if (idProperty == null || idProperty.GetSetMethod(true) == null)
            {
                return;
            }

            if (checkForDisableGuidGenerationAttribute)
            {
                if (idProperty.IsDefined(typeof(DisableIdGenerationAttribute), true))
                {
                    return;
                }
            }

            idProperty.SetValue(entity, idFactory());
        }
    }
}
