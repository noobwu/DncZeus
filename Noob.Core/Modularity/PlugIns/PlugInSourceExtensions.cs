using System;
using System.Linq;
using JetBrains.Annotations;

namespace Noob.Modularity.PlugIns
{
    public static class PlugInSourceExtensions
    {
        [NotNull]
        public static Type[] GetModulesWithAllDependencies([NotNull] this IPlugInSource plugInSource)
        {
            Check.NotNull(plugInSource, nameof(plugInSource));

            return plugInSource
                .GetModules()
                .SelectMany(ModuleHelper.FindAllModuleTypes)
                .Distinct()
                .ToArray();
        }
    }
}