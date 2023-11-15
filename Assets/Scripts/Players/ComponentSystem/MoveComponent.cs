using Infrastructure.States;
using UnityEngine;

public class MoveComponent : IPayloadState<float>
{
    private readonly PlayerAnimationSetter _playerAnimationSetter;
    private readonly Transform _transform;
    private readonly Rigidbody2D _rigidbody2D;
    private readonly float _speed;
    private float _direction;

    public MoveComponent(PlayerAnimationSetter playerAnimationSetter, Transform transform, Rigidbody2D rigidbody2D, float speed)
    {
        _playerAnimationSetter = playerAnimationSetter;
        _transform = transform;
        _rigidbody2D = rigidbody2D;
        _speed = speed;
    }

    private void Flip(float direction)
    {
        if (direction > 0)
            _transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (direction < 0)
            _transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Move(float direction)
    {
        Flip(direction);
        _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
        _playerAnimationSetter.SetRunParameter(direction != 0);
    }

    public void Enter(float direction)
    {
        _direction = direction;
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

    public void Update(float deltaTime) =>
        Move(_direction);

    public void Enter()
    {
    }
}