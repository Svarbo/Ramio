using Players;
using UnityEngine;

namespace Traps.SpikedBall
{
    public class FallingObjectTriggerZone : MonoBehaviour
    {
        [SerializeField] private FallingObject _fallingObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
                _fallingObject.StartFalling();
        }
    }
}