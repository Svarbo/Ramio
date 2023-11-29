using Infrastructure;
using Infrastructure.States;
using Transitions;
using Infrastructure.StateMachines;
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

            StateMachine = new StateMachines.StateMachine(scenes);
            StateMachine.Enter(typeof(SdkLoadState));
        }

        public StateMachines.StateMachine StateMachine { get; }
    }
}