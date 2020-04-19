using System;
using JetBrains.Annotations;

namespace Noob.Modularity.PlugIns
{
    public interface IPlugInSource
    {
        [NotNull]
        Type[] GetModules();
    }
}