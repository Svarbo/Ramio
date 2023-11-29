using UnityEngine;
using UnityEngine.Events;

namespace Traps
{
    public class MoveTarget : MonoBehaviour
    {
        public event UnityAction IsAchieved;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Trap>(out Trap trap))
                IsAchieved?.Invoke();
        }
    }
}