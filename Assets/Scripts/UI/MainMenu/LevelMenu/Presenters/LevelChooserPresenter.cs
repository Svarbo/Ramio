using System;
using UI.MainMenu.Models;
using UI.MainMenu.Views;
using UI.MainMenu.Views.Levels;

namespace UI.MainMenu.Presenters
{
    public class LevelChooserPresenter
    {
        private readonly LevelsRow _levelsRow;
        private readonly ButtonStartGame _playButton;
        private readonly LevelsInfo _levelsInfo;

        public LevelChooserPresenter(LevelsRow levelsRow, ButtonStartGame playButton, LevelsInfo levelsInfo)
        {
            _levelsRow = levelsRow;
            _playButton = playButton;
            _levelsInfo = levelsInfo;
        }
        
        public void ShowLevels(int count) =>
            _levelsRow.ShowLevelChoosers(count);

        public void ActivateButtonToStartGame() =>
            _playButton.Show();

        public void SetLevelName(string levelName) =>
            _levelsInfo.SceneName = levelName;
    }
}