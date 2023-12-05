using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class WalkTransition : Transition
    {
        public WalkTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsGrounded && !PlayerInfo.IsSpeedEqualZero;
    }
}