public class DeceleratedWalkTransition : Transition
{
    public DeceleratedWalkTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions() => 
        PlayerInfo.IsDecelerated;
}