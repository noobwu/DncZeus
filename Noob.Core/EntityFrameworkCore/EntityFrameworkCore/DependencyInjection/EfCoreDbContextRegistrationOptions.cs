using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Noob.DependencyInjection;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.DependencyInjection
{
    public class EfCoreDbContextRegistrationOptions : CommonDbContextRegistrationOptions, IEfCoreDbContextRegistrationOptionsBuilder
    {
        public Dictionary<Type, object> EntityOptions { get; }

        public EfCoreDbContextRegistrationOptions(Type originalDbContextType, IServiceCollection services)
            : base(originalDbContextType, services)
        {
            EntityOptions = new Dictionary<Type, object>();
        }

        public void Entity<TEntity>(Action<EfCoreEntityOptions<TEntity>> optionsAction) where TEntity : IEntity
        {
            Services.Configure<EfCoreEntityOptions>(options =>
            {
                options.Entity(optionsAction);
            });
        }
    }
}