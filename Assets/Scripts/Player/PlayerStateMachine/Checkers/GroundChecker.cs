public class GroundChecker : EnvironmentChecker
{
    protected override void SetStatus(bool value) => 
        PlayerInfo.SetGrounded(value);
}