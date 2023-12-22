using Players.StateMachine.Checkers;
using UnityEngine;

namespace Buffs
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    public class JumpBoost : MonoBehaviour
    {
        [SerializeField] private float _reloadingTime;

        private Animator _animator;
        private AudioSource _audioSource;
        private int _collectedAnimation = Animator.StringToHash("Collected");
        private int _idleAnimation = Animator.StringToHash("Idle");
        private float _currentReloadingTime = 0;
        private bool _isCollected = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update() =>
            TryReload();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isCollected == false)
            {
                if (collision.TryGetComponent(out ExtraJumpChecker extraJumpChecker))
                {
                    extraJumpChecker.AddExtraJump();

                    _animator.Play(_collectedAnimation);
                    _audioSource.Play();
                }
            }
        }

        private void TryReload()
        {
            if (_isCollected == true)
            {
                _currentReloadingTime += Time.deltaTime;

                if (_currentReloadingTime >= _reloadingTime)
                {
                    _isCollected = false;
                    _currentReloadingTime = 0;

                    _animator.Play(_idleAnimation);
                }
            }
        }
    }
}