using Players;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(PlayerMover))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;

    private PlayerMover _playerMover;
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
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;

        PlayerAppeared?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        //_playerMover.Stop();
        _currentHealth -= damage;
        
        _animator.SetTrigger(_isAttackedParameter);
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