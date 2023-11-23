using Level.SpawnPoints;
using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private UserInfo _userInfo;

    public LevelsInfo _levelsInfo;

    private HardLevelStrategy _hardLevelStrategy;
    private MediumLevelStrategy _mediumLevelStrategy;
    private LevelDifficultStrategy _levelDifficultStrategy;
    private Vector3 _startSpawnPosition;
    private Player _player;
    private GameBootstrap _gameBootstrap;
    private SpawnPointContainer _spawnPointContainer;

    public void Construct(LevelsInfo levelsInfo)
    {
        _startSpawnPosition = FindObjectOfType<Spawner>().position.position;
        _gameBootstrap = FindObjectOfType<GameBootstrap>();
        _spawnPointContainer = FindObjectOfType<SpawnPointContainer>();
        
        _spawnPointContainer.gameObject.SetActive(false);
        
        _levelsInfo = levelsInfo;
        Debug.Log(_levelsInfo.CurrentDifficult);

        PlayerFactory playerFactory = new PlayerFactory(_startSpawnPosition, _userInfo);
        _player = playerFactory.Create();

        if (typeof(Easy) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new EasyLevelFactory(_levelsInfo, _player, _gameBootstrap.AppCore.StateMachine, _startSpawnPosition, _spawnPointContainer).Create();
        else if (typeof(Medium) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new MediumLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, _levelsInfo);
        else
            _levelDifficultStrategy = new HardLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, _levelsInfo);

        _levelDifficultStrategy.Execute();
    }
}