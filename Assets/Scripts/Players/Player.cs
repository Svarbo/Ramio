using Infrastructure.Payloads;
using UnityEngine;
using UnityEngine.Events;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMover))]
    public class Player : MonoBehaviour, IDamageable, IPayloadForState
    {
        [SerializeField] private int _maxHealth;

        [field: SerializeField] public PlayerMover PlayerMover { get; private set; }

        private Animator _animator;
        private int _currentHealth;
        private int _score;
        private int _isAttackedParameter = Animator.StringToHash("IsAttacked");

        public int Score => _score;
        public int CurrentHealth => _currentHealth;

        public event UnityAction PlayerDied;
        public event UnityAction PlayerAppeared;
        public event UnityAction FruitRaised;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _currentHealth = _maxHealth;

            PlayerAppeared?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            //_playerMover.Stop();
            _currentHealth -= damage;

            _animator.SetTrigger(_isAttackedParameter);
            //  высключить объект
            Die();
        }

        public void IncreaseScore(int reward)
        {
            _score += reward;
            FruitRaised?.Invoke();
        }

        public void Die()
        {
            PlayerDied?.Invoke();
        }
    }
}