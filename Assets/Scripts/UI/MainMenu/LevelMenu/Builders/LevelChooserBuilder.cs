using UI.MainMenu.LevelMenu.Views.Levels;
using UI.MainMenu.Models;
using UI.MainMenu.Presenters;
using UI.MainMenu.Views.Levels;

namespace UI.MainMenu.LevelMenu.Builders
{
    public class LevelChooserBuilder
    {
        private LevelChooserPresenter _levelChooserPresenter;
        private LevelMenuView _levelMenuView;
        private LevelsInfo _levelsInfo;

        public LevelChooserBuilder(LevelMenuView levelMenuView, LevelsInfo levelsInfo)
        {
            _levelMenuView = levelMenuView;
            _levelsInfo = levelsInfo;
        }

        public LevelChooserPresenter Build()
        {
            _levelChooserPresenter = InitLevelChooser(_levelMenuView.LevelsRow, _levelMenuView.ButtonStartGame, _levelsInfo);
            
            foreach (LevelChooser levelChooser in _levelMenuView.LevelsRow.LevelChoosers)
                levelChooser.Construct(_levelChooserPresenter);

            return _levelChooserPresenter;
        }
        
        private LevelChooserPresenter InitLevelChooser(LevelsRow levelsRow, ButtonStartGame buttonStartGame, LevelsInfo levelsInfo) =>
            _levelChooserPresenter = new LevelChooserPresenter(levelsRow, buttonStartGame, levelsInfo);
    }
}