using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.StateMachines;

public class LevelChooserBuilder
{
    private LevelChooserPresenter _levelChooserPresenter;
    private LevelMenuView _levelMenuView;
    private LevelsInfo _levelsInfo;
    private StateMachine _stateMachine;

    public LevelChooserBuilder(LevelMenuView levelMenuView, LevelsInfo levelsInfo, StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _levelMenuView = levelMenuView;
        _levelsInfo = levelsInfo;
    }

    public LevelChooserPresenter Build()
    {
        _levelChooserPresenter = InitLevelChooser(_levelsInfo);

        foreach (LevelChooser levelChooser in _levelMenuView.LevelsRow.LevelChoosers)
            levelChooser.Construct(_levelChooserPresenter);

        _levelMenuView.Construct(_levelsInfo);
        return _levelChooserPresenter;
    }

    private LevelChooserPresenter InitLevelChooser(LevelsInfo levelsInfo) =>
        _levelChooserPresenter = new LevelChooserPresenter(_levelMenuView.LevelsRow ,levelsInfo, _stateMachine);
}