using Player;
using UnityEngine;

namespace Traps.SpikedBall
{
    public class FallingObjectTriggerZone : MonoBehaviour
    {
        [SerializeField] private FallingObject _fallingObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<MainHero>(out MainHero player))
                _fallingObject.StartFalling();
        }
    }
}