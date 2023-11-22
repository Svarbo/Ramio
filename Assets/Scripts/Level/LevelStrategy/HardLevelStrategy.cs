public class HardLevelStrategy : LevelDifficultStrategy
{
    private Player _player;
    private readonly LevelsInfo _levelsInfo;

    public HardLevelStrategy(Player player,  StateMachine stateMachine, LevelsInfo levelsInfo)
        : base(player, stateMachine, levelsInfo)
    {
        _player = player;
        _levelsInfo = levelsInfo;

        _player.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _levelsInfo.SceneName = "Level0";
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }

    public override void Execute()
    {
    }
}