using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _motionSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _wallSlidingSpeed;
        [SerializeField] private float _wallJumpForce;
        [SerializeField] private float _extraJumpForce;
        [SerializeField] private int _extraJumpsCount = 1;
        [SerializeField] private PlayerInputController _playerInputController;

        private PlayerAnimationSetter _playerAnimationSetter;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private Vector2 _motionVector;
        private bool _isGround;
        private bool _isWallHooked;
        private bool _isWallJumpReady;
        private bool _isFacingRight = true;
        private int _currentExtraJumpsCount = 0;

        private void Awake()
        {
            _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
        }

        private void OnEnable()
        {
            _playerInputController.Moved += OnMoved;
            _playerInputController.Jump += OnJump;
        }

        private void OnDisable()
        {
            _playerInputController.Moved -= OnMoved;
            _playerInputController.Jump -= OnJump;
        }

        private void OnJump()
        {
            if (_isGround)
                Jump();
            else if (_currentExtraJumpsCount < _extraJumpsCount)
                ActivateDoubleJump();
            // else if (_isWallHooked && _isWallJumpReady)
            //     ActivateWallJump();
        }

        private void OnMoved(Vector2 direction)
        {
            Vector2 result = new Vector2(direction.x * (_motionSpeed * Time.deltaTime), _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = result;
        }

        private void Move()
        {
            // _rigidbody2D.velocity = new Vector2(_motionVector.x * _motionSpeed, _rigidbody2D.velocity.y);

            if (_motionVector.x != 0)
                _playerAnimationSetter.PlayRun(true);
            else
                _playerAnimationSetter.PlayRun(false);
        }

        private void Jump()
        {
            _playerAnimationSetter.PlayJump();
            SetJumpVelocity(_jumpForce);
        }

        private void ActivateDoubleJump()
        {
            _playerAnimationSetter.PlayDoubleJump();
            SetJumpVelocity(_extraJumpForce);

            _currentExtraJumpsCount++;
        }

        private void SetJumpVelocity(float jumpForce) =>
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);


        public void SetWallHookValues(bool wallHookedValue, bool wallJumpReadyValue)
        {
            _isWallHooked = wallHookedValue;
            _isWallJumpReady = wallJumpReadyValue;
        }

        public void SetDrag(float value)
        {
            _rigidbody2D.drag = value;
        }

        public void SetGroundedStatus(bool value)
        {
            _isGround = value;
            _currentExtraJumpsCount = 0;
        }
    }
}
// private void Update()
// {
// _motionVector.x = Input.GetAxis("Horizontal");
//
//Move();
//
// SetFlip(_motionVector.x);
//
// if (Input.GetKeyDown(KeyCode.W))
//     TryJump();
//
// if (_isWallHooked)
//     Slide();
// }


// private void SetJumpVelocity(float jumpForce, float jumpForce2)
// {
//     _rigidbody2D.velocity = new Vector2(jumpForce2, jumpForce);
// }


// private void ActivateWallJump()
// {
//     _playerAnimationSetter.PlayJump();
//     SetJumpVelocity(_wallJumpForce, -5f);
//
//     _isWallJumpReady = false;
//     _currentExtraJumpsCount = _extraJumpsCount;
// }


// private void Slide()
// {
//     //_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlidingSpeed, float.MaxValue));
// }
// private void SetFlip(float directionIndicator)
// {
//     if (_isFacingRight && directionIndicator < 0 || !_isFacingRight && directionIndicator > 0)
//     {
//         _isFacingRight = !_isFacingRight;
//         Vector3 localScale = _transform.localScale;
//         localScale.x *= -1f;
//         _transform.localScale = localScale;
//     }
// }