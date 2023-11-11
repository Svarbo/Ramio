using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerInfo))]
public class ExtraJumpChecker : MonoBehaviour
{
    private PlayerStats _playerStats;
    private PlayerInfo _playerInfo;
    private int _currentExtraJumpsCount = 0;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerInfo = GetComponent<PlayerInfo>();
    }

    private void OnEnable()
    {
        _playerInfo.SomeParameterChanged += OnSomeParameterChanged;
    }

    private void OnDisable()
    {
        _playerInfo.SomeParameterChanged -= OnSomeParameterChanged;
    }

    public void AddExtraJump()
    {
        _currentExtraJumpsCount -= 1;
    }

    private void OnSomeParameterChanged()
    {
        DetermineExtraJumpReady();
        TryChangeExtraJumpsCount();
    }

    private void TryChangeExtraJumpsCount()
    {
        if (_playerInfo.IsJumpButtonPressed && !_playerInfo.IsGrounded && !_playerInfo.IsWallHooked)
            _currentExtraJumpsCount++;
        else if(_playerInfo.IsGrounded || _playerInfo.IsWallHooked)
            _currentExtraJumpsCount = 0;
    }

    private void DetermineExtraJumpReady()
    {
        _playerInfo.SetExtraJumpReady(_currentExtraJumpsCount < _playerStats.ExtraJumpsCount);
    }
}