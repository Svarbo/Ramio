using Assets.Scripts.Data;
using Assets.Scripts.Edior;
using Assets.Scripts.Infrastructure.StateMachines;

public class MediumLevelStrategy : LevelDifficultStrategy
{
    private readonly Player _player;
    private LevelsInfo _levelsInfo;
    private readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public MediumLevelStrategy(Player player, StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
        : base(player, stateMachine, levelsInfo, mainMenuButton)
    {
        _player = player;
        _levelsInfo = levelsInfo;
    }

    public override void Execute()
    {
    }
}