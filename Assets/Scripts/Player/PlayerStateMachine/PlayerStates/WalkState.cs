using UnityEngine;

namespace Player
{
    public class WalkState : State
    {
        private int _walkAnimation = Animator.StringToHash("Walk");

        private void OnEnable() =>
            PlayerAnimator.Play(_walkAnimation);

        public override bool IsCompleted()
        {
            return Info.IsSpeedEqualZero
                || Info.IsHit
                || !Info.IsGrounded
                || Info.IsJumpButtonPressed;
        }
    }
}