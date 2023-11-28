using Level.SpawnPoints;
using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    public LevelsInfo LevelsInfo;

    private HardLevelStrategy _hardLevelStrategy;
    private MediumLevelStrategy _mediumLevelStrategy;
    private LevelDifficultStrategy _levelDifficultStrategy;
    private Vector3 _startSpawnPosition;
    private Player _player;
    private GameBootstrap _gameBootstrap;
    private SpawnPointContainer _spawnPointContainer;
    private MainMenuButton _mainMenuButton;

    public void Construct(LevelsInfo levelsInfo)
    {
        _startSpawnPosition = FindObjectOfType<Spawner>().position.position;
        _gameBootstrap = FindObjectOfType<GameBootstrap>();
        _spawnPointContainer = FindObjectOfType<SpawnPointContainer>();
        _mainMenuButton = FindObjectOfType<MainMenuButton>();

        _spawnPointContainer.gameObject.SetActive(false);

        LevelsInfo = levelsInfo;
        Debug.Log(LevelsInfo.CurrentDifficult);
        Debug.Log("is mobile" +  LevelsInfo.IsMobile);

        PlayerFactory playerFactory = new PlayerFactory(_startSpawnPosition, levelsInfo.IsMobile, levelsInfo.CurrentDifficult);
        _player = playerFactory.Create();

        if (typeof(Easy) == LevelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new EasyLevelFactory(LevelsInfo, _player, _gameBootstrap.AppCore.StateMachine, _startSpawnPosition, _spawnPointContainer, _mainMenuButton).Create();
        else if (typeof(Medium) == LevelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new MediumLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, LevelsInfo, _mainMenuButton);
        else
            _levelDifficultStrategy = new HardLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, LevelsInfo, _mainMenuButton);

        _levelDifficultStrategy.Execute();
    }
}