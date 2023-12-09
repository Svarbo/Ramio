using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class JumpTransition : Transition
    {
        public JumpTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsGrounded && PlayerInfo.IsJumpButtonPressed;
    }
}