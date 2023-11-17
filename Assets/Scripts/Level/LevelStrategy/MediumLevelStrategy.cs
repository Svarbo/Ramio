using UnityEngine;
using UnityEngine.SceneManagement;

public class MediumLevelStrategy : LevelDifficultStrategy
{
    private readonly Player _player;
    private LevelsInfo _levelsInfo;
    private GameBootstrap _gameBootstrap;
    private readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public MediumLevelStrategy(Player player, LevelsInfo levelsInfo, GameBootstrap gameBootstrap)
    {
        _player = player;
        _levelsInfo = levelsInfo;
        _gameBootstrap = gameBootstrap;

        _playerCanvasDrawer = _player.GetComponentInChildren<PlayerCanvasDrawer>();
        _playerCanvasDrawer.Construct(_gameBootstrap.AppCore.StateMachine, _levelsInfo);
    }

    public override void Execute()
    {
    }
}