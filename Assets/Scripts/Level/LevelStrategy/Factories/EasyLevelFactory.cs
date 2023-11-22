using UnityEngine;

public class EasyLevelFactory
{
    private LevelsInfo _levelsInfo;
    private Player _player;
    private Vector3 _startSpawnPosition;
    private StateMachine _stateMachine;

    public EasyLevelFactory(LevelsInfo levelsInfo, Player player, StateMachine stateMachine, Vector3 startSpawnPosition)
    {
        _stateMachine = stateMachine;
        _levelsInfo = levelsInfo;
        _player = player;
        _startSpawnPosition = startSpawnPosition;
    }

    public EasyLevelStrategy Create() =>
        new EasyLevelStrategy
        (
            _player,
            _stateMachine,
            _levelsInfo,
            lastCheckpoint: default,
            startCheckpoint: _startSpawnPosition
        );
    //            lastCheckpoint: LevelsProgress.Instance.GetDifficultByType(typeof(Easy)),

}