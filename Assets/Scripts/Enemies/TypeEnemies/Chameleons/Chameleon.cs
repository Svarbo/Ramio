using System;
using System.Collections.Generic;
using Enemies.StatePayloads;
using Enemies.States;
using Infrastructure.StateMachines;
using Infrastructure.States;
using UnityEngine;

namespace Enemies.TypeEnemies.Chameleons
{
    public class Chameleon : Enemy
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly AnimationController _animationController;
        private StateMachine _stateMachine;
        private float _speed = 3f;
        
        public Chameleon(Rigidbody2D rigidbody2D, AnimationController animationController)
        {
            _rigidbody2D = rigidbody2D;
            _animationController = animationController;
            CreateStateMachine();
            Idle();
        }
        
        public StateMachine StateMachine => _stateMachine;

        public void Attack(IDamageable damageable)
        {
            _stateMachine.Enter<AttackStatePayload>(typeof(AttackState),new AttackStatePayload(damageable, this));
        }

        public void Idle()
        {
            _stateMachine.Enter(typeof(IdleState));
        }

        public void Run(Vector2 target)
        {
            _stateMachine.Enter<RunStatePayload>(typeof(MoveState), new RunStatePayload(_rigidbody2D, target, _speed));
        }

        public void Die()
        {
            _stateMachine.Enter(typeof(DieState));
        }

        protected override void CreateStateMachine()
        {
            Dictionary<Type, IState> states = new Dictionary<Type, IState>()
            {
                [typeof(IdleState)] = new Enemies.States.IdleState(_animationController),
                [typeof(AttackState)] = new AttackState(this, _animationController),
                [typeof(MoveState)] = new MoveState(_animationController),
                [typeof(DieState)] = new DieState(_animationController)
            };

            _stateMachine = new StateMachine(states);
        }
    }
}