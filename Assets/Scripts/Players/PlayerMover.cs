using System;
using System.Collections.Generic;
using Infrastructure.Inputs;
using Unity.VisualScripting;
using UnityEngine;
using IState = Infrastructure.States.IState;
using StateMachine = Infrastructure.StateMachines.StateMachine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private WallHookChecker _wallHookChecker;

    [SerializeField] private float _motionSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallJumpForce;
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _extraJumpForce;
    [SerializeField] private int _extraJumpsCount = 1;
    [SerializeField] private Vector2 _forceToWallJump;
    [SerializeField] private WallJumpParametr _wallJumpParametr;
    private PlayerAnimationSetter _playerAnimationSetter;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Vector2 _motionVector;
    private bool _isWallHooked;
    private bool _isWallJumpReady;
    private bool _isFacingRight = true;
    private int _currentExtraJumpsCount = 0;

    private bool _isGrounded = true;
    private bool _isWall = false;

    private InputService _inputService;
    private StateMachine _stateMachine;
    private Type _currentState;
    private float _collisionPosition;

    private void Awake()
    {
        _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        _stateMachine = new StateMachine(new Dictionary<Type, IState>()
        {
            [typeof(MoveComponent)] = new MoveComponent(_playerAnimationSetter, _transform, _rigidbody2D, _motionSpeed),
            [typeof(JumpComponent)] = new JumpComponent(_playerAnimationSetter, _rigidbody2D, _jumpForce),
            [typeof(DoubleJumpState)] = new DoubleJumpState(_playerAnimationSetter, _rigidbody2D, _jumpForce),
            [typeof(SlideComponent)] = new SlideComponent(_playerAnimationSetter, _rigidbody2D, _wallSlidingSpeed),
            [typeof(WallJumpComponent)] = new WallJumpComponent(_playerAnimationSetter, _rigidbody2D, _forceToWallJump),
            [typeof(IdleState)] = new IdleState(),
        });


        _currentState = typeof(IdleState);
        _stateMachine.Enter(typeof(IdleState));
    }

    private void OnEnable()
    {
        _wallHookChecker.OnWalled += SetWallStatus;
        _groundChecker.OnGrounded += OnGroundStatus;
    }


    private void OnDisable()
    {
        _wallHookChecker.OnWalled -= SetWallStatus;
        _groundChecker.OnGrounded -= OnGroundStatus;
    }

    private void Update()
    {
        _stateMachine.Update(Time.deltaTime);

        _motionVector.x = _inputService.Direction;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(_wallJumpParametr.ForceVEctor);
        }
        if (_isGrounded)
        {
            _currentState = typeof(IdleState);
            _stateMachine.Enter(typeof(IdleState));
        }

        if (Mathf.Abs(_motionVector.x) > Mathf.Epsilon && _currentState != typeof(SlideComponent))
        {
            _currentState = typeof(MoveComponent);
            _stateMachine.Enter(_currentState, _motionVector.x);
        }

        if (_inputService.IsPressButtonJump() && _currentState != typeof(SlideComponent))
        {
            if (_isGrounded)
            {
                _currentState = typeof(JumpComponent);
                _stateMachine.Enter(typeof(JumpComponent));
            }
            else if (_currentState != typeof(DoubleJumpState))
            {
                _currentState = typeof(DoubleJumpState);
                _stateMachine.Enter(_currentState);
            }
        }

        if (_isWall)
        {
            _currentState = typeof(SlideComponent);
            _stateMachine.Enter(_currentState);

            if (_inputService.IsPressButtonJump())
            {
                int direction = 0;
                if (_transform.position.x < _collisionPosition)
                    _wallJumpParametr.Direction = -1;
                else
                    _wallJumpParametr.Direction = 1;

                _currentState = typeof(WallJumpComponent);
                _stateMachine.Enter(_currentState, _wallJumpParametr);
            }
        }
    }

    private void FixedUpdate() =>
        _stateMachine.FixedUpdate(Time.fixedDeltaTime);

    private void LateUpdate() =>
        _stateMachine.Update(Time.deltaTime);

    public void SetDrag(float value) =>
        _rigidbody2D.drag = value;

    private void OnGroundStatus(bool status) =>
        _isGrounded = status;

    private void SetWallStatus(bool status, Vector2 collisionPosition)
    {
        _isWall = status;
        _collisionPosition = collisionPosition.x;
    }

    public void SetInputService(InputService inputService) =>
        _inputService = inputService;
}

[Serializable]
public class WallJumpParametr
{
    [field: SerializeField] public Vector2 ForceVEctor { get; set; }
    [field: SerializeField] public int Direction { get; set; }
}
