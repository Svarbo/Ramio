public class HardLevelStrategy : LevelDifficultStrategy
{
    private Player _player;
    private readonly LevelsInfo _levelsInfo;

    public HardLevelStrategy(Player player,  StateMachine stateMachine, LevelsInfo levelsInfo, MainMenuButton mainMenuButton)
        : base(player, stateMachine, levelsInfo, mainMenuButton)
    {
        _player = player;
        _levelsInfo = levelsInfo;
    }

    public override void Execute()
    {
    }
}