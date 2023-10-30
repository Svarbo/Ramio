using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    private Animator _animator;
    protected UnitAnimation UnitAnimation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        UnitAnimation = new UnitAnimation(_animator);
    }

    public abstract void Attack(Player player);

    public abstract void Move();
}