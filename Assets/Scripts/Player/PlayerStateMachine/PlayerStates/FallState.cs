using UnityEngine;

public class FallState : PlayerState
{
    private int _fallAnimation = Animator.StringToHash("Fall");

    private void OnEnable()
    {
        PlayerAnimator.Play(_fallAnimation);
    }

    public override bool IsCompleted()
    {
        return PlayerInfo.IsGrounded
            || PlayerInfo.IsHit
            || PlayerInfo.IsWallHooked
            || PlayerInfo.IsJumpButtonPressed && PlayerInfo.IsExtraJumpReady
            || !PlayerInfo.IsFalling;
    }
}