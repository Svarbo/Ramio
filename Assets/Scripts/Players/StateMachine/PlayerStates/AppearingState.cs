using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    public class AppearingState : State
    {
        private int _appearingAnimation = Animator.StringToHash("Appearing");

        public override bool IsCompleted() =>
            Info.IsAppearingAnimationFinished;

        private void OnEnable() =>
            PlayerAnimator.Play(_appearingAnimation);
    }
}