using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
{
    public class FallTransition : Transition
    {
        public FallTransition(State nextState, Info playerInfo)
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