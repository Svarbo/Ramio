using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class DesappearingTransition : Transition
    {
        public DesappearingTransition(State nextState, PlayerInfo playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions() => 
            PlayerInfo.IsDesappearing && !PlayerInfo.IsHit;
    }
}