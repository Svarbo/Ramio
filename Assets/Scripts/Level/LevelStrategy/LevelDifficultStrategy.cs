using Data;
using Edior;
using Player;
using UI.Level.EndGame;

namespace Level.LevelStrategy
{
    public abstract class LevelDifficultStrategy
    {
        protected readonly PlayerCanvasDrawer _playerCanvasDrawer;

        protected MainHero _player;
        protected Infrastructure.StateMachines.StateMachine _stateMachine;
        protected LevelsInfo _levelsInfo;
        
        public LevelDifficultStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
        {
            _levelsInfo = levelsInfo;
            _stateMachine = stateMachine;
            _player = player;
            _playerCanvasDrawer = _player.GetComponentInChildren<PlayerCanvasDrawer>();

            _playerCanvasDrawer.Construct(_stateMachine, _levelsInfo, player.InputServiceView, mainMenuButton);
        }

        public abstract void Execute();
    }
}