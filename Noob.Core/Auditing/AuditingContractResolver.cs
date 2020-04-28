// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditingContractResolver.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingContractResolver.
    /// Implements the <see cref="Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" />
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" />
    public class AuditingContractResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// The ignored types
        /// </summary>
        private readonly List<Type> _ignoredTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingContractResolver"/> class.
        /// </summary>
        /// <param name="ignoredTypes">The ignored types.</param>
        public AuditingContractResolver(List<Type> ignoredTypes)
        {
            _ignoredTypes = ignoredTypes;
        }

        /// <summary>
        /// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
        /// </summary>
        /// <param name="member">The member to create a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for.</param>
        /// <param name="memberSerialization">The member's parent <see cref="T:Newtonsoft.Json.MemberSerialization" />.</param>
        /// <returns>A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member.IsDefined(typeof(DisableAuditingAttribute)) || member.IsDefined(typeof(JsonIgnoreAttribute)))
            {
                property.ShouldSerialize = instance => false;
            }

            foreach (var ignoredType in _ignoredTypes)
            {
                if (ignoredType.GetTypeInfo().IsAssignableFrom(property.PropertyType))
                {
                    property.ShouldSerialize = instance => false;
                    break;
                }
            }

            return property;
        }
    }
}
