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
        _levelChooserPresenter = InitLevelChooser(_levelMenuView.LevelsRow, _levelsInfo);

        foreach (LevelChooser levelChooser in _levelMenuView.LevelsRow.LevelChoosers)
            levelChooser.Construct(_levelChooserPresenter);

        _levelMenuView.Construct(_levelsInfo);
        return _levelChooserPresenter;
    }

    private LevelChooserPresenter InitLevelChooser(LevelsRow levelsRow, LevelsInfo levelsInfo) =>
        _levelChooserPresenter = new LevelChooserPresenter(levelsRow, levelsInfo, _stateMachine);
}