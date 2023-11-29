using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MainHero))]
    public class Stats : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _extraJumpsCount;
        [SerializeField] private float _decelerationValue = 70f;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _extraJumpForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _wallSlidingSpeed;
        [SerializeField] private Vector2 _wallJumpForce;

        public int Health => _health;
        public int ExtraJumpsCount => _extraJumpsCount;
        public float DecelerationValue => _decelerationValue;
        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float ExtraJumpForce => _extraJumpForce;
        public float WallSlidingSpeed => _wallSlidingSpeed;
        public Vector2 WallJumpForce => _wallJumpForce;
    }
}