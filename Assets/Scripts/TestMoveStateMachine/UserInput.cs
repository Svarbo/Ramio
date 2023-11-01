using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestUserInput : MonoBehaviour
{
    private float _speed;
    private Vector2 _motionVector;

    public event UnityAction SpeedChanged;

    private void Update()
    {
        _motionVector.x = Input.GetAxis("Horizontal");

        if (_motionVector.x == 0)
            SpeedChanged?.Invoke();
    }
}
