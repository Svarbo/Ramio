using System;
using UnityEngine;

public class WallHookChecker : MonoBehaviour
{
    public event Action<bool, Vector2> OnWalled;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            OnWalled?.Invoke(true, collision.ClosestPoint(transform.position));
        //_playerAnimationSetter.SetWallHookedParameter(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnWalled?.Invoke(false, Vector2.zero);
        //_playerAnimationSetter.SetWallHookedParameter(false);
    }
}