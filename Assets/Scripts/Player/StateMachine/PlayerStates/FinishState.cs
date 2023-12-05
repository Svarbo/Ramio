using UnityEngine;

namespace Players.StateMachine.PlayerStates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FinishState : State
    {
        private Rigidbody2D _rigidbody2D;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() =>
            _rigidbody2D.velocity = Vector3.zero;

        public override bool IsCompleted() =>
            Info.IsFinished == false;
    }
}