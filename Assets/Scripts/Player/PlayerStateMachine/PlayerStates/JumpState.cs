using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpState : State
    {
        private Rigidbody2D _rigidbody2D;
        private int _jumpAnimation = Animator.StringToHash("Jump");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() =>
            Jump();

        public override bool IsCompleted()
        {
            return Info.IsGrounded
                || Info.IsHit
                || Info.IsJumpButtonPressed && Info.IsExtraJumpReady
                || Info.IsWallHooked
                || Info.IsFalling;
        }

        private void Jump()
        {
            PlayerAnimator.Play(_jumpAnimation);

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, PlayerStats.JumpForce);
        }
    }
}