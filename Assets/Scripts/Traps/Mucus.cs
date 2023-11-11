using UnityEngine;

public class Mucus : MonoBehaviour
{
    [SerializeField] private float _decelerateValue = 70f;

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