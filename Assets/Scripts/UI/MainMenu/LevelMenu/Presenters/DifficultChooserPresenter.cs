using Data;
using UI.MainMenu.Models;

namespace UI.MainMenu.Presenters
{
    public class DifficultChooserPresenter
    {
        private readonly LevelChooserPresenter _levelChooser;
        private readonly LevelsProgress _levelsProgress;
        private LevelsInfo _levelsInfo;

        public DifficultChooserPresenter(LevelChooserPresenter levelChooser, LevelsInfo levelsInfo, LevelsProgress levelsProgress)
        {
            _levelChooser = levelChooser;
            _levelsInfo = levelsInfo;
            _levelsProgress = levelsProgress;
        }
        
        public void SetEasyDifficult()
        {
            _levelsInfo.CurrentDifficult = typeof(LevelsProgress.Easy);
            ShowLevels(_levelsProgress.GetDifficultLevel(_levelsInfo.CurrentDifficult).CountComplete);
        }

        public void SetMediumDifficult()
        {
            _levelsInfo.CurrentDifficult = typeof(LevelsProgress.Medium);
            ShowLevels(_levelsProgress.GetDifficultLevel(_levelsInfo.CurrentDifficult).CountComplete);
        }

        public void SetHardDifficult()
        {
            _levelsInfo.CurrentDifficult = typeof(LevelsProgress.Hard);
            ShowLevels(_levelsProgress.GetDifficultLevel(_levelsInfo.CurrentDifficult).CountComplete);
        }

        private void ShowLevels(int countCompleteLevels) =>
            _levelChooser.ShowLevels(countCompleteLevels);
    }
}