// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 04-04-2020
//
// Last Modified By : Administrator
// Last Modified On : 04-04-2020
// ***********************************************************************
// <copyright file="AppAuthenticationSettings.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Noob.D2CMSApi.OAuth
{
    /// <summary>
    /// JWT授权的配置项
    /// </summary>
    public class AppAuthenticationSettings
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        /// <value>The application identifier.</value>
        public string AppId { get; set; }
        /// <summary>
        /// 应用密钥(真实项目中可能区分应用,不同的应用对应惟一的密钥)
        /// </summary>
        /// <value>The secret.</value>
        public string Secret { get; set; }
    }
}