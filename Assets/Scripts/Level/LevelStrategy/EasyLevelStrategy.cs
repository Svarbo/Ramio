using Data;
using Infrastructure.Factories;
using Infrastructure.StateMachines;
using Level.SpawnPoints;
using System;
using UnityEngine;
using Players;
using UI.Level;

namespace Level.LevelStrategy
{
    public class EasyLevelStrategy : LevelDifficultStrategy, IDisposable
    {
        private readonly Player _personage;
        private readonly Vector3 _lastCheckpoint;
        private readonly Vector3 _startCheckpoint;

        private AbstractFactory _abstractFactory;
        private CheckpointChooserView _checkpointChooserView;
        private SpawnPointContainer _spawnPointContainer;

        public EasyLevelStrategy(Player personage, StateMachine stateMachine, LevelsInfo levelsInfo, SpawnPointContainer spawnPointContainer, Vector3 lastCheckpoint,
            Vector3 startCheckpoint)
            : base(personage, stateMachine, levelsInfo)
        {
            _spawnPointContainer = spawnPointContainer;
            _personage = personage;
            _lastCheckpoint = lastCheckpoint;
            _startCheckpoint = startCheckpoint;
            _abstractFactory = new AbstractFactory();

            _spawnPointContainer.gameObject.SetActive(true);
            _spawnPointContainer.Show();
        }

        public override void Execute()
        {
            if (_lastCheckpoint != default)
            {
                _checkpointChooserView = _abstractFactory.Create<CheckpointChooserView>("UI/Level/CheckpointChooser");
                _checkpointChooserView.CheckpointChanged += OnCheckpointChanged;
            }
        }

        public void Dispose() =>
            _checkpointChooserView.CheckpointChanged -= OnCheckpointChanged;

        private void OnCheckpointChanged(bool answer)
        {
            if (answer)
                _personage.gameObject.transform.position = _lastCheckpoint;
            else
                _personage.gameObject.transform.position = _startCheckpoint;
        }
    }
}