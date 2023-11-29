using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SlideState : State
    {
        private Rigidbody2D _rigidbody2D;
        private int _slideAnimation = Animator.StringToHash("Slide");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() =>
            Slide();

        public override bool IsCompleted()
        {
            return Info.IsHit
                || Info.IsGrounded
                || Info.IsJumpButtonPressed
                || !Info.IsWallHooked;
        }

        private void Slide()
        {
            PlayerAnimator.Play(_slideAnimation);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -PlayerStats.WallSlidingSpeed, float.MaxValue));
        }
    }
}