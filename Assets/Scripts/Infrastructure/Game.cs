using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine stateMachine = new StateMachine(coroutineRunner);
            stateMachine.Enter<BootstrapState>();
        }
    }
}