public class HitTransition : Transition
{
    public HitTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return PlayerInfo.IsHit;
    }
}