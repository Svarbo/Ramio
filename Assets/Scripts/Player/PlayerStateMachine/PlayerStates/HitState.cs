using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HitState : State
    {
        private Rigidbody2D _rigidbody2D;
        private int _hitAnimation = Animator.StringToHash("Hit");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rigidbody2D.velocity = Vector3.zero;

            PlayerAnimator.Play(_hitAnimation);
        }

        public override bool IsCompleted()
        {
            return Info.IsHit == false
                || Info.IsDesappearing;
        }
    }
}