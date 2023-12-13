using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DeceleratedWalkState : State
    {
        private Rigidbody2D _rigidbody2D;
        private float _oldDragValue;
        private int _walkAnimation = Animator.StringToHash("Walk");

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            PlayerAnimator.Play(_walkAnimation);
            _oldDragValue = _rigidbody2D.drag;
            _rigidbody2D.drag = PlayerStats.DecelerationValue;
        }

        private void OnDisable() =>
            _rigidbody2D.drag = _oldDragValue;

        public override bool IsCompleted()
        {
            return !Info.IsDecelerated
                || Info.IsSpeedEqualZero
                || Info.IsHit;
        }
    }
}