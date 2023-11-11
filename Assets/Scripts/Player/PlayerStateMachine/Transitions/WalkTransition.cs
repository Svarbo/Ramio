public class WalkTransition : Transition
{
    public WalkTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return PlayerInfo.IsGrounded && !PlayerInfo.IsSpeedEqualZero;
    }
}