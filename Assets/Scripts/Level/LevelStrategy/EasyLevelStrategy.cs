using System;
using Level.SpawnPoints;
using UnityEngine;

public class EasyLevelStrategy : LevelDifficultStrategy, IDisposable
{
    private readonly Player _player;
    private readonly Vector3 _lastCheckpoint;
    private readonly Vector3 _startCheckpoint;

    private AbstractFactory _abstractFactory;
    private CheckpointChooserView _checkpointChooserView;
    private SpawnPointContainer _spawnPointContainer;

    public EasyLevelStrategy(Player player, StateMachine stateMachine, LevelsInfo levelsInfo, SpawnPointContainer spawnPointContainer, Vector3 lastCheckpoint, Vector3 startCheckpoint)
    : base(player, stateMachine, levelsInfo)
    {
        _spawnPointContainer = spawnPointContainer;
        _player = player;
        _lastCheckpoint = lastCheckpoint;
        _startCheckpoint = startCheckpoint;
        _abstractFactory = new AbstractFactory();

        _spawnPointContainer.gameObject.SetActive(true);
        _spawnPointContainer.Show();
        _player.PlayerInput.Deactivate();
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
            _player.PlayerInput.Activate();
        }
    }

    private void OnCheckpointChanged(bool answer)
    {
        if (answer)
            _player.gameObject.transform.position = _lastCheckpoint;
        else
            _player.gameObject.transform.position = _startCheckpoint;
        
        _player.PlayerInput.Activate();
    }

    public void Dispose() =>
        _checkpointChooserView.CheckpointChanged -= OnCheckpointChanged;
}