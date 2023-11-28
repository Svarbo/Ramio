using Assets.Scripts.Camera;
using Assets.Scripts.Data;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerFactory
{
    private Vector3 _startSpawnPosition;
    private readonly bool _isMobile;
    private readonly Type _difficult;

    public PlayerFactory(Vector3 startSpawnPosition, bool IsMobile, Type difficult)
    {
        _startSpawnPosition = startSpawnPosition;
        _isMobile = IsMobile;
        _difficult = difficult;
    }

    public Player Create()
    {
        Player player = Object.Instantiate
        (
            original: Resources.Load<Player>("Player"),
            position: _startSpawnPosition,
            rotation: Quaternion.identity
        );
        player.SetDifficult(LevelsProgress.Instance.GetDifficultByType(_difficult));
        Camera.main.GetComponent<TargetFollower>().Construct(player.transform, new Vector3(0, 0, -5));

        if (_isMobile)
        {
            player.InputServiceView.Activate();
            player.PlayerInput.SetInputService(new MobileInputService());
        }
        else
        {
            player.InputServiceView.Deactivate();
            player.PlayerInput.SetInputService(new StandaloneInputService());
        }

        return player;
    }
}