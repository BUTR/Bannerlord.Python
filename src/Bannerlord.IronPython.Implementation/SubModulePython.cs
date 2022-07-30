using Bannerlord.IronPython.Implementation.Utils;

using IronPython.Hosting;

using Microsoft.Scripting.Hosting;

using System.IO;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.IronPython.Implementation
{
    internal class SubModuleIronPython : MBSubModuleBase
    {
        private readonly ScriptEngine _scriptEngine;
        private readonly ScriptScope _scope;
        private readonly dynamic? _subModule;

        internal SubModuleIronPython(string moduleFolder, string scriptName, string subModuleClassType)
        {
            _scriptEngine = Python.CreateEngine();

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

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnSubModuleLoad", out dynamic closure))
            {
                closure();
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnSubModuleUnloaded", out dynamic closure))
            {
                closure();
            }
        }

        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnApplicationTick", out dynamic closure))
            {
                closure(dt);
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnBeforeInitialModuleScreenSetAsRoot", out dynamic closure))
            {
                closure();
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnGameStart", out dynamic closure))
            {
                closure(game, gameStarterObject);
            }
        }

        public void OnServiceRegistration()
        {
            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnServiceRegistration", out dynamic closure))
            {
                closure();
            }
        }

        public override bool DoLoading(Game game)
        {
            if (!base.DoLoading(game))
                return false;

            if (_scriptEngine.Operations.TryGetMember(_subModule, "DoLoading", out dynamic closure))
            {
                return closure(game) is bool value && value;
            }

            return false;
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnGameLoaded", out dynamic closure))
            {
                closure(game, initializerObject);
            }
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnCampaignStart", out dynamic closure))
            {
                closure(game, starterObject);
            }
        }

        public override void BeginGameStart(Game game)
        {
            base.BeginGameStart(game);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "BeginGameStart", out dynamic closure))
            {
                closure(game);
            }
        }

        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnGameEnd", out dynamic closure))
            {
                closure(game);
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnGameInitializationFinished", out dynamic closure))
            {
                closure(game);
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission)
        {
            base.OnMissionBehaviorInitialize(mission);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnMissionBehaviourInitialize", out dynamic closure))
            {
                closure(mission);
            }
        }

        public override void OnMultiplayerGameStart(Game game, object starterObject)
        {
            base.OnMultiplayerGameStart(game, starterObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnMultiplayerGameStart", out dynamic closure))
            {
                closure(game, starterObject);
            }
        }

        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            base.OnNewGameCreated(game, initializerObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnNewGameCreated", out dynamic closure))
            {
                closure(game, initializerObject);
            }
        }

        public override void OnConfigChanged()
        {
            base.OnConfigChanged();

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnConfigChanged", out dynamic closure))
            {
                closure();
            }
        }

        protected override void InitializeGameStarter(Game game, IGameStarter starterObject)
        {
            base.InitializeGameStarter(game, starterObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "InitializeGameStarter", out dynamic closure))
            {
                closure(game, starterObject);
            }
        }

        public override void OnInitialState()
        {
            base.OnInitialState();

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnInitialState", out dynamic closure))
            {
                closure();
            }
        }

        public override void RegisterSubModuleObjects(bool isSavedCampaign)
        {
            base.RegisterSubModuleObjects(isSavedCampaign);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "RegisterSubModuleObjects", out dynamic closure))
            {
                closure(isSavedCampaign);
            }
        }

        public override void AfterRegisterSubModuleObjects(bool isSavedCampaign)
        {
            base.AfterRegisterSubModuleObjects(isSavedCampaign);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "AfterRegisterSubModuleObjects", out dynamic closure))
            {
                closure(isSavedCampaign);
            }
        }

        public override void OnAfterGameInitializationFinished(Game game, object starterObject)
        {
            base.OnAfterGameInitializationFinished(game, starterObject);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnAfterGameInitializationFinished", out dynamic closure))
            {
                closure(game, starterObject);
            }
        }

        public override void OnBeforeMissionBehaviorInitialize(Mission mission)
        {
            base.OnBeforeMissionBehaviorInitialize(mission);

            if (_scriptEngine.Operations.TryGetMember(_subModule, "OnBeforeMissionBehaviorInitialize", out dynamic closure))
            {
                closure(mission);
            }
        }

#if e180
        protected override void AfterAsyncTickTick(float dt)
        {
            base.AfterAsyncTickTick(dt);
            
            if (_scriptEngine.Operations.TryGetMember(_subModule, "AfterAsyncTickTick", out dynamic closure))
            {
                closure(dt);
            }
        }
#endif
    }
}