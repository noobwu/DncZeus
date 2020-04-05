// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 04-04-2020
//
// Last Modified By : Administrator
// Last Modified On : 04-04-2020
// ***********************************************************************
// <copyright file="WeatherForecast.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.D2CMSApi
{
    /// <summary>
    /// Class WeatherForecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature c.
        /// </summary>
        /// <value>The temperature c.</value>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature f.
        /// </summary>
        /// <value>The temperature f.</value>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Summary { get; set; }
    }
}
