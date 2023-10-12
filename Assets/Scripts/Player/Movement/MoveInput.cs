using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhisicsMovement))]
public class MoveInput : MonoBehaviour
{
    private PhisicsMovement _phisicsMovement;
    private Vector2 _moveDirection;
    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _phisicsMovement = GetComponent<PhisicsMovement>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _moveDirection = new Vector2(-_horizontal, _vertical);

        _phisicsMovement.Move(_moveDirection);
    }
}
