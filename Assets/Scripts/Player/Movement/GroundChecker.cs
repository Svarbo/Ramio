using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    //[SerializeField] private PlayerAnimationSetter _playerAnimationSetter;

    public event Action<bool> OnGrounded; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGrounded?.Invoke(true);
        //_playerMover.SetGroundedStatus(true);
        //_playerAnimationSetter.SetGroundedParameter(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnGrounded?.Invoke(false);
        //_playerMover.SetGroundedStatus(false);
        //_playerAnimationSetter.SetGroundedParameter(false);
    }
}
