using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ExtraJumpState : State
    {
        private Rigidbody2D _rigidbody2D;
        private int _extraJumpAnimation = Animator.StringToHash("ExtraJump");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() =>
            DoubleJump();

        public override bool IsCompleted()
        {
            return Info.IsGrounded
                || Info.IsHit
                || Info.IsJumpButtonPressed && Info.IsExtraJumpReady
                || Info.IsWallHooked
                || Info.IsFalling;
        }

        private void DoubleJump()
        {
            PlayerAnimator.Play(_extraJumpAnimation);

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, PlayerStats.ExtraJumpForce);
        }
    }
}