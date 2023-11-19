public class DifficultChooserPresenter
{
    private readonly LevelChooserPresenter _levelChooser;
    private LevelsInfo _levelsInfo;

    public DifficultChooserPresenter(LevelChooserPresenter levelChooser, LevelsInfo levelsInfo)
    {
        _levelChooser = levelChooser;
        _levelsInfo = levelsInfo;
    }

    public void SetEasyDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Easy);
        //TODO PlayerPrefs для EasyDifficult  DifficultChooserPresenter
        ShowLevels(1);
    }

    public void SetMediumDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Medium);
        ShowLevels(LevelsProgress.Instance.GetMediumDifficult().GetAcceptLevels());
    }

    public void SetHardDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Hard);
        ShowLevels(LevelsProgress.Instance.GetHardDifficult().GetAcceptLevels());
    }

    private void ShowLevels(int countCompleteLevels) =>
        _levelChooser.ShowLevels(countCompleteLevels);
}