public class ButtonStartGamePresenter
{
    private readonly StateMachine _stateMachine;
    private readonly LevelsInfo _levelsInfo;

    public ButtonStartGamePresenter(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _stateMachine = stateMachine;
        _levelsInfo = levelsInfo;
    }

    public void StartGame() =>
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
}