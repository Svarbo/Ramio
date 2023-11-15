public abstract class InputService
{
    protected readonly string Horizontal = "Horizontal";
    public abstract float Direction { get; }

    public abstract bool IsPressButtonJump();
}