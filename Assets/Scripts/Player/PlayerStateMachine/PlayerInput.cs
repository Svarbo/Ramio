using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInfo))]
public class PlayerInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private float _motionDirection;

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        _motionDirection = Input.GetAxis("Horizontal");

        SetDirectionIndicator(_motionDirection);
        SetSpeed(_motionDirection);

        if (!_playerInfo.IsSpeedEqualZero && _motionDirection == 0)
            _playerInfo.SetSpeedEqualZero(true);

        if (_playerInfo.IsSpeedEqualZero && _motionDirection != 0)
            _playerInfo.SetSpeedEqualZero(false);

        if (Input.GetKeyDown(KeyCode.W))
            _playerInfo.ActivateJumpButtonPressed();
    }

    private void SetDirectionIndicator(float motionDirection)
    {
        if(motionDirection > 0)
            _playerInfo.SetDirectionIndicator(1);
        else if(motionDirection < 0)
            _playerInfo.SetDirectionIndicator(-1);
    }

    private void SetSpeed(float speed)
    {
        _playerInfo.SetSpeed(speed);
    }
}