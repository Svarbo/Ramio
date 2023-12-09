using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class FallTransition : Transition
    {
        public FallTransition(State nextState, PlayerInfo playerInfo)
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
}