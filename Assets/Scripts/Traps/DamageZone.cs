using Player;
using UnityEngine;

namespace Traps
{
    public class DamageZone : Trap
    {
        [SerializeField] private int _damage = 1;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<MainHero>(out MainHero player))
                player.TakeDamage(_damage);
        }
    }
}