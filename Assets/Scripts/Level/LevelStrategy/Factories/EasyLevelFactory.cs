using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevelFactory
{
    private LevelsInfo _levelsInfo;
    private Player _player;
    private Vector3 _startSpawnPosition;
    private LevelsProgress _levelsProgress;

    public EasyLevelFactory(LevelsInfo levelsInfo, Player player, Vector3 startSpawnPosition, LevelsProgress levelsProgress)
    {
        _levelsInfo = levelsInfo;
        _player = player;
        _startSpawnPosition = startSpawnPosition;
        _levelsProgress = levelsProgress;
    }

    public EasyLevelStrategy Create()
    {
        LevelsProgress.Easy easy = _levelsProgress.GetDifficultLevel(typeof(LevelsProgress.Easy)) as LevelsProgress.Easy;

        EasyLevelStrategy easyLevelStrategy = new EasyLevelStrategy
        (
            player: _player,
            lastCheckpoint: easy.GetSpawnPoint(SceneManager.GetActiveScene().name),
            startCheckpoint: _startSpawnPosition
        );

        return easyLevelStrategy;
    }
}