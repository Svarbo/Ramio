using Data;
using Data.Difficults;
using Infrastructure.StateMachines;
using Level.SpawnPoints;
using Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.LevelStrategy.Factories
{
    public class CheckpointLevelFactory
    {
        private readonly LevelsInfo _levelsInfo;
        private readonly Player _player;
        private readonly Vector3 _startSpawnPosition;
        private readonly StateMachine _stateMachine;
        private readonly SpawnPointContainer _spawnPointContainer;
        private readonly AcceptLevelsDeterminator _acceptLevelsDeterminator;

        public CheckpointLevelFactory(
            LevelsInfo levelsInfo, 
            Player player, 
            StateMachine stateMachine,
            Vector3 startSpawnPosition, 
            SpawnPointContainer spawnPointContainer,
            AcceptLevelsDeterminator acceptLevelsDeterminator)
        {
            _spawnPointContainer = spawnPointContainer;
            _acceptLevelsDeterminator = acceptLevelsDeterminator;
            _stateMachine = stateMachine;
            _levelsInfo = levelsInfo;
            _player = player;
            _startSpawnPosition = startSpawnPosition;
        }

        public CheckpointLevelStrategy Create()
        {
            return new CheckpointLevelStrategy(
                _player,
                _stateMachine,
                _levelsInfo,
                _spawnPointContainer,
                lastCheckpoint: GetLastPosition(),
                startCheckpoint: _startSpawnPosition,
                _acceptLevelsDeterminator);
        }

        private Vector3 GetLastPosition()
        {
            Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
            return easy.GetSpawnPoint(SceneManager.GetActiveScene().name).Position;
        }
    }
}