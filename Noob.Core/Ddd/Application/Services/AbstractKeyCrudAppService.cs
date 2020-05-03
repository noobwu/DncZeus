// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="AbstractKeyCrudAppService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Noob.Application.Dtos;
using Noob.Auditing;
using Noob.Domain.Entities;
using Noob.Domain.Repositories;
using Noob.Linq;
using Noob.ObjectMapping;

namespace Noob.Application.Services
{
    /// <summary>
    /// Class AbstractKeyCrudAppService.
    /// Implements the <see cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    public abstract class AbstractKeyCrudAppService<TEntity, TEntityDto, TKey>
        : AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, PagedAndSortedResultRequestDto>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeyCrudAppService{TEntity, TEntityDto, TKey}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected AbstractKeyCrudAppService(IRepository<TEntity> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class AbstractKeyCrudAppService.
    /// Implements the <see cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <seealso cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    public abstract class AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, TGetListInput>
        : AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected AbstractKeyCrudAppService(IRepository<TEntity> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class AbstractKeyCrudAppService.
    /// Implements the <see cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <seealso cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    public abstract class AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput>
        : AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected AbstractKeyCrudAppService(IRepository<TEntity> repository)
            : base(repository)
        {

        }
    }

    /// <summary>
    /// Class AbstractKeyCrudAppService.
    /// Implements the <see cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.AbstractKeyCrudAppService{TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    public abstract class AbstractKeyCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        : AbstractKeyCrudAppService<TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeyCrudAppService{TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected AbstractKeyCrudAppService(IRepository<TEntity> repository)
            : base(repository)
        {

        }

        /// <summary>
        /// Maps <see cref="!:TEntity" /> to <see cref="!:TGetListOutputDto" />.
        /// It uses <see cref="T:Noob.ObjectMapping.IObjectMapper" /> by default.
        /// It can be overriden for custom mapping.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TGetListOutputDto.</returns>
        protected override TEntityDto MapToGetListOutputDto(TEntity entity)
        {
            return MapToGetOutputDto(entity);
        }
    }

    /// <summary>
    /// Class AbstractKeyCrudAppService.
    /// Implements the <see cref="Noob.Application.Services.ApplicationService" />
    /// Implements the <see cref="Noob.Application.Services.ICrudAppService{TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TGetOutputDto">The type of the t get output dto.</typeparam>
    /// <typeparam name="TGetListOutputDto">The type of the t get list output dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.ApplicationService" />
    /// <seealso cref="Noob.Application.Services.ICrudAppService{TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    public abstract class AbstractKeyCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        : ApplicationService,
            ICrudAppService<TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets or sets the asynchronous queryable executer.
        /// </summary>
        /// <value>The asynchronous queryable executer.</value>
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>The repository.</value>
        protected IRepository<TEntity> Repository { get; }

        /// <summary>
        /// Gets or sets the name of the get policy.
        /// </summary>
        /// <value>The name of the get policy.</value>
        protected virtual string GetPolicyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the get list policy.
        /// </summary>
        /// <value>The name of the get list policy.</value>
        protected virtual string GetListPolicyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the create policy.
        /// </summary>
        /// <value>The name of the create policy.</value>
        protected virtual string CreatePolicyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the update policy.
        /// </summary>
        /// <value>The name of the update policy.</value>
        protected virtual string UpdatePolicyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the delete policy.
        /// </summary>
        /// <value>The name of the delete policy.</value>
        protected virtual string DeletePolicyName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeyCrudAppService{TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected AbstractKeyCrudAppService(IRepository<TEntity> repository)
        {
            Repository = repository;
            AsyncQueryableExecuter = DefaultAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        public virtual async Task<TGetOutputDto> GetAsync(TKey id)
        {
            await CheckGetPolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            return MapToGetOutputDto(entity);
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;PagedResultDto&lt;TGetListOutputDto&gt;&gt;.</returns>
        public virtual async Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input)
        {
            await CheckGetListPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TGetListOutputDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }

        /// <summary>
        /// create as an asynchronous operation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        public virtual async Task<TGetOutputDto> CreateAsync(TCreateInput input)
        {
            await CheckCreatePolicyAsync();

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        public virtual async Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            MapToEntity(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        public virtual async Task DeleteAsync(TKey id)
        {
            await CheckDeletePolicyAsync();

            await DeleteByIdAsync(id);
        }

        /// <summary>
        /// Deletes the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        protected abstract Task DeleteByIdAsync(TKey id);

        /// <summary>
        /// Gets the entity by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        protected abstract Task<TEntity> GetEntityByIdAsync(TKey id);

        /// <summary>
        /// check get policy as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CheckGetPolicyAsync()
        {
            await CheckPolicyAsync(GetPolicyName);
        }

        /// <summary>
        /// check get list policy as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CheckGetListPolicyAsync()
        {
            await CheckPolicyAsync(GetListPolicyName);
        }

        /// <summary>
        /// check create policy as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CheckCreatePolicyAsync()
        {
            await CheckPolicyAsync(CreatePolicyName);
        }

        /// <summary>
        /// check update policy as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CheckUpdatePolicyAsync()
        {
            await CheckPolicyAsync(UpdatePolicyName);
        }

        /// <summary>
        /// check delete policy as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CheckDeletePolicyAsync()
        {
            await CheckPolicyAsync(DeletePolicyName);
        }

        /// <summary>
        /// Should apply sorting if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TGetListInput input)
        {
            //Try to sort query if available
            if (input is ISortedResultRequest sortInput)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
            }

            //IQueryable.Task requires sorting, so we should sort if Take will be used.
            if (input is ILimitedResultRequest)
            {
                return ApplyDefaultSorting(query);
            }

            //No sorting
            return query;
        }

        /// <summary>
        /// Applies sorting if no sorting specified but a limited result requested.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        /// <exception cref="Exception">No sorting specified but this query requires sorting. Override the ApplyDefaultSorting method for your application service derived from AbstractKeyCrudAppService!</exception>
        protected virtual IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
        {
            if (typeof(TEntity).IsAssignableTo<ICreationAuditedObject>())
            {
                return query.OrderByDescending(e => ((ICreationAuditedObject)e).CreationTime);
            }

            throw new Exception("No sorting specified but this query requires sorting. Override the ApplyDefaultSorting method for your application service derived from AbstractKeyCrudAppService!");
        }

        /// <summary>
        /// Should apply paging if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TGetListInput input)
        {
            //Try to use paging if available
            if (input is IPagedResultRequest pagedInput)
            {
                return query.PageBy(pagedInput);
            }

            //Try to limit query result if available
            if (input is ILimitedResultRequest limitedInput)
            {
                return query.Take(limitedInput.MaxResultCount);
            }

            //No paging
            return query;
        }

        /// <summary>
        /// This method should create <see cref="IQueryable{TEntity}" /> based on given input.
        /// It should filter query if needed, but should not do sorting or paging.
        /// Sorting should be done in <see cref="ApplySorting" /> and paging should be done in <see cref="ApplyPaging" />
        /// methods.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        protected virtual IQueryable<TEntity> CreateFilteredQuery(TGetListInput input)
        {
            return Repository;
        }

        /// <summary>
        /// Maps <see cref="TEntity" /> to <see cref="TGetOutputDto" />.
        /// It uses <see cref="IObjectMapper" /> by default.
        /// It can be overriden for custom mapping.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TGetOutputDto.</returns>
        protected virtual TGetOutputDto MapToGetOutputDto(TEntity entity)
        {
            return ObjectMapper.Map<TEntity, TGetOutputDto>(entity);
        }

        /// <summary>
        /// Maps <see cref="TEntity" /> to <see cref="TGetListOutputDto" />.
        /// It uses <see cref="IObjectMapper" /> by default.
        /// It can be overriden for custom mapping.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TGetListOutputDto.</returns>
        protected virtual TGetListOutputDto MapToGetListOutputDto(TEntity entity)
        {
            return ObjectMapper.Map<TEntity, TGetListOutputDto>(entity);
        }

        /// <summary>
        /// Maps <see cref="TCreateInput" /> to <see cref="TEntity" /> to create a new entity.
        /// It uses <see cref="IObjectMapper" /> by default.
        /// It can be overriden for custom mapping.
        /// </summary>
        /// <param name="createInput">The create input.</param>
        /// <returns>TEntity.</returns>
        protected virtual TEntity MapToEntity(TCreateInput createInput)
        {
            var entity = ObjectMapper.Map<TCreateInput, TEntity>(createInput);
            SetIdForGuids(entity);
            return entity;
        }

        /// <summary>
        /// Sets Id value for the entity if <see cref="TKey" /> is <see cref="Guid" />.
        /// It's used while creating a new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void SetIdForGuids(TEntity entity)
        {
            var entityWithGuidId = entity as IEntity<Guid>;

            if (entityWithGuidId == null || entityWithGuidId.Id != Guid.Empty)
            {
                return;
            }

            EntityHelper.TrySetId(
                entityWithGuidId,
                () => GuidGenerator.Create(),
                true
            );
        }

        /// <summary>
        /// Maps <see cref="TUpdateInput" /> to <see cref="TEntity" /> to update the entity.
        /// It uses <see cref="IObjectMapper" /> by default.
        /// It can be overriden for custom mapping.
        /// </summary>
        /// <param name="updateInput">The update input.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void MapToEntity(TUpdateInput updateInput, TEntity entity)
        {
            ObjectMapper.Map(updateInput, entity);
        }
    }
}