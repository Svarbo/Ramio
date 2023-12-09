using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class HitTransition : Transition
    {
        public HitTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() =>
            PlayerInfo.IsHit;
    }
}