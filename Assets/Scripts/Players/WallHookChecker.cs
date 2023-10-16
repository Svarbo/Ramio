using Players;
using UnityEngine;

public class WallHookChecker : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimationSetter _playerAnimationSetter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerAnimationSetter.PlayWallHooked(true);
        _playerMover.SetWallHookValues(true, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerAnimationSetter.PlayWallHooked(false);
        _playerMover.SetWallHookValues(false, false);
    }
}