using UnityEngine;

public class SpikedBallTriggerZone : MonoBehaviour
{
    [SerializeField] private SpikedBall spikedBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            spikedBall.StartFall();
    }
}