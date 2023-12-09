using Infrastructure.Inputs;
using Players.StateMachine;
using System;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInfo))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public InputServiceView InputServiceView { get; private set; }

        private PlayerInfo _info;
        private PlayerStats _stats;
        private int _currentHealth;
        private int _fruitsCount = 0;
        private bool _isDied = false;
        private string _sceneName;

        public event Action Desappeared;
        
        //TODO не используется
        public event Action FruitRaised;

        public PlayerInput Input { get; private set; }

        public int FruitsCount => _fruitsCount;

        public int AttemptsCount { get; private set; }

        private void Awake()
        {
            _info = GetComponent<PlayerInfo>();
            _stats = GetComponent<PlayerStats>();
            Input = GetComponent<PlayerInput>();

            SetHealth();
        }

        public void SetAttemptsCount(int attemptsCount) =>
            AttemptsCount = attemptsCount;

        public void IncreaseFruitsCount()
        {
            _fruitsCount++;
            FruitRaised?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            _info.ActivateHit();

            if (_currentHealth <= 0 && _isDied != true)
                Die();
        }

        private void SetHealth() =>
            _currentHealth = _stats.Health;

        private void Die()
        {
            _isDied = true;
            _info.SetDesappearing(true);
        }
    }
}