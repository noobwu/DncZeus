using System;
using System.Collections.Generic;
using Noob.Domain.Repositories;
using Noob.Domain.Repositories.EntityFrameworkCore;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    public class EfCoreRepositoryRegistrar : RepositoryRegistrarBase<EfCoreDbContextRegistrationOptions>
    {
        public EfCoreRepositoryRegistrar(EfCoreDbContextRegistrationOptions options)
            : base(options)
        {

        }

        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return DbContextHelper.GetEntityTypes(dbContextType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(EfCoreRepository<,>).MakeGenericType(dbContextType, entityType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
        {
            return typeof(EfCoreRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
        }
    }
}