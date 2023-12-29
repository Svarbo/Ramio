using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    public class FallState : State
    {
        private int _fallAnimation = Animator.StringToHash("Fall");

        private void OnEnable() =>
            PlayerAnimator.Play(_fallAnimation);

        public override bool IsCompleted()
        {
            return Info.IsGrounded
                || Info.IsHit
                || Info.IsWallHooked
                || (Info.IsJumpButtonPressed && Info.IsExtraJumpReady)
                || !Info.IsFalling
                || Info.IsDecelerated
                || Info.IsFinished;
        }
    }
}