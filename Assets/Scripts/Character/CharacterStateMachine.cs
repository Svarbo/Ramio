using System;
using System.Collections.Generic;
using Infrastructure.Payloads;
using Infrastructure.StateMachines;
using Infrastructure.States;

namespace Character
{
    public class CharacterStateMachine : IStateMachine
    {
        private IState _currentState;
        private Dictionary<Type, IState> _states;

        public CharacterStateMachine(Dictionary<Type, IState> states)
        {
            _states = states;
        }

        public void Enter(Type type)
        {
            if (_states.ContainsKey(type) == false)
                throw new KeyNotFoundException();

            _currentState?.Exit();
            _currentState = _states[type]; 
            _currentState?.Enter();
        }

        public void Enter<T>(T payload) where T : IPayloadForState
        {
            foreach (KeyValuePair<Type, IState> state in _states)
            {
                if (state.Value is IPayloadState<T> newState)
                {
                    _currentState?.Exit();
                    _currentState = newState;
                    newState.Enter(payload);
                    return;
                }
            }
            
            throw new InvalidOperationException("Dictinary value not found " + payload);
        }

        public void Update(float deltaTime)
        {
            _currentState.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _currentState.FixedUpdate(deltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            _currentState.LateUpdate(deltaTime);
        }
    }
}