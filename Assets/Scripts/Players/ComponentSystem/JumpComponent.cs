using Infrastructure.States;
using UnityEngine;

public class JumpComponent : IState
{
    private readonly PlayerAnimationSetter _playerAnimationSetter;
    private readonly Rigidbody2D _rigidbody2D;
    private readonly float _jumpForce;

    public JumpComponent(PlayerAnimationSetter playerAnimationSetter, Rigidbody2D rigidbody2D, float jumpForce)
    {
        _playerAnimationSetter = playerAnimationSetter;
        _rigidbody2D = rigidbody2D;
        _jumpForce = jumpForce;
    }

    private void SetJumpVelocity()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }

    private void Jump()
    {
        SetJumpVelocity();
        _playerAnimationSetter.ActivateJump();
    }
    
    public void Exit()
    {
    }

    public void FixedUpdate(float deltaTime)
    {
    }

    public void LateUpdate(float deltaTime)
    {
    }

    public void Update(float deltaTime)
    {
    }

    public void Enter()
    {
        Jump();
    }
}
