public class DifficultBuilder
{
    private DifficultChooserPresenter _difficultChooserPresenter;

    private LevelChooserPresenter _levelChooserPresenter;
    private LevelsInfo _levelsInfo;
    private LevelMenuView _levelMenuView;

    public DifficultBuilder(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo, LevelMenuView levelMenuView)
    {
        _levelChooserPresenter = levelChooserPresenter;
        _levelsInfo = levelsInfo;
        _levelMenuView = levelMenuView;
    }

    public DifficultChooserPresenter Build()
    {
        _difficultChooserPresenter = InitDifficultChooser(_levelChooserPresenter, _levelsInfo);
        _levelMenuView.EasyDifficultViewButton.Construct(_difficultChooserPresenter);
        _levelMenuView.MediumDifficultViewButton.Construct(_difficultChooserPresenter);
        _levelMenuView.HardDifficultViewButton.Construct(_difficultChooserPresenter);
        return _difficultChooserPresenter;
    }

    private DifficultChooserPresenter InitDifficultChooser(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo) =>
        _difficultChooserPresenter = new DifficultChooserPresenter(levelChooserPresenter, levelsInfo);
}