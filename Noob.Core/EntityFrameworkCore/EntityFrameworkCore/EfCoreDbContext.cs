// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="EfCoreDbContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Noob.Auditing;
using Noob.Data;
using Noob.DependencyInjection;
using Noob.Domain.Entities;
using Noob.EntityFrameworkCore.Modeling;
using Noob.Guids;
using Noob.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// Implements the <see cref="Noob.EntityFrameworkCore.IEfCoreDbContext" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <seealso cref="Noob.EntityFrameworkCore.IEfCoreDbContext" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class EfCoreDbContext<TDbContext> : DbContext,IEfCoreDbContext,ITransientDependency
          where TDbContext : DbContext
    {
        /// <summary>
        /// Gets a value indicating whether this instance is soft delete filter enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is soft delete filter enabled; otherwise, <c>false</c>.</value>
        protected virtual bool IsSoftDeleteFilterEnabled => DataFilter?.IsEnabled<ISoftDelete>() ?? false;
        /// <summary>
        /// Gets or sets the data filter.
        /// </summary>
        /// <value>The data filter.</value>
        public IDataFilter DataFilter { get; set; }
        /// <summary>
        /// Gets or sets the audit property setter.
        /// </summary>
        /// <value>The audit property setter.</value>
        public IAuditPropertySetter AuditPropertySetter { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier generator.
        /// </summary>
        /// <value>The unique identifier generator.</value>
        public IGuidGenerator GuidGenerator { get; set; }
        /// <summary>
        /// The configuration assemblies
        /// </summary>
        Assembly[] configAssemblies;
        /// <summary>
        /// The configure base properties method information
        /// </summary>
        private static readonly MethodInfo ConfigureBasePropertiesMethodInfo
        = typeof(EfCoreDbContext<TDbContext>)
            .GetMethod(
                nameof(ConfigureBaseProperties),
                BindingFlags.Instance | BindingFlags.NonPublic
            );
        /// <summary>
        /// The configure value generated method information
        /// </summary>
        private static readonly MethodInfo ConfigureValueGeneratedMethodInfo
            = typeof(EfCoreDbContext<TDbContext>)
                .GetMethod(
                    nameof(ConfigureValueGenerated),
                    BindingFlags.Instance | BindingFlags.NonPublic
                );
        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="configAssemblies">The configuration assemblies.</param>
        public EfCoreDbContext(DbContextOptions options, params Assembly[] configAssemblies) : base(options)
        {
            GuidGenerator = SimpleGuidGenerator.Instance;
            this.configAssemblies = configAssemblies;
        }
        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (configAssemblies != null && configAssemblies.Length > 0)
            {
                foreach (var assembly in configAssemblies)
                {
                    modelBuilder.AddEntityConfigurationsFromAssembly(assembly);
                }
                
            }
            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// Checks the and set identifier.
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected virtual void CheckAndSetId(EntityEntry entry)
        {
            if (entry.Entity is IEntity<Guid> entityWithGuidId)
            {
                TrySetGuidId(entry, entityWithGuidId);
            }
        }
        /// <summary>
        /// Tries the set unique identifier identifier.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void TrySetGuidId(EntityEntry entry, IEntity<Guid> entity)
        {
            if (entity.Id != default)
            {
                return;
            }

            var idProperty = entry.Property("Id").Metadata.PropertyInfo;

            //Check for DatabaseGeneratedAttribute
            var dbGeneratedAttr = ReflectionHelper
                .GetSingleAttributeOrDefault<DatabaseGeneratedAttribute>(
                    idProperty
                );

            if (dbGeneratedAttr != null && dbGeneratedAttr.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
            {
                return;
            }

            EntityHelper.TrySetId(
                entity,
                () => GuidGenerator.Create(),
                true
            );
        }
        /// <summary>
        /// Sets the creation audit properties.
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected virtual void SetCreationAuditProperties(EntityEntry entry)
        {
            AuditPropertySetter?.SetCreationProperties(entry.Entity);
        }
        /// <summary>
        /// Sets the modification audit properties.
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected virtual void SetModificationAuditProperties(EntityEntry entry)
        {
            AuditPropertySetter?.SetModificationProperties(entry.Entity);
        }
        /// <summary>
        /// Sets the deletion audit properties.
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected virtual void SetDeletionAuditProperties(EntityEntry entry)
        {
            AuditPropertySetter?.SetDeletionProperties(entry.Entity);
        }
        /// <summary>
        /// Configures the base properties.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="mutableEntityType">Type of the mutable entity.</param>
        protected virtual void ConfigureBaseProperties<TEntity>(ModelBuilder modelBuilder, IMutableEntityType mutableEntityType)
          where TEntity : class
        {
            if (mutableEntityType.IsOwned())
            {
                return;
            }

            modelBuilder.Entity<TEntity>().ConfigureByConvention();

            ConfigureGlobalFilters<TEntity>(modelBuilder, mutableEntityType);
        }

        /// <summary>
        /// Configures the global filters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="mutableEntityType">Type of the mutable entity.</param>
        protected virtual void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType mutableEntityType)
           where TEntity : class
        {
            if (mutableEntityType.BaseType == null && ShouldFilterEntity<TEntity>(mutableEntityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        /// <summary>
        /// Configures the value generated.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="mutableEntityType">Type of the mutable entity.</param>
        protected virtual void ConfigureValueGenerated<TEntity>(ModelBuilder modelBuilder, IMutableEntityType mutableEntityType)
          where TEntity : class
        {
            if (!typeof(IEntity<Guid>).IsAssignableFrom(typeof(TEntity)))
            {
                return;
            }

            var idPropertyBuilder = modelBuilder.Entity<TEntity>().Property(x => ((IEntity<Guid>)x).Id);
            if (idPropertyBuilder.Metadata.PropertyInfo.IsDefined(typeof(DatabaseGeneratedAttribute), true))
            {
                return;
            }

            idPropertyBuilder.ValueGeneratedNever();
        }
        /// <summary>
        /// Shoulds the filter entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
        {

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates the filter expression.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
          where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                expression = e => !IsSoftDeleteFilterEnabled || !EF.Property<bool>(e, "IsDeleted");
            }
            return expression;
        }
        /// <summary>
        /// Combines the expressions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression1">The expression1.</param>
        /// <param name="expression2">The expression2.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        protected virtual Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expression1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expression1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expression2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expression2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }
        /// <summary>
        /// Class ReplaceExpressionVisitor.
        /// Implements the <see cref="System.Linq.Expressions.ExpressionVisitor" />
        /// </summary>
        /// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
        class ReplaceExpressionVisitor : ExpressionVisitor
        {
            /// <summary>
            /// The old value
            /// </summary>
            private readonly Expression _oldValue;
            /// <summary>
            /// The new value
            /// </summary>
            private readonly Expression _newValue;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReplaceExpressionVisitor" /> class.
            /// </summary>
            /// <param name="oldValue">The old value.</param>
            /// <param name="newValue">The new value.</param>
            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            /// <summary>
            /// Dispatches the expression to one of the more specialized visit methods in this class.
            /// </summary>
            /// <param name="node">The expression to visit.</param>
            /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }
    }
}
