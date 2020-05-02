// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="ICrudAppService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Noob.Application.Dtos;

namespace Noob.Application.Services
{
    /// <summary>
    /// Interface ICrudAppService
    /// Implements the <see cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    /// </summary>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, Noob.Application.Dtos.PagedAndSortedResultRequestDto}" />
    public interface ICrudAppService<TEntityDto, in TKey>
        : ICrudAppService<TEntityDto, TKey, PagedAndSortedResultRequestDto>
    {

    }

    /// <summary>
    /// Interface ICrudAppService
    /// Implements the <see cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    /// </summary>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <seealso cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto}" />
    public interface ICrudAppService<TEntityDto, in TKey, in TGetListInput>
        : ICrudAppService<TEntityDto, TKey, TGetListInput, TEntityDto, TEntityDto>
    {

    }

    /// <summary>
    /// Interface ICrudAppService
    /// Implements the <see cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    /// </summary>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <seealso cref="Noob.Application.Services.ICrudAppService{TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput}" />
    public interface ICrudAppService<TEntityDto, in TKey, in TGetListInput, in TCreateInput>
        : ICrudAppService<TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput>
    {

    }

    /// <summary>
    /// Interface ICrudAppService
    /// Implements the <see cref="Noob.Application.Services.ICrudAppService{TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    /// </summary>
    /// <typeparam name="TEntityDto">The type of the t entity dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.ICrudAppService{TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput}" />
    public interface ICrudAppService<TEntityDto, in TKey, in TGetListInput, in TCreateInput, in TUpdateInput>
        : ICrudAppService<TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
    {

    }

    /// <summary>
    /// Interface ICrudAppService
    /// Implements the <see cref="Noob.Application.Services.IApplicationService" />
    /// </summary>
    /// <typeparam name="TGetOutputDto">The type of the t get output dto.</typeparam>
    /// <typeparam name="TGetListOutputDto">The type of the t get list output dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TGetListInput">The type of the t get list input.</typeparam>
    /// <typeparam name="TCreateInput">The type of the t create input.</typeparam>
    /// <typeparam name="TUpdateInput">The type of the t update input.</typeparam>
    /// <seealso cref="Noob.Application.Services.IApplicationService" />
    public interface ICrudAppService<TGetOutputDto, TGetListOutputDto, in TKey, in TGetListInput, in TCreateInput, in TUpdateInput>
        : IApplicationService
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        Task<TGetOutputDto> GetAsync(TKey id);

        /// <summary>
        /// Gets the list asynchronous.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;PagedResultDto&lt;TGetListOutputDto&gt;&gt;.</returns>
        Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        Task<TGetOutputDto> CreateAsync(TCreateInput input);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;TGetOutputDto&gt;.</returns>
        Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(TKey id);
    }
}
