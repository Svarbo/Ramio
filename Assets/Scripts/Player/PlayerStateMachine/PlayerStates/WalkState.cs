using UnityEngine;

public class WalkState : PlayerState 
{
    private int _walkAnimation = Animator.StringToHash("Walk");

    public override bool IsCompleted()
    {
        return PlayerInfo.IsSpeedEqualZero
            || PlayerInfo.IsHit
            || !PlayerInfo.IsGrounded
            || PlayerInfo.IsJumpButtonPressed;
    }

    private void OnEnable() => 
        PlayerAnimator.Play(_walkAnimation);
}