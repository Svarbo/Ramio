using UnityEngine;

public class Mucus : MonoBehaviour
{
    private float _dragValue = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out PlayerMover playerMover))
            playerMover.SetDrag(_dragValue);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out PlayerMover playerMover))
            playerMover.SetDrag(0);
    }
}