using UnityEngine;

public class WallJumpState : State
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _wallJumpForce;

    private void OnEnable()
    {
        WallJump();
    }

    private void WallJump()
    {
        PlayerAnimationSetter.ActivateJump();
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _wallJumpForce);
    }
}