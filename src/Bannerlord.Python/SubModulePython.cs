using Bannerlord.Python.Utils;

using Microsoft.Scripting.Hosting;

using System.IO;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Python
{
    internal class SubModulePython : MBSubModuleBase
    {
        private readonly ScriptEngine _scriptEngine;
        private readonly ScriptScope _scope;
        private readonly dynamic? _subModule;

        internal SubModulePython(string moduleFolder, string scriptName, string subModuleClassType)
        {
            _scriptEngine = IronPython.Hosting.Python.CreateEngine();

            var subModuleFilePath = Path.Combine(moduleFolder, "Python", scriptName);
            if (File.Exists(subModuleFilePath))
            {
                _scope = _scriptEngine.ExecuteFile(subModuleFilePath);
                var subModuleType = _scope.GetVariable(subModuleClassType);
                _subModule = _scriptEngine.Operations.CreateInstance(subModuleType, new EmptySubModule());
            }
            else
            {
                _scope = _scriptEngine.CreateScope();
                _subModule = null;
            }
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            if (_subModule?.OnSubModuleLoad is { } closure)
            {
                closure();
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

            if (_subModule?.OnSubModuleUnloaded is { } closure)
            {
                closure();
            }
        }

        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);

            if (_subModule?.OnApplicationTick is { } closure)
            {
                closure(dt);
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (_subModule?.OnBeforeInitialModuleScreenSetAsRoot is { } closure)
            {
                closure();
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (_subModule?.OnGameStart is { } closure)
            {
                closure(game, gameStarterObject);
            }
        }

        public void OnServiceRegistration()
        {
            if (_subModule?.OnServiceRegistration is { } closure)
            {
                closure();
            }
        }

        public override bool DoLoading(Game game)
        {
            if (!base.DoLoading(game))
                return false;

            if (_subModule?.DoLoading is { } closure && closure(game) is bool value)
            {
                return value;
            }

            return false;
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);

            if (_subModule?.OnGameLoaded is { } closure)
            {
                closure(game, initializerObject);
            }
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);

            if (_subModule?.OnCampaignStart is { } closure)
            {
                closure(game, starterObject);
            }
        }

        public override void BeginGameStart(Game game)
        {
            base.BeginGameStart(game);

            if (_subModule?.BeginGameStart is { } closure)
            {
                closure(game);
            }
        }

        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);

            if (_subModule?.OnGameEnd is { } closure)
            {
                closure(game);
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (_subModule?.OnGameInitializationFinished is { } closure)
            {
                closure(game);
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);

            if (_subModule?.OnMissionBehaviourInitialize is { } closure)
            {
                closure(mission);
            }
        }

        public override void OnMultiplayerGameStart(Game game, object starterObject)
        {
            base.OnMultiplayerGameStart(game, starterObject);

            if (_subModule?.OnMultiplayerGameStart is { } closure)
            {
                closure(game, starterObject);
            }
        }

        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            base.OnNewGameCreated(game, initializerObject);

            if (_subModule?.OnNewGameCreated is { } closure)
            {
                closure(game, initializerObject);
            }
        }

        public override void OnConfigChanged()
        {
            base.OnConfigChanged();

            if (_subModule?.OnConfigChanged is { } closure)
            {
                closure();
            }
        }
    }
}