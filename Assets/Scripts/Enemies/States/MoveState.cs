using Enemies.StatePayloads;
using Enemies.TypeEnemies.Chameleons;
using Infrastructure.States;
using UnityEngine;
using static UnityEngine.Vector2;

namespace Enemies.States
{
    public class MoveState : IPayloadState<RunStatePayload>
    {
        private readonly AnimationController _animator;
        private RunStatePayload _payload;
        private int _direction;

        public MoveState(AnimationController animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
        }

        public void Enter(RunStatePayload payload)
        {
            _payload = payload;
            _animator.Run();
        }

        private void Move()
        {
            if (_payload.TargetDirection.x < _payload.Rigidbody2D.gameObject.transform.position.x)
                _payload.Rigidbody2D.velocity = Vector2.left * (Time.deltaTime * _payload.Speed);
            else if (_payload.TargetDirection.x > _payload.Rigidbody2D.gameObject.transform.position.x)
                _payload.Rigidbody2D.velocity = Vector2.right * (Time.deltaTime * _payload.Speed);
            else
                _payload.Rigidbody2D.velocity = Vector2.zero;
        }

        public void Exit()
        {
            _payload.Rigidbody2D.velocity = Vector2.zero;
        }

        public void FixedUpdate(float deltaTime)
        {
        }

        public void LateUpdate(float deltaTime)
        {
        }

        public void Update(float deltaTime)
        {
            Move();
        }
    }
}