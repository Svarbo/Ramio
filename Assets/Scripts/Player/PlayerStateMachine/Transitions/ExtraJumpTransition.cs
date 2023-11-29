using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
{
    public class ExtraJumpTransition : Transition
    {
        public ExtraJumpTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions()
        {
            return !PlayerInfo.IsGrounded
                && PlayerInfo.IsExtraJumpReady
                && PlayerInfo.IsJumpButtonPressed
                && !PlayerInfo.IsWallHooked;
        }
    }
}