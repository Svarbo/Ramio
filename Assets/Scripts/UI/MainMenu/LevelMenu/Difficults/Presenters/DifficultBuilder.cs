using Data;
using UI.MainMenu.LevelMenu.LevelChoosers;

namespace UI.MainMenu.LevelMenu.Difficults.Presenters
{
    public class DifficultBuilder
    {
        private DifficultChooserPresenter _difficultChooserPresenter;

        private readonly LevelsInfo _levelsInfo;
        private readonly LevelChooserPresenter _levelChooserPresenter;
        private readonly DifficultChooserView _difficultChooserView;

        public DifficultBuilder(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo, DifficultChooserView difficultChooserView)
        {
            _levelChooserPresenter = levelChooserPresenter;
            _difficultChooserView = difficultChooserView;
            _levelsInfo = levelsInfo;
        }

        public DifficultChooserPresenter Build()
        {
            _difficultChooserPresenter = InitDifficultChooser(_levelChooserPresenter, _levelsInfo, _difficultChooserView.DifficultInfoPanel.EasyDifficultView,
                _difficultChooserView.DifficultInfoPanel.MediumDifficultView, _difficultChooserView.DifficultInfoPanel.HardDifficultView);

            _difficultChooserView.DifficultInfoPanel.EasyDifficultView.Construct(_difficultChooserPresenter);
            _difficultChooserView.DifficultInfoPanel.MediumDifficultView.Construct(_difficultChooserPresenter);
            _difficultChooserView.DifficultInfoPanel.HardDifficultView.Construct(_difficultChooserPresenter);
            return _difficultChooserPresenter;
        }

        private DifficultChooserPresenter InitDifficultChooser(LevelChooserPresenter levelChooserPresenter, LevelsInfo levelsInfo, EasyDifficultView easyDifficultView,
            MediumDifficultView mediumDifficultView, HardDifficultView hardDifficultView) =>
            _difficultChooserPresenter = new DifficultChooserPresenter(levelChooserPresenter, levelsInfo, easyDifficultView, mediumDifficultView, hardDifficultView);
    }
}