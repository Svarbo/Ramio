using UnityEngine;

public class Mucus : MonoBehaviour
{
    [SerializeField] private float _decelerateValue = 70f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out PlayerMover playerMover))
            playerMover.Decelerate(_decelerateValue);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out PlayerMover playerMover))
            playerMover.NormalizeSpeed();
    }
}