using System;
using UnityEngine;

namespace Enemies.TypeEnemies.Chameleons
{
    public class FindZoneTrigger : MonoBehaviour
    {
        public event Action<Vector2> Entered;
        public event Action Exited;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
                Entered?.Invoke(player.transform.position);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
                Exited?.Invoke();
        }
    }
}