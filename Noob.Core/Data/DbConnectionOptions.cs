// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="DbConnectionOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Data
{
    /// <summary>
    /// Class DbConnectionOptions.
    /// </summary>
    public class DbConnectionOptions
    {
        /// <summary>
        /// Gets or sets the connection strings.
        /// </summary>
        /// <value>The connection strings.</value>
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbConnectionOptions"/> class.
        /// </summary>
        public DbConnectionOptions()
        {
            ConnectionStrings = new ConnectionStrings();
        }
    }
}
