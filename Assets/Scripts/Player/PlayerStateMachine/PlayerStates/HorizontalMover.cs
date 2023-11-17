using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInfo))]
[RequireComponent(typeof(PlayerStats))]
public class HorizontalMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerInfo _playerInfo;
    private PlayerStats _playerStats;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInfo = GetComponent<PlayerInfo>();
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Update() => 
        Move();

    private void Move() => 
        _rigidbody2D.velocity = new Vector2(_playerInfo.CurrentSpeed * _playerStats.Speed, _rigidbody2D.velocity.y);
}