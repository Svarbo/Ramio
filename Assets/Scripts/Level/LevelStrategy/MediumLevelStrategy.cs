using Data;
using Edior;
using Infrastructure.StateMachines;
using Player;

namespace Level.LevelStrategy
{
    public class MediumLevelStrategy : LevelDifficultStrategy
    {
        private readonly MainHero _player;
        private readonly PlayerCanvasDrawer _playerCanvasDrawer;

        private LevelsInfo _levelsInfo;

        public MediumLevelStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
            : base(player, stateMachine, levelsInfo, mainMenuButton)
        {
            _player = player;
            _levelsInfo = levelsInfo;
        }

        public override void Execute()
        {
        }
    }
}