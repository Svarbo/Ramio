public class DesappearingTransition : Transition
{
    public DesappearingTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions()
    {
        return PlayerInfo.IsDesappearing
            && !PlayerInfo.IsHit;
    }
}