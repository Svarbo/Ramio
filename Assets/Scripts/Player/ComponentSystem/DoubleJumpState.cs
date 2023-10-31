using Infrastructure.States;
using UnityEngine;

public class DoubleJumpState : IState
{
    private readonly Rigidbody2D _rigidbody2D;
    private readonly float _jumpForce;
    private readonly PlayerAnimationSetter _playerAnimationSetter;
    private float _extraJumpForce;
    private int _maxExtraJumpsCount = 1;
    private static int _currentExtraJumpsCount = 0;

    public DoubleJumpState(PlayerAnimationSetter playerAnimationSetter, Rigidbody2D rigidbody2D, float jumpForce)
    {
        _playerAnimationSetter = playerAnimationSetter;
        _rigidbody2D = rigidbody2D;
        _jumpForce = jumpForce;
    }

    public void Exit() =>
        _currentExtraJumpsCount = 0;

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
        if (_currentExtraJumpsCount < _maxExtraJumpsCount)
        {
            _currentExtraJumpsCount++;
            ActivateDoubleJump();
        }
    }

    private void ActivateDoubleJump()
    {
        _playerAnimationSetter.ActivateDoubleJump();
        SetJumpVelocity();
    }

    private void SetJumpVelocity() =>
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
}