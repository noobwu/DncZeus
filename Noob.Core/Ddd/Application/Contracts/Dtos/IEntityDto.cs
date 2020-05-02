// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-14
// ***********************************************************************
// <copyright file="IEntityDto.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// Interface IEntityDto
    /// </summary>
    public interface IEntityDto
    {

    }

    /// <summary>
    /// Interface IEntityDto
    /// Implements the <see cref="Noob.Application.Dtos.IEntityDto" />
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <seealso cref="Noob.Application.Dtos.IEntityDto" />
    public interface IEntityDto<TKey> : IEntityDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        TKey Id { get; set; }
    }
}