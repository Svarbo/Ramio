using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachines
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _currentState;

        public void Update(float deltaTime) =>
            _currentState?.Update(deltaTime);

        public void FixedUpdate(float deltaTime) =>
            _currentState?.FixedUpdate(deltaTime);

        public void LateUpdate(float deltaTime) =>
            _currentState?.LateUpdate(deltaTime);

        public StateMachine(Dictionary<Type, IState> states) =>
            _states = states ?? throw new InvalidOperationException();

        public void Enter(Type state)
        {
            if (_states.ContainsKey(state) == false)
                throw new KeyNotFoundException();

            _currentState?.Exit();
            _currentState = _states[state];
            _currentState?.Enter();
        }

        public void Enter<T>(Type state, T payload)
        {
            if (_states.ContainsKey(state) == false)
                throw new KeyNotFoundException(state.ToString());

            _currentState?.Exit();
            IPayloadState<T> newState = _states[state] as IPayloadState<T>;
            _currentState = newState;
            newState.Enter(payload);
        }

    }
}