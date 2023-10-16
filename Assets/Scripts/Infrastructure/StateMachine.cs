using System;
using System.Collections.Generic;
using Infrastructure.States;

namespace Infrastructure
{
    public class StateMachine
    {
        private IExitableState _currentState;
        private readonly Dictionary<Type, IExitableState> _states;

        public StateMachine(ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner),
                [typeof(SceneLoaderState)] = new SceneLoaderState(this, coroutineRunner),
                [typeof(MainMenuState)] = new MainMenuState()
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            IPayloadState<TPayload> payloadState = ChangeState<TState>();
            payloadState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }

}