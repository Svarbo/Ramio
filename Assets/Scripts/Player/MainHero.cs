using Data.Difficults;
using Infrastructure.Inputs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Info))]
    [RequireComponent(typeof(Stats))]
    [RequireComponent(typeof(Input))]
    public class MainHero : MonoBehaviour
    {
        [field: SerializeField] public InputServiceView InputServiceView { get; private set; }

        private Info _info;
        private Stats _stats;
        private int _currentHealth;
        private int _fruitsCount;
        private bool _isDied = false;
        private IDifficult _levelDifficult;
        private string _sceneName;

        public Input Input { get; private set; }

        public event UnityAction PlayerDesappeared;
        public event UnityAction FruitRaised;

        public int FruitsCount => _fruitsCount;
        public int CurrentHealth => _currentHealth;
        public int AttemptsCount => _levelDifficult.GetCountTryBySceneName(_sceneName);

        private void Awake()
        {
            _sceneName = SceneManager.GetActiveScene().name;
            _info = GetComponent<Info>();
            _stats = GetComponent<Stats>();
            Input = GetComponent<Input>();
            SetHealth();
        }

        public void IncreaseScore(int reward)
        {
            _fruitsCount += reward;
            FruitRaised?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            _info.ActivateHit();

            if (_currentHealth <= 0 && _isDied != true)
                Die();
        }

        public void SetDifficult(IDifficult levelDifficult) =>
            _levelDifficult = levelDifficult;

        private void SetHealth() =>
            _currentHealth = _stats.Health;

        private void Die()
        {
            _isDied = true;
            IncreaseAttemptsCount();
            _info.SetDesappearing(true);
        }

        private void CompleteDesappearing() =>
            PlayerDesappeared?.Invoke();

        private void IncreaseAttemptsCount() =>
            _levelDifficult.IncreaseCountTry(_sceneName);
    }
}