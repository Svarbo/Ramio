using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInfo))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public InputServiceView InputServiceView { get; private set; }

    private PlayerInfo _playerInfo;
    private PlayerStats _playerStats;
    private int _currentHealth;
    private int _maxHealth;
    private int _fruitsCount;
    private bool _isDied = false;
    private IDifficult _levelDifficult;
    private string _sceneName;

    public int FruitsCount => _fruitsCount;
    public int CurrentHealth => _currentHealth;

    public int AttemptsCount => _levelDifficult.GetCountTry(_sceneName);

    public PlayerInput PlayerInput { get; private set; }

    public event UnityAction PlayerDesappeared;
    public event UnityAction FruitRaised;

    private void Awake()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        _playerInfo = GetComponent<PlayerInfo>();
        _playerStats = GetComponent<PlayerStats>();
        PlayerInput = GetComponent<PlayerInput>();
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
        _playerInfo.ActivateHit();

        if (_currentHealth <= 0 && _isDied != true)
            Die();
    }

    private void SetHealth()
    {
        _maxHealth = _playerStats.Health;
        _currentHealth = _maxHealth;
    }

    private void Die()
    {
        _isDied = true;
        IncreaseAttemptsCount();
        _playerInfo.SetDesappearing(true);
    }

    private void CompleteDesappearing() =>
        PlayerDesappeared?.Invoke();

    private void IncreaseAttemptsCount() =>
        _levelDifficult.IncreaseCountTry(_sceneName);

    public void SetDifficult(IDifficult levelDifficult) =>
        _levelDifficult = levelDifficult;
}