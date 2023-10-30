using Enemies.TypeEnemies.Chameleons;
using Infrastructure.States;

namespace Enemies.States
{
    public class DieState : IState
    {
        private readonly AnimationController _animationController;

        public DieState(AnimationController animationController)
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
            _animationController.Die();
        }
    }
}