using Player.PlayerStateMachine.PlayerStates;

namespace Player.PlayerStateMachine.Transitions
{
    public class HitTransition : Transition
    {
        public HitTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsHit;
    }
}