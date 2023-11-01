using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 _motionVector;
    [SerializeField] private float _motionSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_motionVector.x * _motionSpeed, _rigidbody2D.velocity.y);
        PlayerAnimationSetter.SetRunParameter(_motionVector.x != 0);
    }
}
