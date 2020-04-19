// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EventHandlerExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace System
{
    /// <summary>
    /// Extension methods for <see cref="EventHandler" />.
    /// </summary>
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        public static void InvokeSafely(this EventHandler eventHandler, object sender)
        {
            eventHandler.InvokeSafely(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        /// <param name="e">Event argument</param>
        public static void InvokeSafely(this EventHandler eventHandler, object sender, EventArgs e)
        {
            eventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <typeparam name="TEventArgs">Type of the <see cref="EventArgs" /></typeparam>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        /// <param name="e">Event argument</param>
        public static void InvokeSafely<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e)
            where TEventArgs : EventArgs
        {
            eventHandler?.Invoke(sender, e);
        }
    }
}