using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IdleState : PlayerState
{
    private Rigidbody2D _rigidbody2D;
    private int _idleAnimation = Animator.StringToHash("Idle");

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = Vector2.zero;
        PlayerAnimator.Play(_idleAnimation);
}

    public override bool IsCompleted()
    {
        return !PlayerInfo.IsSpeedEqualZero
            || PlayerInfo.IsHit
            || PlayerInfo.IsJumpButtonPressed;
    }
}