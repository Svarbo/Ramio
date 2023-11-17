using UnityEngine;

public class DesappearingState : PlayerState
{
    private int _desappearingAnimation = Animator.StringToHash("Desappearing");

    private void OnEnable() => 
        PlayerAnimator.Play(_desappearingAnimation);

    public override bool IsCompleted() => 
        !PlayerInfo.IsDesappearing;
}