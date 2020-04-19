// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="SecondContextTestDataBuilder.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Noob.DependencyInjection;
using Noob.Domain.Repositories;
using Noob.Guids;

namespace Noob.EntityFrameworkCore.TestApp.SecondContext
{
    /// <summary>
    /// Class SecondContextTestDataBuilder.
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class SecondContextTestDataBuilder : ITransientDependency
    {
        /// <summary>
        /// The book repository
        /// </summary>
        private readonly IBasicRepository<BookInSecondDbContext, Guid> _bookRepository;
        /// <summary>
        /// The unique identifier generator
        /// </summary>
        private readonly IGuidGenerator _guidGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondContextTestDataBuilder"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        /// <param name="guidGenerator">The unique identifier generator.</param>
        public SecondContextTestDataBuilder(IBasicRepository<BookInSecondDbContext, Guid> bookRepository, IGuidGenerator guidGenerator)
        {
            _bookRepository = bookRepository;
            _guidGenerator = guidGenerator;
        }

        /// <summary>
        /// build as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task BuildAsync()
        {
            await _bookRepository.InsertAsync(
                new BookInSecondDbContext(
                    _guidGenerator.Create(),
                    "TestBook1"
                )
            );
        }
    }
}