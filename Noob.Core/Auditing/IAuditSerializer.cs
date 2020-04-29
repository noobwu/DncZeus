// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="IAuditSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob
{ 
    public interface IAuditSerializer
    {
        string Serialize(object obj);
    }
}