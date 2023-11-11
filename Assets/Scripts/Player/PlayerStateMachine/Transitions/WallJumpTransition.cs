public class WallJumpTransition : Transition
{
    public WallJumpTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return !PlayerInfo.IsGrounded 
            && PlayerInfo.IsWallHooked 
            && PlayerInfo.IsJumpButtonPressed;
    }
}