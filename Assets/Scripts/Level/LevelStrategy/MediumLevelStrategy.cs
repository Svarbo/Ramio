using Data;
using Edior;
using Infrastructure.StateMachines;
using Player;

namespace Level.LevelStrategy
{
    public class MediumLevelStrategy : LevelDifficultStrategy
    {
        public MediumLevelStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
            : base(player, stateMachine, levelsInfo, mainMenuButton)
        {
        }

        public override void Execute()
        {
        }
    }
}