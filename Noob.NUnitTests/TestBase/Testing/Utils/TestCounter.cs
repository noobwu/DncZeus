// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="TestCounter.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Noob.DependencyInjection;

namespace Noob.Testing.Utils
{
    /// <summary>
    /// Class TestCounter.
    /// Implements the <see cref="Noob.Testing.Utils.ITestCounter" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Testing.Utils.ITestCounter" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    public class TestCounter : ITestCounter, ISingletonDependency
    {
        /// <summary>
        /// The values
        /// </summary>
        private readonly Dictionary<string, int> _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCounter"/> class.
        /// </summary>
        public TestCounter()
        {
            _values = new Dictionary<string, int>();
        }

        /// <summary>
        /// Increments the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int Increment(string name)
        {
            return Add(name, 1);
        }

        /// <summary>
        /// Decrements the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int Decrement(string name)
        {
            return Add(name, -1);
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public int Add(string name, int count)
        {
            lock (_values)
            {
                var newValue = _values.GetOrDefault(name) + count;
                _values[name] = newValue;
                return newValue;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int GetValue(string name)
        {
            lock (_values)
            {
                return _values.GetOrDefault(name);
            }
        }
    }
}
