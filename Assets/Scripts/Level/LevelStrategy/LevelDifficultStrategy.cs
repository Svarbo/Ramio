using Data;
using Edior;
using Player;

namespace Level.LevelStrategy
{
    public abstract class LevelDifficultStrategy
    {
        protected readonly PlayerCanvasDrawer _playerCanvasDrawer;

        protected MainHero _player;
        protected Infrastructure.StateMachines.StateMachine _stateMachine;
        protected LevelsInfo _levelsInfo;

        public abstract void Execute();

        public LevelDifficultStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
        {
            _levelsInfo = levelsInfo;
            _stateMachine = stateMachine;
            _player = player;
            _playerCanvasDrawer = _player.GetComponentInChildren<PlayerCanvasDrawer>();

            _playerCanvasDrawer.Construct(_stateMachine, _levelsInfo, player.InputServiceView, mainMenuButton);
        }

    }
}