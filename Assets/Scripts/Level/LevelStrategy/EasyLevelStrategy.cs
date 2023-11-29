using Data;
using Edior;
using Infrastructure.Factories;
using Infrastructure.StateMachines;
using Level.SpawnPoints;
using System;
using UnityEngine;
using Player;

namespace Level.LevelStrategy
{
    public class EasyLevelStrategy : LevelDifficultStrategy, IDisposable
    {
        private readonly MainHero _player;
        private readonly Vector3 _lastCheckpoint;
        private readonly Vector3 _startCheckpoint;

        private AbstractFactory _abstractFactory;
        private CheckpointChooserView _checkpointChooserView;
        private SpawnPointContainer _spawnPointContainer;

        public EasyLevelStrategy(MainHero player, Infrastructure.StateMachines.StateMachine stateMachine, LevelsInfo levelsInfo, SpawnPointContainer spawnPointContainer, Vector3 lastCheckpoint,
            Vector3 startCheckpoint, MainMenuButton mainMenuButton)
            : base(player, stateMachine, levelsInfo, mainMenuButton)
        {
            _spawnPointContainer = spawnPointContainer;
            _player = player;
            _lastCheckpoint = lastCheckpoint;
            _startCheckpoint = startCheckpoint;
            _abstractFactory = new AbstractFactory();

            _spawnPointContainer.gameObject.SetActive(true);
            _spawnPointContainer.Show();
            _player.Input.Deactivate();
        }

        public override void Execute()
        {
            if (_lastCheckpoint != default)
            {
                _checkpointChooserView = _abstractFactory.Create<CheckpointChooserView>("UI/Level/CheckpointChooser");
                _checkpointChooserView.CheckpointChanged += OnCheckpointChanged;
            }
            else
            {
                _player.Input.Activate();
            }
        }

        public void Dispose() =>
            _checkpointChooserView.CheckpointChanged -= OnCheckpointChanged;

        private void OnCheckpointChanged(bool answer)
        {
            if (answer)
                _player.gameObject.transform.position = _lastCheckpoint;
            else
                _player.gameObject.transform.position = _startCheckpoint;

            _player.Input.Activate();
        }
    }
}