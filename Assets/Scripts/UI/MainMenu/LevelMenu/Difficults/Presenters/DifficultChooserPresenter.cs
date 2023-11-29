using Data;
using Data.Difficults;
using UI.MainMenu.LevelMenu.LevelChoosers;

public class DifficultChooserPresenter
{
    private readonly LevelsInfo _levelsInfo;
    private readonly EasyDifficultView _easyDifficultView;
    private readonly MediumDifficultView _mediumDifficultView;
    private readonly LevelChooserPresenter _levelChooserPresenter;
    private readonly HardDifficultView _hardDifficultView;

    public DifficultChooserPresenter(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo, EasyDifficultView easyDifficultView, MediumDifficultView mediumDifficultView,
        HardDifficultView hardDifficultView)
    {
        _levelChooserPresenter = levelChooserPresenter;
        _hardDifficultView = hardDifficultView;
        _mediumDifficultView = mediumDifficultView;
        _easyDifficultView = easyDifficultView;
        _levelsInfo = levelsInfo;

        if (_levelsInfo.CurrentDifficult == typeof(Easy))
            SetEasyDifficult();
        else if (_levelsInfo.CurrentDifficult == typeof(Medium))
            SetMediumDifficult();
        else
            SetHardDifficult();
    }


    public void SetEasyDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Easy);
        _easyDifficultView.Hide();
        _mediumDifficultView.Show();
        _hardDifficultView.Show();
        _levelChooserPresenter.ShowLevels(LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult).GetAcceptLevels());
    }

    public void SetMediumDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Medium);
        _easyDifficultView.Show();
        _mediumDifficultView.Hide();
        _hardDifficultView.Show();
        _levelChooserPresenter.ShowLevels(LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult).GetAcceptLevels());
    }

    public void SetHardDifficult()
    {
        _levelsInfo.CurrentDifficult = typeof(Hard);
        _easyDifficultView.Show();
        _mediumDifficultView.Show();
        _hardDifficultView.Hide();
        _levelChooserPresenter.ShowLevels(LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult).GetAcceptLevels());
    }
}