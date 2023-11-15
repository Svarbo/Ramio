using Players;
using UnityEngine;

namespace Level
{
    public class MediumLevelStrategy : LevelDifficultStrategy
    {
        private readonly Player _player;
        private readonly Vector3 _startSpawnPosition;

        public MediumLevelStrategy(Player player, Vector3 startSpawnPosition)
        {
            _player = player;
            _startSpawnPosition = startSpawnPosition;
            _player.PlayerDied += OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            _player.transform.position = _startSpawnPosition;
        }

        public override void Execute()
        {
            
        }
    }
}