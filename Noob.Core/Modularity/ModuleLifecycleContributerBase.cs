﻿namespace Noob.Modularity
{
    public abstract class ModuleLifecycleContributorBase : IModuleLifecycleContributor
    {
        public virtual void Initialize(ApplicationInitializationContext context, IModule module)
        {
        }

        public virtual void Shutdown(ApplicationShutdownContext context, IModule module)
        {
        }
    }
}