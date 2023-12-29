using Data;
using Data.Difficults;
using Infrastructure;
using Level.LevelStrategy;
using Level.LevelStrategy.Factories;
using Level.SpawnPoints;
using Players;
using UnityEngine;

namespace Level
{
    public class LevelBootstrap : MonoBehaviour
    {
        private LevelDifficultStrategy _levelDifficultStrategy;
        private Vector3 _startSpawnPosition;
        private Player _player;
        private GameBootstrap _gameBootstrap;
        private SpawnPointContainer _spawnPointContainer;
        private AcceptLevelsDeterminator _acceptLevelsDeterminator;

        public LevelsInfo LevelsInfo { get; private set; }

        private void OnDestroy() =>
            _levelDifficultStrategy.Dispose();

        public void Construct(LevelsInfo levelsInfo)
        {
            LevelsInfo = levelsInfo;

            FindObjects();
            _spawnPointContainer.gameObject.SetActive(false);
            CreatePersonage(levelsInfo);
            CreateAcceptLevelsDeterminator();
            SetDifficult();
        }

        private void FindObjects()
        {
            _startSpawnPosition = FindObjectOfType<Spawner>().Position.position;
            _gameBootstrap = FindObjectOfType<GameBootstrap>();
            _spawnPointContainer = FindObjectOfType<SpawnPointContainer>();
        }

        private void SetDifficult()
        {
            if (typeof(Easy) == LevelsInfo.CurrentDifficult)
                _levelDifficultStrategy = new CheckpointLevelFactory(LevelsInfo, _player, _gameBootstrap.AppCore.StateMachine, _startSpawnPosition, _spawnPointContainer, _acceptLevelsDeterminator).Create();
            else
                _levelDifficultStrategy = new NotCheckpointLevelStrategy(_player, _gameBootstrap.AppCore.StateMachine, LevelsInfo, _acceptLevelsDeterminator);

            _levelDifficultStrategy.Execute();
        }

        private void CreateAcceptLevelsDeterminator() =>
            _acceptLevelsDeterminator = new AcceptLevelsDeterminator(LevelsInfo);

        private void CreatePersonage(LevelsInfo levelsInfo)
        {
            PlayerFactory personageFactory = new PlayerFactory(_startSpawnPosition, levelsInfo.IsMobile, levelsInfo.CurrentDifficult);
            _player = personageFactory.Create();
        }
    }
}