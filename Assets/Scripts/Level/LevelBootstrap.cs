using System;
using Data;
using Infrastructure;
using Level;
using Level.Factories;
using Players;
using UI.MainMenu.Models;
using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private LevelsProgress _levelsProgress;
    [SerializeField] private UserInfo _userInfo;

    private LevelsInfo _levelsInfo;

    private HardLevelStrategy _hardLevelStrategy;
    private MediumLevelStrategy _mediumLevelStrategy;
    private LevelDifficultStrategy _levelDifficultStrategy;
    private Vector3 _startSpawnPosition;
    private Type _difficult;
    private Player _player;
    private GameBootstrap _gameBootstrap;

    public void Construct(LevelsInfo levelsInfo)
    {
        _startSpawnPosition = FindObjectOfType<Spawner>().position.position;
        _gameBootstrap = FindObjectOfType<GameBootstrap>();
                
        _difficult = levelsInfo.CurrentDifficult;
        _levelsInfo = levelsInfo;

        PlayerFactory playerFactory = new PlayerFactory(_startSpawnPosition, _userInfo);
        _player = playerFactory.Create();

        #region DifficultLogic
        
        if (typeof(LevelsProgress.Easy) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new EasyLevelFactory(_levelsInfo, _player, _startSpawnPosition, _levelsProgress).Create();
        else if (typeof(LevelsProgress.Medium) == _levelsInfo.CurrentDifficult)
            _levelDifficultStrategy = new MediumLevelStrategy(_player, _startSpawnPosition, _levelsInfo, _gameBootstrap);
        else
            _levelDifficultStrategy = new HardLevelStrategy(_player, _startSpawnPosition, _gameBootstrap, _levelsInfo);

        _levelDifficultStrategy.Execute();

        #endregion
    }

    // private void OnDestroy() =>
    //     _referee.Dispose();
}