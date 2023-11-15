using Infrastructure.States;
using UnityEngine;

public class WallJumpComponent : IPayloadState<WallJumpParametr>
{
    private readonly PlayerAnimationSetter _playerAnimationSetter;
    private readonly Rigidbody2D _rigidbody2D;
    private readonly Vector2 _forceToWallJump;

    public WallJumpComponent(PlayerAnimationSetter playerAnimationSetter, Rigidbody2D rigidbody2D, Vector2 forceToWallJump)
    {
        _playerAnimationSetter = playerAnimationSetter;
        _rigidbody2D = rigidbody2D;
        _forceToWallJump = forceToWallJump;
    }


    public void Enter(WallJumpParametr parametr)
    {
        ActivateWallJump(parametr.Direction, parametr.ForceVEctor);
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
    }

    private void ActivateWallJump(int direction, Vector2 parametrForceVEctor)
    {
        _playerAnimationSetter.ActivateJump();
        Vector2 force = new Vector2(direction * parametrForceVEctor.x, parametrForceVEctor.y);
        _rigidbody2D.AddForce(force);
        Debug.Log("direction " + direction);
        
        Debug.Log("ActivateWallJump - VEctor force = " + force);
    }
}
