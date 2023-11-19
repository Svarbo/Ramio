using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevelFactory
{
    private LevelsInfo _levelsInfo;
    private Player _player;
    private Vector3 _startSpawnPosition;

    public EasyLevelFactory(LevelsInfo levelsInfo, Player player, Vector3 startSpawnPosition)
    {
        _levelsInfo = levelsInfo;
        _player = player;
        _startSpawnPosition = startSpawnPosition;
    }

    public EasyLevelStrategy Create() =>
        null;
}