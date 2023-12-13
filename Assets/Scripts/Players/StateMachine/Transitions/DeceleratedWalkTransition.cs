using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class DeceleratedWalkTransition : Transition
    {
        public DeceleratedWalkTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions()
        {
            return PlayerInfo.IsDecelerated
                && PlayerInfo.IsGrounded
                && !PlayerInfo.IsSpeedEqualZero;
        }
    }
}