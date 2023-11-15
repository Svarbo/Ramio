public class MobileInputService : InputService
{
    private const string Jump = "Jump";

    public override float Direction => throw new System.NotImplementedException();

    public override bool IsPressButtonJump()
    {
        throw new System.NotImplementedException();
    }

    //public override float Direction
    //{
    //    get
    //    {
    //        return SimpleInput.GetAxis(Horizontal);
    //    }
    //}

    //public override bool IsPressButtonJump() =>
    //        SimpleInput.GetButtonUp(Jump);
}