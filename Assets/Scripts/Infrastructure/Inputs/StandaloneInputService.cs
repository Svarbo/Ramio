using UnityEngine;

namespace Infrastructure.Inputs
{
    public class StandaloneInputService : InputService
    {
        public override float Direction
        {
            get
            {
                return UnityEngine.Input.GetAxis(Horizontal);
            }
        }

        public override bool IsPressButtonJump()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                return true;

            return false;
        }
    }
}