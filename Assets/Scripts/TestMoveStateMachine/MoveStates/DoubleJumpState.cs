using UnityEngine;

public class DoubleJumpState : State
{
    [SerializeField] private float _extraJumpForce;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        DoubleJump();
    }

    private void DoubleJump()
    {
        PlayerAnimationSetter.ActivateDoubleJump();
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _extraJumpForce);
    }
}