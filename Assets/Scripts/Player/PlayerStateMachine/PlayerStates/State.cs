using UnityEngine;

namespace Player.PlayerStateMachine.PlayerStates
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Stats))]
    [RequireComponent(typeof(Info))]
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private bool _isFlippable;
        [SerializeField] private bool _isHorizontalMovable;

        protected AudioSource AudioSource;
        protected Animator PlayerAnimator;
        protected Stats PlayerStats;
        protected Info Info;

        public bool IsFlippable => _isFlippable;
        public bool IsMovable => _isHorizontalMovable;

        protected virtual void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerStats = GetComponent<Stats>();
            Info = GetComponent<Info>();
        }

        public void Enter() =>
            enabled = true;

        public void Exit() =>
            enabled = false;

        public abstract bool IsCompleted();
    }
}