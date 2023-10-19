using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _motionSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallJumpForce;
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _extraJumpForce;
    [SerializeField] private int _extraJumpsCount  = 1;

    private PlayerAnimationSetter _playerAnimationSetter;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Vector2 _motionVector;
    private bool _isGrounded;
    private bool _isWallHooked;
    private bool _isWallJumpReady;
    private bool _isFacingRight = true;
    private int _currentExtraJumpsCount = 0;

    private void Start()
    {
        _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _motionVector.x = Input.GetAxis("Horizontal");

        Move();

        Flip(_motionVector.x);

        if (Input.GetKeyDown(KeyCode.W))
            TryJump();
    }

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
        _isGrounded = value;
        
        if (_isWallHooked)
            Slide();
        
        _currentExtraJumpsCount = 0;
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.gravityScale = 0;
        enabled = false;
    }
    
    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_motionVector.x * _motionSpeed, _rigidbody2D.velocity.y);
        _playerAnimationSetter.SetRunParameter(_motionVector.x != 0);
    }

    private void TryJump()
    {
        if (_isGrounded)
            Jump();
        else if (_isWallHooked && _isWallJumpReady)
            ActivateWallJump();
        else if(_currentExtraJumpsCount < _extraJumpsCount)
            ActivateDoubleJump();
    }

    private void Jump()
    {
        _playerAnimationSetter.ActivateJump();
        SetJumpVelocity(_jumpForce);
    }

    private void ActivateDoubleJump()
    {
        _playerAnimationSetter.ActivateDoubleJump();
        SetJumpVelocity(_extraJumpForce);

        _currentExtraJumpsCount++;
    }

    private void ActivateWallJump()
    {
        _playerAnimationSetter.ActivateJump();
        SetJumpVelocity(_wallJumpForce, -5f);

        _isWallJumpReady = false;
        _currentExtraJumpsCount = 0;
    }

    private void SetJumpVelocity(float jumpForce)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
    }

    private void SetJumpVelocity(float jumpForce, float jumpForce2)
    {
        _rigidbody2D.velocity = new Vector2(jumpForce2, jumpForce);
    }

    private void Flip(float direction)
    {
        if (direction > 0)
            _transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (direction < 0)
            _transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    
    private void Slide()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlidingSpeed, float.MaxValue));
    }
}