public class DifficultChooserPresenter
{
    private LevelsInfo _levelsInfo;

    public DifficultChooserPresenter(LevelsInfo levelsInfo) =>
        _levelsInfo = levelsInfo;

    public void SetEasyDifficult() =>
        _levelsInfo.CurrentDifficult = typeof(Easy);

    public void SetMediumDifficult() =>
        _levelsInfo.CurrentDifficult = typeof(Medium);

    public void SetHardDifficult() =>
        _levelsInfo.CurrentDifficult = typeof(Hard);
}