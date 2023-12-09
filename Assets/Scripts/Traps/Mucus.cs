using Players.StateMachine;
using UnityEngine;

namespace Traps
{
    public class Mucus : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInfo))
                playerInfo.SetDecelerated(true);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInfo))
                playerInfo.SetDecelerated(false);
        }
    }
}