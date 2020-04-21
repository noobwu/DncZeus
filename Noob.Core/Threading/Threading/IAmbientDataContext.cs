// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="IAmbientDataContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Threading
{
    /// <summary>
    /// Interface IAmbientDataContext
    /// </summary>
    public interface IAmbientDataContext
    {
        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void SetData(string key, object value);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        object GetData(string key);
    }
}