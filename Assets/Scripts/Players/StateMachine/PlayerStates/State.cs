using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(PlayerInfo))]
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private bool _isFlippable;
        [SerializeField] private bool _isHorizontalMovable;

        protected AudioSource AudioSource;
        protected Animator PlayerAnimator;
        protected PlayerStats PlayerStats;
        protected PlayerInfo Info;

        public bool IsFlippable => _isFlippable;
        public bool IsMovable => _isHorizontalMovable;

        protected virtual void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerStats = GetComponent<PlayerStats>();
            Info = GetComponent<PlayerInfo>();
        }

        public void Enter() =>
            enabled = true;

        public void Exit() =>
            enabled = false;

        public abstract bool IsCompleted();
    }
}