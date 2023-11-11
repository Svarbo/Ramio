public class TestWallHookChecker : EnvironmentChecker
{
    protected override void SetStatus(bool value)
    {
        PlayerInfo.SetWallHooked(value);
    }
}