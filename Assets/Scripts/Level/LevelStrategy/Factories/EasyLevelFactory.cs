using Data;
using Players;
using Data.Difficults;
using Infrastructure.StateMachines;
using Level.SpawnPoints;
using UnityEngine;
using UnityEngine.SceneManagement;
using UI.Level;

namespace Level.LevelStrategy.Factories
{
    public class EasyLevelFactory
    {
        private LevelsInfo _levelsInfo;
        private Player _personage;
        private Vector3 _startSpawnPosition;
        private Infrastructure.StateMachines.StateMachine _stateMachine;
        private SpawnPointContainer _spawnPointContainer;

        public EasyLevelFactory(LevelsInfo levelsInfo, Player player, StateMachine stateMachine, Vector3 startSpawnPosition, SpawnPointContainer spawnPointContainer)
        {
            _spawnPointContainer = spawnPointContainer;
            _stateMachine = stateMachine;
            _levelsInfo = levelsInfo;
            _personage = player;
            _startSpawnPosition = startSpawnPosition;
        }

        public EasyLevelStrategy Create() =>
            new EasyLevelStrategy
            (
                _personage,
                _stateMachine,
                _levelsInfo,
                _spawnPointContainer,
                lastCheckpoint: GetLastPosition(),
                startCheckpoint: _startSpawnPosition
            );

        private Vector3 GetLastPosition()
        {
            Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
            return easy.GetSpawnPoint(SceneManager.GetActiveScene().name).Position;
        }
    }
}