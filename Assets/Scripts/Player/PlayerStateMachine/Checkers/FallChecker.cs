using UnityEngine;

namespace Player.PlayerStateMachine.Checkers
{
    [RequireComponent(typeof(MainHero))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Info))]
    public class FallChecker : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Info _playerInfo;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInfo = GetComponent<Info>();
        }

        private void Update()
        {
            if (_rigidbody2D.velocity.y < 0)
                _playerInfo.ActivateFalling();
        }
    }
}