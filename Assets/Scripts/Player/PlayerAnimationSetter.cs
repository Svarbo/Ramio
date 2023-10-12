using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationSetter : MonoBehaviour
{
    private Animator _animator;
    private int _jumpAnimation = Animator.StringToHash("Jump");
    private int _doubleJumpAnimation = Animator.StringToHash("DoubleJump");
    private int _isGroundedParameter = Animator.StringToHash("IsGrounded");
    private int _isWallHookedParameter = Animator.StringToHash("IsWallHooked");
    private int _speedParameter = Animator.StringToHash("Speed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeedParameter(int value)
    {
        _animator.SetInteger(_speedParameter, value);
    }

    public void SetGroundedParameter(bool value)
    {
        _animator.SetBool(_isGroundedParameter, value);
    }

    public void SetWallHookedParameter(bool value)
    {
        _animator.SetBool(_isWallHookedParameter, value);
    }

    public void ActivateJump()
    {
        _animator.Play(_jumpAnimation);
    }

    public void ActivateDoubleJump()
    {
        _animator.Play(_doubleJumpAnimation);
    }
}