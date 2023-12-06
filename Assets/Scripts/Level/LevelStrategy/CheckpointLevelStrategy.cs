using ConstantValues;
using Data;
using Infrastructure.Factories;
using Infrastructure.StateMachines;
using Level.SpawnPoints;
using UnityEngine;
using Players;
using UI.Level;

namespace Level.LevelStrategy
{
    public class CheckpointLevelStrategy : LevelDifficultStrategy
    {
        private readonly Player _personage;
        private readonly Vector3 _lastCheckpoint;
        private readonly Vector3 _startCheckpoint;
        private readonly AbstractFactory _abstractFactory;
        private readonly SpawnPointContainer _spawnPointContainer;

        private CheckpointChooserView _checkpointChooserView;

        public CheckpointLevelStrategy(
            Player personage, 
            StateMachine stateMachine, 
            LevelsInfo levelsInfo,
            SpawnPointContainer spawnPointContainer, 
            Vector3 lastCheckpoint,
            Vector3 startCheckpoint, 
            AcceptLevelsDeterminator acceptLevelsDeterminator)
            : base(personage, stateMachine, levelsInfo, acceptLevelsDeterminator)
        {
            _spawnPointContainer = spawnPointContainer;
            _personage = personage;
            _lastCheckpoint = lastCheckpoint;
            _startCheckpoint = startCheckpoint;
            _abstractFactory = new AbstractFactory();
        }

        protected override void OnExecute()
        {
            _spawnPointContainer.gameObject.SetActive(true);
            _spawnPointContainer.Show();
    
            if (_lastCheckpoint != default || _lastCheckpoint != Vector3.zero)
            {
                _checkpointChooserView = _abstractFactory.Create<CheckpointChooserView>(ResourcesPath.CheckpointChooserView);
                _checkpointChooserView.CheckpointChanged += OnCheckpointChanged;
            }
        }

        protected override void OnDispose()
        {
            if (_checkpointChooserView != null)
                _checkpointChooserView.CheckpointChanged -= OnCheckpointChanged;
        }

        private void OnCheckpointChanged(bool answer)
        {
            if (answer)
                _personage.gameObject.transform.position = _lastCheckpoint;
            else
                _personage.gameObject.transform.position = _startCheckpoint;
        }
    }
}