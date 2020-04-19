// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 04-05-2020
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="ModelBuilderExtenions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class ModelBuilderExtenions.
    /// </summary>
    public static class ModelBuilderExtenions
    {

        /// <summary>
        /// Gets the mapping types.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="mappingInterface">The mapping interface.</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly.GetTypes().Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }

        /// <summary>
        /// Adds the entity configurations from assembly.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="assembly">The assembly.</param>
        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            // Types that do entity mapping
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityTypeConfiguration<>));

            // Get the generic Entity method of the ModelBuilder type
            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                        x.IsGenericMethod &&
                        x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                // Get the type of entity to be mapped
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();

                // Get the method builder.Entity<TEntity>
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);

                // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);

                // Create the mapping type and do the mapping
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
            }
        }
    }
}
