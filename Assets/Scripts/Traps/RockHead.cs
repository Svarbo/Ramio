using UnityEngine;

public class RockHead : MonoBehaviour
{
    [SerializeField] private DamageZone _damageZone;

    private void Hit()
    {
        _damageZone.gameObject.SetActive(true);
    }
}