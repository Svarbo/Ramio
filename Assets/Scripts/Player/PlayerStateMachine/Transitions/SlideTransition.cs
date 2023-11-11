public class SlideTransition : Transition
{
    public SlideTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return !PlayerInfo.IsGrounded
            && PlayerInfo.IsWallHooked
            && !PlayerInfo.IsJumpButtonPressed;
    }
}