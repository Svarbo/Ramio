using System;
using System.Collections.Generic;

public class AppCore
{
    public AppCore(ICoroutineRunner coroutineRunner)
    {
        Dictionary<Type, IState> scenes = new Dictionary<Type, IState>()
        {
            [typeof(MainMenuState)] = new MainMenuState(this, coroutineRunner),
            [typeof(GameLoopState)] = new GameLoopState(),
            [typeof(SdkLoadState)] = new SdkLoadState(this),
            [typeof(LoadLevelState)] = new LoadLevelState(this, coroutineRunner),
        };

        StateMachine = new StateMachine(scenes);
        StateMachine.Enter(typeof(SdkLoadState));
    }

    public StateMachine StateMachine { get; }
}