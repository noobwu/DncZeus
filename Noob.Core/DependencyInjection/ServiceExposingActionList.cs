// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ServiceExposingActionList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ServiceExposingActionList.
    /// Implements the <see cref="System.Collections.Generic.List{System.Action{Noob.DependencyInjection.IOnServiceExposingContext}}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{System.Action{Noob.DependencyInjection.IOnServiceExposingContext}}" />
    public class ServiceExposingActionList : List<Action<IOnServiceExposingContext>>
    {

    }
}