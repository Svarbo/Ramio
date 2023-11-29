using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
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