using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class DeceleratedIdleTransition : Transition
    {
        public DeceleratedIdleTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions()
        {
            return PlayerInfo.IsGrounded
                && PlayerInfo.IsDecelerated
                && PlayerInfo.IsSpeedEqualZero;
        }
    }
}