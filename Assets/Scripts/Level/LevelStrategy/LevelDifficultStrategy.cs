public abstract class LevelDifficultStrategy
{
    protected Player _player;
    protected StateMachine _stateMachine;
    protected LevelsInfo _levelsInfo;
    protected readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public LevelDifficultStrategy(Player player, StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
        _player = player;
        _playerCanvasDrawer = _player.GetComponentInChildren<PlayerCanvasDrawer>();
        
        _playerCanvasDrawer.Construct(_stateMachine, _levelsInfo, player.InputServiceView);
    }

    public abstract void Execute();
}