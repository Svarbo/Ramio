using Players.StateMachine.PlayerStates;

namespace Players.StateMachine.Transitions
{
    public class DesappearingTransition : Transition
    {
        public DesappearingTransition(State nextState, Info playerInfo)
        {
            NextState = nextState;
            PlayerInfo = playerInfo;
        }

        protected override bool CheckConditions()
        {
            return PlayerInfo.IsDesappearing
                && !PlayerInfo.IsHit;
        }
    }
}