using Infrastructure.Inputs;
using Players.StateMachine;
using System;
using UnityEngine;
using Input = Players.StateMachine.Input;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Info))]
    [RequireComponent(typeof(Stats))]
    [RequireComponent(typeof(Input))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public InputServiceView InputServiceView { get; private set; }

        private Info _info;
        private Stats _stats;
        private int _currentHealth;
        private int _fruitsCount = 0;
        private bool _isDied = false;
        private string _sceneName;
        
        public event Action Desappeared;
        public event Action FruitRaised;

        public Input Input { get; private set; }

        public int FruitsCount => _fruitsCount;
        public int AttemptsCount { get;private set; }

        private void Awake()
        {
            _info = GetComponent<Info>();
            _stats = GetComponent<Stats>();
            Input = GetComponent<Input>();

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

        private void CompleteDesappearing() =>
            Desappeared?.Invoke();
    }
}