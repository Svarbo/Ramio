using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerInfo))]
public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] private bool _isFlippable;
    [SerializeField] private bool _isHorizontalMovable;

    protected Animator PlayerAnimator;
    protected PlayerStats PlayerStats;
    protected PlayerInfo PlayerInfo;

    public bool IsFlippable => _isFlippable;
    public bool IsMovable => _isHorizontalMovable;

    protected virtual void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerStats = GetComponent<PlayerStats>();
        PlayerInfo = GetComponent<PlayerInfo>();
    }

    public void Enter()
    {
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
    }

    public abstract bool IsCompleted();
}