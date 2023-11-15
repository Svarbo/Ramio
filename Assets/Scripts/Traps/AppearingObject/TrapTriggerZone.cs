using Players;
using UnityEngine;

public class TrapTriggerZone : MonoBehaviour
{
    [SerializeField] private AppearingObject _appearingObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _appearingObject.Appear();
    }
}