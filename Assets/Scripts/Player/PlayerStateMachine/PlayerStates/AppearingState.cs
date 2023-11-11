using UnityEngine;

public class AppearingState : PlayerState
{
    private int _appearingAnimation = Animator.StringToHash("Appearing");

    public override bool IsCompleted()
    {
        return PlayerInfo.IsAppearingAnimationFinished;
    }

    private void OnEnable()
    {
        PlayerAnimator.Play(_appearingAnimation);
    }
}