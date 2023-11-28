using Assets.Scripts.Data;
using Assets.Scripts.Data.Difficults;
using Assets.Scripts.Edior;
using Assets.Scripts.Infrastructure.StateMachines;
using Level.SpawnPoints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevelFactory
{
    private LevelsInfo _levelsInfo;
    private Player _player;
    private Vector3 _startSpawnPosition;
    private StateMachine _stateMachine;
    private SpawnPointContainer _spawnPointContainer;
    private readonly MainMenuButton _mainMenuButton;

    public EasyLevelFactory(LevelsInfo levelsInfo, Player player, StateMachine stateMachine, Vector3 startSpawnPosition, SpawnPointContainer spawnPointContainer,
        MainMenuButton mainMenuButton)
    {
        _spawnPointContainer = spawnPointContainer;
        _mainMenuButton = mainMenuButton;
        _stateMachine = stateMachine;
        _levelsInfo = levelsInfo;
        _player = player;
        _startSpawnPosition = startSpawnPosition;
    }

    public EasyLevelStrategy Create() =>
        new EasyLevelStrategy
        (
            _player,
            _stateMachine,
            _levelsInfo,
            _spawnPointContainer,
            lastCheckpoint: GetLastPosition(),
            startCheckpoint: _startSpawnPosition,
            _mainMenuButton
        );

    private Vector3 GetLastPosition()
    {
        Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
        return easy.GetSpawnPoint(SceneManager.GetActiveScene().name).Position;
    }
}