using Enemies.StatePayloads;
using Enemies.TypeEnemies.Chameleons;
using Infrastructure.States;
using Interfaces;

namespace Enemies.States
{
    public class AttackState : IPayloadState<AttackStatePayload>
    {
        private readonly IAttack _attacker;
        private readonly AnimationController _animationController;
        private AttackStatePayload _payload;

        public AttackState(IAttack attacker, AnimationController animationController)
        {
            _attacker = attacker;
            _animationController = animationController;
        }

        public void FixedUpdate(float deltaTime)
        {

        }

        public void LateUpdate(float deltaTime)
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void Enter()
        {
        }

        public void Enter(AttackStatePayload direction)
        {
            _payload = direction;
            _animationController.Attack();
            _attacker.Attack(direction.Damageable);
        }

        public void Exit()
        {
        }
    }
}