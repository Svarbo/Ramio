using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class FinishTransition : Transition
    {
        public FinishTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsFinished;
    }
}