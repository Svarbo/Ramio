using Players.StateMachine;
using UnityEngine;

namespace Traps
{
    public class Mucus : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Info>(out Info playerInfo))
                playerInfo.SetDecelerated(true);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Info>(out Info playerInfo))
                playerInfo.SetDecelerated(false);
        }
    }
}