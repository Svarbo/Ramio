using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerFliper))]
public class WallJumpState : PlayerState
{
    [SerializeField] private AudioClip _wallJumpSound;

    private Rigidbody2D _rigidbody2D;
    private PlayerFliper _playerFliper;
    private int _jumpAnimation = Animator.StringToHash("Jump");

    protected override void Awake()
    {
        base.Awake();

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerFliper = GetComponent<PlayerFliper>();
    }

    private void OnEnable()
    {
        WallJump();
        SetFlip();
    }

    private void WallJump()
    {
        PlayerAnimator.Play(_jumpAnimation);
        AudioSource.PlayOneShot(_wallJumpSound);

        _rigidbody2D.velocity = new Vector2(PlayerStats.WallJumpForce.x * -PlayerInfo.DirectionIndicator, PlayerStats.WallJumpForce.y);
    }

    private void SetFlip()
    {
        _playerFliper.enabled = true;

        int currentDirectionIndicator = PlayerInfo.DirectionIndicator;
        PlayerInfo.SetDirectionIndicator(-currentDirectionIndicator);

        _playerFliper.enabled = false;
    }

    public override bool IsCompleted()
    {
        return PlayerInfo.IsWallHooked
            || PlayerInfo.IsHit
            || PlayerInfo.IsJumpButtonPressed && PlayerInfo.IsExtraJumpReady
            || PlayerInfo.IsGrounded
            || PlayerInfo.IsFalling;
    }
}