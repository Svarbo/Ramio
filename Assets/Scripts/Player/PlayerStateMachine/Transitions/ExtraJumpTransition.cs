public class ExtraJumpTransition : Transition
{
    public ExtraJumpTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return !PlayerInfo.IsGrounded
            && PlayerInfo.IsExtraJumpReady 
            && PlayerInfo.IsJumpButtonPressed
            && !PlayerInfo.IsWallHooked;
    }
}