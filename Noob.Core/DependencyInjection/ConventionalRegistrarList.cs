// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ConventionalRegistrarList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Class ConventionalRegistrarList.
    /// Implements the <see cref="System.Collections.Generic.List{Noob.DependencyInjection.IConventionalRegistrar}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{Noob.DependencyInjection.IConventionalRegistrar}" />
    internal class ConventionalRegistrarList : List<IConventionalRegistrar>
    {

    }
}