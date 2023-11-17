public class IdleTransition : Transition
{
    public IdleTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions() => 
        PlayerInfo.IsGrounded && PlayerInfo.IsSpeedEqualZero && PlayerInfo.IsAppearingAnimationFinished && !PlayerInfo.IsJumpButtonPressed;
}