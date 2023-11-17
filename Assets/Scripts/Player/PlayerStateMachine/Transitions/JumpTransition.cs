public class JumpTransition : Transition
{
    public JumpTransition(PlayerState nextState, PlayerInfo playerInfo)
    {
        NextState = nextState;
        PlayerInfo = playerInfo;
    }

    protected override bool CheckConditions() => 
        PlayerInfo.IsGrounded && PlayerInfo.IsJumpButtonPressed;
}