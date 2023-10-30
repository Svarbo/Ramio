using UnityEngine;

public class FallingTrapTriggerZone : MonoBehaviour
{
    [SerializeField] private FallingTrap fallingObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            fallingObject.StartFalling();
    }
}