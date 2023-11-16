using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInfo))]
[RequireComponent(typeof(PlayerFliper))]
public class PlayerInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private PlayerFliper _playerFliper;
    private InputService _inputService;

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _playerFliper = GetComponent<PlayerFliper>();
    }

    private void Update()
    {
        if (_playerFliper.enabled)
            _playerFliper.SetDirectionIndicator(_inputService.Direction);

        SetSpeed(_inputService.Direction);

        if (!_playerInfo.IsSpeedEqualZero && _inputService.Direction == 0)
            _playerInfo.SetSpeedEqualZero(true);

        if (_playerInfo.IsSpeedEqualZero && _inputService.Direction != 0)
            _playerInfo.SetSpeedEqualZero(false);
        
        if (_inputService.IsPressButtonJump())
            _playerInfo.ActivateJumpButtonPressed();
    }

    public void SetInputService(InputService inputService)
    {
        _inputService = inputService;
    }

    private void SetSpeed(float speed)
    {
        _playerInfo.SetSpeed(speed);
    }
}