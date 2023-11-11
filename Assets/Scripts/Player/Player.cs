using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInfo))]
public class Player : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private PlayerStats _playerStats;
    private int _currentHealth;
    private int _maxHealth;
    private int _score;
    
    public int Score => _score;
    public int CurrentHealth => _currentHealth;

    public event UnityAction PlayerDied;
    public event UnityAction FruitRaised;

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _playerStats = GetComponent<PlayerStats>();

        SetHealth();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _playerInfo.ActivateHit();

        if (_currentHealth <= 0)
            Die();
    }

    public void IncreaseScore(int reward)
    {
        _score += reward;
        FruitRaised?.Invoke();
    }

    private void Die()
    {
        _playerInfo.SetDesappearing(true);
        PlayerDied?.Invoke();
    }

    private void SetHealth()
    {
        _maxHealth = _playerStats.Health;
        _currentHealth = _maxHealth;
    }
}