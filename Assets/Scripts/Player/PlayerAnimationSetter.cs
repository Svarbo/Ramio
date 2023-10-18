using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationSetter : MonoBehaviour
{
    private Animator _animator;
    private int _jumpAnimation = Animator.StringToHash("Jump");
    private int _doubleJumpAnimation = Animator.StringToHash("DoubleJump");
    private int _isGroundedParameter = Animator.StringToHash("IsGrounded");
    private int _isWallHookedParameter = Animator.StringToHash("IsWallHooked");
    private int _isRunParameter = Animator.StringToHash("IsRun");
    private int _danceStateHash = Animator.StringToHash("Dance");
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDance()
    {
        _animator.Play(_danceStateHash);
    }
    
    public void SetRunParameter(bool value)
    {
        _animator.SetBool(_isRunParameter, value);
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