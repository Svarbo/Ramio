using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    public class DeceleratedIdleState : State
    {
        private int _idleAnimation = Animator.StringToHash("Idle");

        private void OnEnable() =>
            PlayerAnimator.Play(_idleAnimation);

        public override bool IsCompleted()
        {
            return !Info.IsSpeedEqualZero
                || Info.IsHit;
        }
    }
}