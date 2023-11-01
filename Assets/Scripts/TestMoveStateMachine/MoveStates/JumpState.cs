using UnityEngine;

public class JumpState : State
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;

    private void OnEnable()
    {
        Jump();
    }

    private void Jump()
    {
        PlayerAnimationSetter.ActivateJump();
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }
}