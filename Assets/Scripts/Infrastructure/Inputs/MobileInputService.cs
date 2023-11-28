namespace Infrastructure.Inputs
{
    public class MobileInputService : InputService
    {
        private const string Jump = "Jump";

        public override float Direction
        {
            get
            {
                return SimpleInput.GetAxis(Horizontal);
            }
        }

        public override bool IsPressButtonJump() =>
                SimpleInput.GetButtonUp(Jump);
    }
}