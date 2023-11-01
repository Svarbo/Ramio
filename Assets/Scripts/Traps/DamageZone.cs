using UnityEngine;

public class DamageZone : Trap
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            player.TakeDamage(_damage);
    }
}