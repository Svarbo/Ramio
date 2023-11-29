using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Fliper))]
    public class WallJumpState : State
    {
        private Rigidbody2D _rigidbody2D;
        private Fliper _playerFliper;
        private int _jumpAnimation = Animator.StringToHash("Jump");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerFliper = GetComponent<Fliper>();
        }

        private void OnEnable()
        {
            WallJump();
            SetFlip();
        }

        public override bool IsCompleted()
        {
            return Info.IsWallHooked
                || Info.IsHit
                || Info.IsJumpButtonPressed && Info.IsExtraJumpReady
                || Info.IsGrounded
                || Info.IsFalling;
        }

        private void WallJump()
        {
            PlayerAnimator.Play(_jumpAnimation);

            _rigidbody2D.velocity = new Vector2(PlayerStats.WallJumpForce.x * -Info.DirectionIndicator, PlayerStats.WallJumpForce.y);
        }

        private void SetFlip()
        {
            _playerFliper.enabled = true;

            int currentDirectionIndicator = Info.DirectionIndicator;
            Info.SetDirectionIndicator(-currentDirectionIndicator);

            _playerFliper.enabled = false;
        }
    }
}