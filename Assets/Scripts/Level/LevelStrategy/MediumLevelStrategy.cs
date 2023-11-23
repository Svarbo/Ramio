public class MediumLevelStrategy : LevelDifficultStrategy
{
    private readonly Player _player;
    private LevelsInfo _levelsInfo;
    private readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public MediumLevelStrategy(Player player, StateMachine stateMachine, LevelsInfo levelsInfo)
        : base(player, stateMachine, levelsInfo)
    {
        _player = player;
        _levelsInfo = levelsInfo;
    }

    public override void Execute()
    {
    }
}