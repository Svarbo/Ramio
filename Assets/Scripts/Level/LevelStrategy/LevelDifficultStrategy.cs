using Assets.Scripts.Data;
using Assets.Scripts.Edior;
using Assets.Scripts.Infrastructure.StateMachines;

public abstract class LevelDifficultStrategy
{
    protected Player _player;
    protected StateMachine _stateMachine;
    protected LevelsInfo _levelsInfo;
    protected readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public LevelDifficultStrategy(Player player, StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
        _player = player;
        _playerCanvasDrawer = _player.GetComponentInChildren<PlayerCanvasDrawer>();
        
        _playerCanvasDrawer.Construct(_stateMachine, _levelsInfo, player.InputServiceView, mainMenuButton);
    }

    public abstract void Execute();
}