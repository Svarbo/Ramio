using Interfaces;
using UnityEngine;

public abstract class Enemy : IDamageable, IAttack, ICharacter
{
    private int _damage = 2;
    
    public virtual void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(_damage);
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log("Уничтожен");
    }

    protected abstract void CreateStateMachine();
}