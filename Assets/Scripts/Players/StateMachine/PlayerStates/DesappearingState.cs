using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    [RequireComponent(typeof(AudioSource))]
    public class DesappearingState : State
    {
        [SerializeField] private AudioClip _disappearingSound;

        private int _desappearingAnimation = Animator.StringToHash("Desappearing");

        private void OnEnable()
        {
            PlayerAnimator.Play(_desappearingAnimation);
            AudioSource.PlayOneShot(_disappearingSound);
        }

        public override bool IsCompleted() =>
            !Info.IsDesappearing;
    }
}