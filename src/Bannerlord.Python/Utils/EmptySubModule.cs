using Bannerlord.ButterLib.SubModuleWrappers;

using TaleWorlds.MountAndBlade;

namespace Bannerlord.Python.Utils
{
    internal class EmptySubModule : MBSubModuleBaseWrapper
    {
        private class EmptySubModuleImpl : MBSubModuleBase { }

        public EmptySubModule() : base(new EmptySubModuleImpl()) { }
    }
}