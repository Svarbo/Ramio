using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class DeceleratedWalkTransition : Transition
    {
        public DeceleratedWalkTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsDecelerated;
    }
}