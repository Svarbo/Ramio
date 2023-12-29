using Data;
using Infrastructure.StateMachines;
using Players;

namespace Level.LevelStrategy
{
	public class NotCheckpointLevelStrategy : LevelDifficultStrategy
	{
		public NotCheckpointLevelStrategy(
			Player personage,
			StateMachine stateMachine,
			LevelsInfo levelsInfo,
			AcceptLevelsDeterminator acceptLevelsDeterminator)
			: base(personage, stateMachine, levelsInfo, acceptLevelsDeterminator)
		{
		}
	}
}