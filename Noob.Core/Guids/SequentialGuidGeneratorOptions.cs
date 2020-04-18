// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="SequentialGuidGeneratorOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Guids
{
    /// <summary>
    /// Class SequentialGuidGeneratorOptions.
    /// </summary>
    public class SequentialGuidGeneratorOptions
    {
        /// <summary>
        /// Default value: <see cref="SequentialGuidType.SequentialAtEnd" />.
        /// </summary>
        /// <value>The default type of the sequential unique identifier.</value>
        public SequentialGuidType DefaultSequentialGuidType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialGuidGeneratorOptions"/> class.
        /// </summary>
        public SequentialGuidGeneratorOptions()
        {
            DefaultSequentialGuidType = SequentialGuidType.SequentialAtEnd;
        }
    }
}