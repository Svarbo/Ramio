using Enemies.TypeEnemies.Chameleons;
using Infrastructure.States;

namespace Enemies.States
{
    public class IdleState : IState
    {
        private readonly AnimationController _animationController;

        public IdleState(AnimationController animationController)
        {
            _animationController = animationController;
        }

        public void Exit()
        {
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
            _animationController.Idle();
        }
    }
}