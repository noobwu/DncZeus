// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IApplicationService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Services
{
    /// <summary>
    /// This interface must be implemented by all application services to register and identify them by convention.
    /// Implements the <see cref="Noob.IRemoteService" />
    /// </summary>
    /// <seealso cref="Noob.IRemoteService" />
    public interface IApplicationService : 
        IRemoteService
    {

    }
}
