using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
{
    public class IdleTransition : Transition
    {
        public IdleTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsGrounded && PlayerInfo.IsSpeedEqualZero && PlayerInfo.IsAppearingAnimationFinished && !PlayerInfo.IsJumpButtonPressed;
    }
}