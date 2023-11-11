public class FallTransition : Transition
{
    public FallTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return !PlayerInfo.IsGrounded 
            && !PlayerInfo.IsJumpButtonPressed 
            && !PlayerInfo.IsWallHooked;
    }
}