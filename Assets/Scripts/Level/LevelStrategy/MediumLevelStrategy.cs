using Data;
using Players;

namespace Level.LevelStrategy
{
    public class MediumLevelStrategy : LevelDifficultStrategy
    {
        public MediumLevelStrategy(Player personage, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo)
            : base(personage, stateMachine, levelsInfo)
        {
        }

        public override void Execute()
        {
        }
    }
}