using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeceleratedWalkState : PlayerState
{
    private Rigidbody2D _rigidbody2D;
    private float _oldDragValue;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _oldDragValue = _rigidbody2D.drag;
        _rigidbody2D.drag = PlayerStats.DecelerationValue;
    }

    private void OnDisable() => 
        _rigidbody2D.drag = _oldDragValue;

    public override bool IsCompleted() => 
        !PlayerInfo.IsDecelerated;
}