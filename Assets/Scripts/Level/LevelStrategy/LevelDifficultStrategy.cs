using Data;
using Players;

namespace Level.LevelStrategy
{
    public abstract class LevelDifficultStrategy
    {
        protected Player _personage;
        protected Infrastructure.StateMachines.StateMachine _stateMachine;
        protected LevelsInfo _levelsInfo;
        
        public LevelDifficultStrategy(Player player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo)
        {
            _levelsInfo = levelsInfo;
            _stateMachine = stateMachine;
            _personage = player;

            //TODO: Избавиться
            //_playerCanvasDrawer.Construct(_stateMachine, _levelsInfo, player.InputServiceView, mainMenuButton);
        }

        public abstract void Execute();
    }
}