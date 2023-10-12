using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimationSetter _playerAnimationSetter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerMover.SetGroundedStatus(true);
        _playerAnimationSetter.SetGroundedParameter(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerMover.SetGroundedStatus(false);
        _playerAnimationSetter.SetGroundedParameter(false);
    }
}
