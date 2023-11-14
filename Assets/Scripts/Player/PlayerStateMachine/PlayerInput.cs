using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInfo))]
[RequireComponent(typeof(PlayerFliper))]
public class PlayerInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private PlayerFliper _playerFliper;
    private float _motionDirection;

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _playerFliper = GetComponent<PlayerFliper>();
    }

    private void Update()
    {
        _motionDirection = Input.GetAxis("Horizontal");

        if(_playerFliper.enabled == true)
            _playerFliper.SetDirectionIndicator(_motionDirection);

        SetSpeed(_motionDirection);

        if (!_playerInfo.IsSpeedEqualZero && _motionDirection == 0)
            _playerInfo.SetSpeedEqualZero(true);

        if (_playerInfo.IsSpeedEqualZero && _motionDirection != 0)
            _playerInfo.SetSpeedEqualZero(false);

        if (Input.GetKeyDown(KeyCode.W))
            _playerInfo.ActivateJumpButtonPressed();
    }

    private void SetSpeed(float speed)
    {
        _playerInfo.SetSpeed(speed);
    }
}