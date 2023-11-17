using UnityEngine;

public class StandaloneInputService : InputService
{
    public override float Direction
    {
        get
        {
            return Input.GetAxis(Horizontal);
        }
    }

    public override bool IsPressButtonJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
            return true;

        return false;
    }
}