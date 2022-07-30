using Bannerlord.BUTR.Shared.Helpers;
using Bannerlord.BUTRLoader;
using Bannerlord.IronPython.Implementation.Utils;

using HarmonyLib;
using HarmonyLib.BUTR.Extensions;

using System;
using System.Collections.Generic;
using System.Xml;

using TaleWorlds.Engine;

using Module = TaleWorlds.MountAndBlade.Module;

namespace Bannerlord.IronPython.Implementation
{
    [BUTRLoaderInterceptor]
    public static class BUTRLoadingInterceptor
    {
        private static readonly AccessTools.FieldRef<Module, Dictionary<string, Type>>? LoadedSubModuleTypes =
            AccessTools2.FieldRefAccess<Module, Dictionary<string, Type>>("_loadedSubmoduleTypes");

        public static void OnInitializeSubModulesPrefix()
        {
            var loadedSubModuleTypes = LoadedSubModuleTypes?.Invoke(Module.CurrentModule);

            var baseFolder = Utilities.GetBasePath();

            foreach (var moduleInfo in ModuleInfoHelper.GetLoadedModules())
            {
                var moduleFolder = System.IO.Path.Combine(baseFolder, "Modules", moduleInfo.Id);
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(System.IO.Path.Combine(moduleFolder, "SubModule.xml"));

                var moduleNode = xmlDocument.SelectSingleNode("Module");

                var subModules = moduleNode?.SelectSingleNode("SubModules");
                var subModuleList = subModules?.SelectNodes("SubModulePython");
                for (var i = 0; i < subModuleList?.Count; i++)
                {
                    var subModuleNode = subModuleList[i];
                    var name = subModuleNode?.SelectSingleNode("Name")?.Attributes["value"]?.InnerText ?? string.Empty;
                    var scriptName = subModuleNode?.SelectSingleNode("ScriptName")?.Attributes["value"]?.InnerText ?? string.Empty;
                    var subModuleClassType = subModuleNode?.SelectSingleNode("SubModuleClassType")?.Attributes["value"]?.InnerText ?? string.Empty;
                    loadedSubModuleTypes?.Add(name, new WrappedSubModulePythonType(moduleFolder, scriptName, subModuleClassType));
                }
            }
        }
    }
}