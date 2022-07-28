using Bannerlord.ButterLib.SubModuleWrappers2;

using TaleWorlds.MountAndBlade;

namespace Bannerlord.IronPython.Utils
{
    internal class EmptySubModule : MBSubModuleBaseWrapper
    {
        private class EmptySubModuleImpl : MBSubModuleBase { }

        public EmptySubModule() : base(new EmptySubModuleImpl()) { }
    }
}