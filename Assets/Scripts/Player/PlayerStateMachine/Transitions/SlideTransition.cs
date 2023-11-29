using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
{
    public class SlideTransition : Transition
    {
        public SlideTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions()
        {
            return !PlayerInfo.IsGrounded
                && PlayerInfo.IsWallHooked
                && !PlayerInfo.IsJumpButtonPressed;
        }
    }
}