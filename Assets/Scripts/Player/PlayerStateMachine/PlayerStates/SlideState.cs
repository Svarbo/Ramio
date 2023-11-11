using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlideState : PlayerState
{
    private Rigidbody2D _rigidbody2D;
    private int _slideAnimation = Animator.StringToHash("Slide");

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Slide();
    }

    private void Slide()
    {
        PlayerAnimator.Play(_slideAnimation);
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -PlayerStats.WallSlidingSpeed, float.MaxValue));
    }

    public override bool IsCompleted()
    {
        return PlayerInfo.IsHit
            || PlayerInfo.IsGrounded
            || PlayerInfo.IsJumpButtonPressed
            || !PlayerInfo.IsWallHooked;
    }
}