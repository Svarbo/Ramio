public class DifficultBuilder
{
    private DifficultChooserPresenter _difficultChooserPresenter;

    private LevelsInfo _levelsInfo;
    private DifficultChooserView _difficultChooserView;

    public DifficultBuilder(LevelsInfo levelsInfo, DifficultChooserView difficultChooserView)
    {
        _difficultChooserView = difficultChooserView;
        _levelsInfo = levelsInfo;
    }

    public DifficultChooserPresenter Build()
    {
        _difficultChooserPresenter = InitDifficultChooser(_levelsInfo);
        
        _difficultChooserView.DifficultInfoPanel.EasyDifficultView.Construct(_difficultChooserPresenter);
        _difficultChooserView.DifficultInfoPanel.MediumDifficultView.Construct(_difficultChooserPresenter);
        _difficultChooserView.DifficultInfoPanel.HardDifficultView.Construct(_difficultChooserPresenter);
        return _difficultChooserPresenter;
    }

    private DifficultChooserPresenter InitDifficultChooser(LevelsInfo levelsInfo) =>
        _difficultChooserPresenter = new DifficultChooserPresenter(levelsInfo);
}