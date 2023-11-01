using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private TestUserInput _userInput;

    private float _speed;
    private bool _isGrounded;

    private void OnEnable()
    {
        _userInput.SpeedChanged += TryChangeState;
    }

    private void OnDisable()
    {
        _userInput.SpeedChanged -= TryChangeState;
    }

    private void TryChangeState()
    {

    }
}