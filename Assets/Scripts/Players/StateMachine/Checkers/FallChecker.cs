using UnityEngine;

namespace Players.StateMachine.Checkers
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInfo))]
    public class FallChecker : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private PlayerInfo _playerInfo;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInfo = GetComponent<PlayerInfo>();
        }

        private void Update()
        {
            if (_rigidbody2D.velocity.y < 0)
                _playerInfo.ActivateFalling();
        }
    }
}