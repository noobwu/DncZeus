// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ServiceRegistrationActionList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ServiceRegistrationActionList.
    /// Implements the <see cref="System.Collections.Generic.List{System.Action{Noob.DependencyInjection.IOnServiceRegistredContext}}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{System.Action{Noob.DependencyInjection.IOnServiceRegistredContext}}" />
    public class ServiceRegistrationActionList : List<Action<IOnServiceRegistredContext>>
    {
        
    }
}