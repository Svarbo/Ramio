namespace Player.PlayerStateMachine.Checkers
{
    public class WallHookChecker : EnvironmentChecker
    {
        protected override void SetStatus(bool value) =>
            PlayerInfo.SetWallHooked(value);
    }
}