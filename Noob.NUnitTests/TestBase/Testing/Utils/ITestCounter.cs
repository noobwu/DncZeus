// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="ITestCounter.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Testing.Utils
{
    /// <summary>
    /// Interface ITestCounter
    /// </summary>
    public interface ITestCounter
    {
        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        int Add(string name, int count);

        /// <summary>
        /// Decrements the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        int Decrement(string name);

        /// <summary>
        /// Increments the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        int Increment(string name);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        int GetValue(string name);
    }
}