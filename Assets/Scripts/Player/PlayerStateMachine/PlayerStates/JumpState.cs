using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpState : PlayerState
{
    [SerializeField] private AudioClip _jumpSound;

    private Rigidbody2D _rigidbody2D;
    private int _jumpAnimation = Animator.StringToHash("Jump");

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Jump();
    }

    private void Jump()
    {
        PlayerAnimator.Play(_jumpAnimation);
        AudioSource.PlayOneShot(_jumpSound);

        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, PlayerStats.JumpForce);
    }

    public override bool IsCompleted()
    {
        return PlayerInfo.IsGrounded
            || PlayerInfo.IsHit
            || PlayerInfo.IsJumpButtonPressed && PlayerInfo.IsExtraJumpReady
            || PlayerInfo.IsWallHooked
            || PlayerInfo.IsFalling;
    }
}