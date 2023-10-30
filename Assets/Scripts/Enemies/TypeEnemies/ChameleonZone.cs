using UnityEngine;

public class ChameleonZone : MonoBehaviour
{
    [SerializeField] private Chameleon _chameleon;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
            _chameleon.Attack(player);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        _chameleon.Move();
    }
}