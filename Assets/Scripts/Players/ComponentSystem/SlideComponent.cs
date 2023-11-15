using Infrastructure.States;
using UnityEngine;

public class SlideComponent : IState
{
    private readonly PlayerAnimationSetter _playerAnimationSetter;
    private readonly Rigidbody2D _rigidbody2D;
    private readonly float _wallSlidingSpeed;

    public SlideComponent(PlayerAnimationSetter playerAnimationSetter, Rigidbody2D rigidbody2D, float wallSlidingSpeed)
    {
        _playerAnimationSetter = playerAnimationSetter;
        _rigidbody2D = rigidbody2D;
        _wallSlidingSpeed = wallSlidingSpeed;
    }

    private void Slide()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlidingSpeed, float.MaxValue));
    }

    private void Update()
    {
        Slide();
    }

    public void Exit()
    {
        _playerAnimationSetter.SetWallHookedParameter(false);
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
        _playerAnimationSetter.SetWallHookedParameter(true);
    }
}