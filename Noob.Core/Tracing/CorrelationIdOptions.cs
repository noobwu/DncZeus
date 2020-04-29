// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="CorrelationIdOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Tracing
{
    /// <summary>
    /// Class CorrelationIdOptions.
    /// </summary>
    public class CorrelationIdOptions
    {
        /// <summary>
        /// Gets or sets the name of the HTTP header.
        /// </summary>
        /// <value>The name of the HTTP header.</value>
        public string HttpHeaderName { get; set; } = "X-Correlation-Id";

        /// <summary>
        /// Gets or sets a value indicating whether [set response header].
        /// </summary>
        /// <value><c>true</c> if [set response header]; otherwise, <c>false</c>.</value>
        public bool SetResponseHeader { get; set; } = true;
    }
}
