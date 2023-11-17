using UnityEngine;

public class IdleState : PlayerState
{
    private int _idleAnimation = Animator.StringToHash("Idle");

    private void OnEnable() => 
        PlayerAnimator.Play(_idleAnimation);

    public override bool IsCompleted()
    {
        return !PlayerInfo.IsSpeedEqualZero
            || PlayerInfo.IsHit
            || PlayerInfo.IsJumpButtonPressed;
    }
}