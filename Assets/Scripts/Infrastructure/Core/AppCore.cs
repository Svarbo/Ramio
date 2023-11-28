using Assets.Scripts.Infrastructure.StateMachines;
using Assets.Scripts.Infrastructure.States.Scenes;
using Infrastructure.States.Scenes;
using System;
using System.Collections.Generic;

namespace Infrastructure.Core
{
    public class AppCore
    {
        public AppCore(ICoroutineRunner coroutineRunner, Fader fader)
        {
            Dictionary<Type, IState> scenes = new Dictionary<Type, IState>()
            {
                [typeof(MainMenuState)] = new MainMenuState(this),
                [typeof(GameLoopState)] = new GameLoopState(),
                [typeof(SdkLoadState)] = new SdkLoadState(this, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(this, coroutineRunner, fader),
            };

            StateMachine = new StateMachine(scenes);
            StateMachine.Enter(typeof(SdkLoadState));
        }

        public StateMachine StateMachine { get; }
    }
}