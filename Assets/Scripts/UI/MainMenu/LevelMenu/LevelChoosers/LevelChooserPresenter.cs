using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.StateMachines;
using Assets.Scripts.Infrastructure.States.Scenes;

public class LevelChooserPresenter
{
    private readonly StateMachine _stateMachine;
    private readonly LevelsRow _levelsRow;
    private LevelsInfo _levelsInfo;

    public LevelChooserPresenter(LevelsRow levelsRow, LevelsInfo levelsInfo, StateMachine stateMachine)
    {
        _levelsRow = levelsRow;
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
    }

    public void ShowLevels(int count) =>
        _levelsRow.ShowLevelChoosers(count);

    public void StartGame(string levelName)
    {
        _levelsInfo.SceneName = levelName;

        LevelsProgress.Instance.SetStartDifficult(_levelsInfo.CurrentDifficult.ToString());

        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }
}