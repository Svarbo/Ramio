using System;
using Data;
using Infrastructure;
using Level;
using Players;
using UI.MainMenu.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private LevelsProgress _levelsProgress;
    [SerializeField] private UserInfo _userInfo;
    private PlayerCanvasDrawer _playerCanvas;

    private LevelsInfo _levelsInfo;

    private HardLevelStrategy _hardLevelStrategy;
    private MediumLevelStrategy _mediumLevelStrategy;
    private LevelDifficultStrategy _levelDifficultStrategy;
    private Vector3 _startSpawnPosition;
    private Type _difficult;
    private Player _player;
    private GameBootstrap _gameBootstrap;
    private Referee _referee;

    public void Construct(LevelsInfo levelsInfo)
    {
        // ImportantObjects /// PlayerCanvasDrawer
        
        _startSpawnPosition = FindObjectOfType<Spawner>().position.position;
        _gameBootstrap = FindObjectOfType<GameBootstrap>();

        _difficult = levelsInfo.CurrentDifficult;
        _levelsInfo = levelsInfo;

        PlayerFactory playerFactory = new PlayerFactory(_startSpawnPosition, _userInfo);
        _player = playerFactory.Create();
        _playerCanvas = Instantiate(Resources.Load<PlayerCanvasDrawer>("PlayerCanvas"));
        _referee = new Referee(_player, _playerCanvas);

        #region DifficultLogic

        LevelsProgress.Easy easy = _levelsProgress.GetDifficultLevel(typeof(LevelsProgress.Easy)) as LevelsProgress.Easy;

        if (typeof(LevelsProgress.Easy) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new EasyLevelStrategy
            (
                player: _player,
                lastCheckpoint: easy.GetSpawnPoint(SceneManager.GetActiveScene().name),
                startCheckpoint: _startSpawnPosition
            );

        else if (typeof(LevelsProgress.Medium) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new MediumLevelStrategy(_player, _startSpawnPosition, _levelsInfo, _gameBootstrap, _playerCanvas);
        else
            _levelDifficultStrategy = new HardLevelStrategy(_player, _startSpawnPosition, _gameBootstrap, _levelsInfo);

        _levelDifficultStrategy.Execute();

        #endregion

    }

    private void OnDestroy() =>
        _referee.Dispose();
}