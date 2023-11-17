using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ExtraJumpState : PlayerState
{
    [SerializeField] private AudioClip _extraJumpSound;

    private Rigidbody2D _rigidbody2D;
    private int _extraJumpAnimation = Animator.StringToHash("ExtraJump");

    protected override void Awake()
    {
        base.Awake();

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => 
        DoubleJump();

    private void DoubleJump()
    {
        PlayerAnimator.Play(_extraJumpAnimation);
        AudioSource.PlayOneShot(_extraJumpSound);

        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, PlayerStats.ExtraJumpForce);
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