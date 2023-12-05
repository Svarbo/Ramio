using Data;
using Infrastructure.StateMachines;
using Players;
using UI.Level;

namespace Level.LevelStrategy
{
    public class HardLevelStrategy : LevelDifficultStrategy
    {
        public HardLevelStrategy(Player personage
            , Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo)
            : base(personage, stateMachine, levelsInfo)
        {
        }

        public override void Execute()
        {
        }
    }
}