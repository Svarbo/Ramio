using Data;
using Edior;
using Infrastructure.StateMachines;
using Player;

namespace Level.LevelStrategy
{
    public class HardLevelStrategy : LevelDifficultStrategy
    {
        private MainHero _player;
        private readonly LevelsInfo _levelsInfo;

        public HardLevelStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
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