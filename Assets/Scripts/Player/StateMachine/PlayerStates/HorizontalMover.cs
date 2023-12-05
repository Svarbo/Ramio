using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Info))]
    [RequireComponent(typeof(Stats))]
    public class HorizontalMover : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Info _playerInfo;
        private Stats _playerStats;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInfo = GetComponent<Info>();
            _playerStats = GetComponent<Stats>();
        }

        private void Update() =>
            Move();

        private void Move() =>
            _rigidbody2D.velocity = new Vector2(_playerInfo.CurrentSpeed * _playerStats.Speed, _rigidbody2D.velocity.y);
    }
}