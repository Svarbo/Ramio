using System;
using Infrastructure.Factories;
using Players;
using UI.Level;
using UnityEngine;

namespace Level
{
    public class EasyLevelStrategy : LevelDifficultStrategy, IDisposable
    {
        private readonly Player _player;
        private readonly Vector3 _lastCheckpoint;
        private readonly Vector3 _startCheckpoint;
        private AbstractFactory _abstractFactory;
        private CheckpointChooserView _checkpointChooserView;

        public EasyLevelStrategy(Player player, Vector3 lastCheckpoint, Vector3 startCheckpoint)
        {
            _player = player;
            _lastCheckpoint = lastCheckpoint;
            _startCheckpoint = startCheckpoint;
            _abstractFactory = new AbstractFactory();
        }

        public override void Execute()
        {
            if (_lastCheckpoint != default)
            {
                _checkpointChooserView = _abstractFactory.Create<CheckpointChooserView>("UI/Level/Canvas");
                _checkpointChooserView.CheckpointChanged += OnCheckpointChanged;
            }
        }

        private void OnCheckpointChanged(bool answer)
        {
            if (answer)
                _player.gameObject.transform.position = _lastCheckpoint;
            else
                _player.gameObject.transform.position = _startCheckpoint;
        }

        public void Dispose() =>
            _checkpointChooserView.CheckpointChanged -= OnCheckpointChanged;
    }
}