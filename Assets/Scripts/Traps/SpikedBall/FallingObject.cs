using UnityEngine;

namespace Traps.SpikedBall
{
    [RequireComponent(typeof(DamageZone))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingObject : MonoBehaviour
    {
        private const string _groundLayer = "Ground";
        private const string _playerLayer = "Player";

        private Rigidbody2D _rigidbody2D;

        private void Start() =>
            _rigidbody2D = GetComponent<Rigidbody2D>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            int collisionLayer = collision.gameObject.layer;

            if (collisionLayer == LayerMask.NameToLayer(_groundLayer) || collisionLayer == LayerMask.NameToLayer(_playerLayer))
                gameObject.SetActive(false);
        }

        public void StartFalling() =>
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}