// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="CrudAppService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Threading.Tasks;
using Noob.Application.Dtos;
using Noob.Auditing;
using Noob.Domain.Entities;
using Noob.Domain.Repositories;

namespace Noob.Application.Services
{
    /// <summary>
    /// Class CrudAppService.
    /// Implements the <see cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    public abstract class CrudAppService<TEntity, TEntityDto, TKey>
        : CrudAppService<TEntity, TEntityDto, TKey, PagedAndSortedResultRequestDto>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudAppService{TEntity, TEntityDto, TKey}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected CrudAppService(IRepository<TEntity, TKey> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class CrudAppService.
    /// Implements the <see cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <seealso cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    public abstract class CrudAppService<TEntity, TEntityDto, TKey, TGetListInput>
        : CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudAppService{TEntity, TEntityDto, TKey, TGetListInput}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected CrudAppService(IRepository<TEntity, TKey> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class CrudAppService.
    /// Implements the <see cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <seealso cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    public abstract class CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput>
        : CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected CrudAppService(IRepository<TEntity, TKey> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class CrudAppService.
    /// Implements the <see cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.CrudAppService{TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    public abstract class CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        : CrudAppService<TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected CrudAppService(IRepository<TEntity, TKey> repository)
            : base(repository)
        {

        }

        /// <summary>
        /// Maps to get list output dto.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntityDto.</returns>
        protected override TEntityDto MapToGetListOutputDto(TEntity entity)
        {
            return MapToGetOutputDto(entity);
        }
    }

    /// <summary>
    /// Class CrudAppService.
    /// Implements the <see cref="AbstractKeyCrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// Implements the <see cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TGetOutputDto">The type of the t get output dto.</typeparam>
    /// <typeparam name="TGetListOutputDto">The type of the t get list output dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// <seealso cref="AbstractKeyCrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    public abstract class CrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        : AbstractKeyCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TGetOutputDto : IEntityDto<TKey>
        where TGetListOutputDto : IEntityDto<TKey>
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>The repository.</value>
        protected new IRepository<TEntity, TKey> Repository { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected CrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// delete by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        protected override async Task DeleteByIdAsync(TKey id)
        {
            await Repository.DeleteAsync(id);
        }

        /// <summary>
        /// get entity by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
        {
            return await Repository.GetAsync(id);
        }

        /// <summary>
        /// Maps to entity.
        /// </summary>
        /// <param name="updateInput">The update input.</param>
        /// <param name="entity">The entity.</param>
        protected override void MapToEntity(TUpdateInput updateInput, TEntity entity)
        {
            if (updateInput is IEntityDto<TKey> entityDto)
            {
                entityDto.Id = entity.Id;
            }

            base.MapToEntity(updateInput, entity);
        }

        /// <summary>
        /// Applies the default sorting.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
        {
            if (typeof(TEntity).IsAssignableTo<ICreationAuditedObject>())
            {
                return query.OrderByDescending(e => ((ICreationAuditedObject)e).CreationTime);
            }
            else
            {
                return query.OrderByDescending(e => e.Id);
            }
        }
    }
}
