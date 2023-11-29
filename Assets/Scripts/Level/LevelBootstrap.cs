using Player;
using Data;
using Data.Difficults;
using Edior;
using Infrastructure;
using Level.LevelStrategy;
using Level.SpawnPoints;
using UnityEngine;
using Level.LevelStrategy.Factories;

namespace Level
{
    public class LevelBootstrap : MonoBehaviour
    {
        public LevelsInfo LevelsInfo;

        private HardLevelStrategy _hardLevelStrategy;
        private MediumLevelStrategy _mediumLevelStrategy;
        private LevelDifficultStrategy _levelDifficultStrategy;
        private Vector3 _startSpawnPosition;
        private MainHero _player;
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
            Debug.Log("is mobile" + LevelsInfo.IsMobile);

            Factory playerFactory = new Factory(_startSpawnPosition, levelsInfo.IsMobile, levelsInfo.CurrentDifficult);
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
}