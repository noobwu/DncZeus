// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="OptionsFactory.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Noob.Options
{
    //TODO: Derive from OptionsFactory when this is released: https://github.com/aspnet/Options/pull/258 (or completely remove this!)
    /// <summary>
    /// Class OptionsFactory.
    /// Implements the <see cref="Microsoft.Extensions.Options.IOptionsFactory{TOptions}" />
    /// </summary>
    /// <typeparam name="TOptions">The type of the t options.</typeparam>
    /// <seealso cref="Microsoft.Extensions.Options.IOptionsFactory{TOptions}" />
    public class OptionsFactory<TOptions> : IOptionsFactory<TOptions> where TOptions : class, new()
    {
        /// <summary>
        /// The setups
        /// </summary>
        private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
        /// <summary>
        /// The post configures
        /// </summary>
        private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsFactory{TOptions}"/> class.
        /// </summary>
        /// <param name="setups">The setups.</param>
        /// <param name="postConfigures">The post configures.</param>
        public OptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
        {
            _setups = setups;
            _postConfigures = postConfigures;
        }

        /// <summary>
        /// Returns a configured <typeparamref name="TOptions" /> instance with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>TOptions.</returns>
        public virtual TOptions Create(string name)
        {
            var options = new TOptions();

            foreach (var setup in _setups)
            {
                if (setup is IConfigureNamedOptions<TOptions> namedSetup)
                {
                    namedSetup.Configure(name, options);
                }
                else if (name == Microsoft.Extensions.Options.Options.DefaultName)
                {
                    setup.Configure(options);
                }
            }

            foreach (var post in _postConfigures)
            {
                post.PostConfigure(name, options);
            }

            return options;
        }
    }
}