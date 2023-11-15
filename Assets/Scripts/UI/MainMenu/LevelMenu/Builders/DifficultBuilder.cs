using Data;
using UI.MainMenu.Models;
using UI.MainMenu.Presenters;

namespace UI.MainMenu.LevelMenu.Builders
{
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
            _difficultChooserPresenter = InitDifficultChooser(_levelChooserPresenter, _levelsInfo, _levelMenuView.LevelsProgress);
            _levelMenuView.EasyDifficultViewButton.Construct(_difficultChooserPresenter);
            _levelMenuView.MediumDifficultViewButton.Construct(_difficultChooserPresenter);
            _levelMenuView.HardDifficultViewButton.Construct(_difficultChooserPresenter);
            return _difficultChooserPresenter;
        }
        
        private DifficultChooserPresenter InitDifficultChooser(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo, LevelsProgress levelsProgress) =>
            _difficultChooserPresenter = new DifficultChooserPresenter(levelChooserPresenter, levelsInfo, levelsProgress);
    }
}