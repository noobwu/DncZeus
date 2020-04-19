// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DisposeAction.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob
{
    /// <summary>
    /// This class can be used to provide an action when
    /// Dipose method is called.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class DisposeAction : IDisposable
    {
        /// <summary>
        /// The action
        /// </summary>
        private readonly Action _action;

        /// <summary>
        /// Creates a new <see cref="DisposeAction" /> object.
        /// </summary>
        /// <param name="action">Action to be executed when this object is disposed.</param>
        public DisposeAction([NotNull] Action action)
        {
            Check.NotNull(action, nameof(action));

            _action = action;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _action();
        }
    }
}
