using UnityEngine;

namespace Enemies
{
    public class UnitAnimation
    {
        private readonly Animator _animator;

        public UnitAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAnimationByBool(int hashTransition, bool parameter)
        {
            _animator.SetBool(hashTransition, parameter);
        }
        
        public void PlayAnimationByTrigger(int hashTransition)
        {
            _animator.SetTrigger(hashTransition);
        }

        public void PlayAnimationByState(int hashState)
        {
            _animator.Play(hashState);
        }
    }
}