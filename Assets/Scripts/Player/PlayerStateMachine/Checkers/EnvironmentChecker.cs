using UnityEngine;

namespace Player.PlayerStateMachine.Checkers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class EnvironmentChecker : MonoBehaviour
    {
        private const string _groundLayer = "Ground";

        [SerializeField] protected Info PlayerInfo;

        [SerializeField] private LayerMask _layerMask;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(_groundLayer))
                SetStatus(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(_groundLayer))
                SetStatus(false);
        }

        protected abstract void SetStatus(bool value);
    }
}