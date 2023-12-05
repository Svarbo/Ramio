using Players;
using Data;
using Data.Difficults;
using Infrastructure;
using Level.LevelStrategy;
using Level.SpawnPoints;
using UnityEngine;
using Level.LevelStrategy.Factories;
using Infrastructure.StateMachines;

namespace Level
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField] private FinishZone _finishZone;

        private LevelDifficultStrategy _levelDifficultStrategy;
        private LevelLoader _levelLoader;
        private Vector3 _startSpawnPosition;
        private Player _player;
        private GameBootstrap _gameBootstrap;
        private SpawnPointContainer _spawnPointContainer;
        private AcceptLevelsDeterminator _acceptLevelsDeterminator;

        public LevelsInfo LevelsInfo { get; private set; }

        public void Construct(LevelsInfo levelsInfo)
        {
            LevelsInfo = levelsInfo;

            FindObjects();
            CreatePersonage(levelsInfo);
            CreateLevelLoader(levelsInfo);
            SetDifficult();
            CreateAcceptLevelsDeterminator();

            _spawnPointContainer.gameObject.SetActive(false);
        }

        private void FindObjects()
        {
            _startSpawnPosition = FindObjectOfType<Spawner>().position.position;
            _gameBootstrap = FindObjectOfType<GameBootstrap>();
            _spawnPointContainer = FindObjectOfType<SpawnPointContainer>();
        }

        private void SetDifficult()
        {
            if (typeof(Easy) == LevelsInfo.CurrentDifficult)
                _levelDifficultStrategy = new EasyLevelFactory(LevelsInfo, _player, _gameBootstrap.AppCore.StateMachine, _startSpawnPosition, _spawnPointContainer).Create();
            else if (typeof(Medium) == LevelsInfo.CurrentDifficult)
                _levelDifficultStrategy = new MediumLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, LevelsInfo);
            else
                _levelDifficultStrategy = new HardLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, LevelsInfo);

            _levelDifficultStrategy.Execute();
        }

        private void CreateAcceptLevelsDeterminator()
        {
            _acceptLevelsDeterminator = new AcceptLevelsDeterminator(LevelsInfo);
            _finishZone.Construct(_acceptLevelsDeterminator);
        }

        private void CreatePersonage(LevelsInfo levelsInfo)
        {
            //TODO: Прокинуть LevelLoader
            PlayerFactory personageFactory = new PlayerFactory(_startSpawnPosition, levelsInfo.IsMobile, levelsInfo.CurrentDifficult);
            _player = personageFactory.Create();
        }

        private void CreateLevelLoader(LevelsInfo levelsInfo)
        {
            StateMachine stateMachine = _gameBootstrap.AppCore.StateMachine;
            _levelLoader = new LevelLoader(stateMachine, levelsInfo);
        }
    }
}