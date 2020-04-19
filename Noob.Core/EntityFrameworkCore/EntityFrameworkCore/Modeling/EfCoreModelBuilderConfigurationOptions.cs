// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreModelBuilderConfigurationOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.EntityFrameworkCore.Modeling
{
    /// <summary>
    /// Class EfCoreModelBuilderConfigurationOptions.
    /// </summary>
    public class EfCoreModelBuilderConfigurationOptions
    {
        /// <summary>
        /// Gets or sets the table prefix.
        /// </summary>
        /// <value>The table prefix.</value>
        [NotNull]
        public string TablePrefix
        {
            get => _tablePrefix;
            set
            {
                Check.NotNull(value, nameof(value), $"{nameof(TablePrefix)} can not be null! Set to empty string if you don't want a table prefix.");
                _tablePrefix = value;
            }
        }
        /// <summary>
        /// The table prefix
        /// </summary>
        private string _tablePrefix;

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>The schema.</value>
        [CanBeNull]
        public string Schema { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreModelBuilderConfigurationOptions"/> class.
        /// </summary>
        /// <param name="tablePrefix">The table prefix.</param>
        /// <param name="schema">The schema.</param>
        public EfCoreModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
        {
            Check.NotNull(tablePrefix, nameof(tablePrefix));

            TablePrefix = tablePrefix;
            Schema = schema;
        }
    }
}
