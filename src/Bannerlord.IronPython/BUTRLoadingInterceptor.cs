using Bannerlord.BUTR.Shared.Helpers;
using Bannerlord.BUTRLoader;

using HarmonyLib.BUTR.Extensions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bannerlord.IronPython
{
    [BUTRLoaderInterceptor]
    public static class BUTRLoadingInterceptor
    {
        private delegate void OnInitializeSubModulesPrefixDelegate();
        private delegate void OnLoadSubModulesPostfixDelegate();

        private static bool CheckType(Type type) => type.GetCustomAttributes()
            .Any(att => string.Equals(att.GetType().FullName, typeof(BUTRLoaderInterceptorAttribute).FullName, StringComparison.Ordinal));

        private static IEnumerable<Type> GetInterceptorTypes(Assembly assembly)
        {
            IEnumerable<Type> enumerable;
            try
            {
                enumerable = assembly.GetTypes().Where(CheckType).ToArray(); // Force type resolution
            }
            catch (TypeLoadException)
            {
                enumerable = Enumerable.Empty<Type>(); // ignore the incompatibility, not our problem
            }
            catch (ReflectionTypeLoadException)
            {
                enumerable = Enumerable.Empty<Type>(); // ignore the incompatibility, not our problem
            }
            foreach (var type in enumerable)
            {
                yield return type;
            }
        }

        private static IEnumerable<Type> GetInterceptorTypes2()
        {
            var implementationAssemblies = new List<Assembly>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ToList();

            var thisAssembly = typeof(ImplementationLoaderSubModule).Assembly;

            var assemblyFile = new FileInfo(thisAssembly.Location);
            if (!assemblyFile.Exists)
            {
                return Array.Empty<Type>();
            }

            var assemblyDirectory = assemblyFile.Directory;
            if (assemblyDirectory?.Exists != true)
            {
                return Array.Empty<Type>();
            }

            var implementations = assemblyDirectory.GetFiles("Bannerlord.IronPython.Implementation.*.dll");
            if (implementations.Length == 0)
            {
                return Array.Empty<Type>();
            }

            var gameVersion = ApplicationVersionHelper.GameVersion();
            if (gameVersion is null)
            {
                return Array.Empty<Type>();
            }

            var importedImplementationFiles = implementations.Where(x => assemblies.Any(a => Path.GetFileNameWithoutExtension(a.Location) == Path.GetFileNameWithoutExtension(x.Name)));
            var importedImplementationsWithVersions = ImplementationLoaderSubModule.GetImplementations(importedImplementationFiles).ToList();
            if (importedImplementationsWithVersions.Count == 1)
            {
                return implementationAssemblies.SelectMany(GetInterceptorTypes);
            }

            var implementationsFiles = implementations.Where(x => assemblies.All(a => Path.GetFileNameWithoutExtension(a.Location) != Path.GetFileNameWithoutExtension(x.Name)));
            var implementationsWithVersions = ImplementationLoaderSubModule.GetImplementations(implementationsFiles).ToList();
            if (implementationsWithVersions.Count == 0)
            {
                return Array.Empty<Type>();
            }

            var implementationsForGameVersion = ImplementationLoaderSubModule.ImplementationForGameVersion(gameVersion.Value, implementationsWithVersions).ToList();
            switch (implementationsForGameVersion.Count)
            {
                case > 1:
                {
                    var (implementation, _) = ImplementationLoaderSubModule.ImplementationLatest(implementationsForGameVersion);
                    implementationAssemblies.Add(Assembly.LoadFrom(implementation.FullName));
                    break;
                }

                case 1:
                {
                    var (implementation, _) = implementationsForGameVersion[0];
                    implementationAssemblies.Add(Assembly.LoadFrom(implementation.FullName));
                    break;
                }

                case 0:
                {
                    var (implementation, _) = ImplementationLoaderSubModule.ImplementationLatest(implementationsWithVersions);
                    implementationAssemblies.Add(Assembly.LoadFrom(implementation.FullName));
                    break;
                }
            }

            return implementationAssemblies.SelectMany(GetInterceptorTypes);
        }

        public static void OnInitializeSubModulesPrefix()
        {
            foreach (var type in GetInterceptorTypes2())
            {
                if (AccessTools2.GetDelegate<OnInitializeSubModulesPrefixDelegate>(type, "OnInitializeSubModulesPrefix") is { } method)
                {
                    method();
                }
            }
        }

        public static void OnLoadSubModulesPostfix()
        {
            foreach (var type in GetInterceptorTypes2())
            {
                if (AccessTools2.GetDelegate<OnLoadSubModulesPostfixDelegate>(type, "OnLoadSubModulesPostfix") is { } method)
                {
                    method();
                }
            }
        }
    }
}