using Infrastructure.Core;
using UI.MainMenu.Models;
using UI.MainMenu.Presenters;

namespace UI.MainMenu.LevelMenu.Builders
{
    public class ButtonStartGameBuilder
    {
        private ButtonStartGamePresenter _buttonStartGamePresenter;

        public ButtonStartGameBuilder(LevelsInfo levelsInfo, ButtonStartGame buttonStartGame, AppCore appCore)
        {
            _levelsInfo = levelsInfo;
            _buttonStartGame = buttonStartGame;
            _appCore = appCore;
        }

        private LevelsInfo _levelsInfo;
        private ButtonStartGame _buttonStartGame;
        private AppCore _appCore;

        public ButtonStartGamePresenter Build()
        {
            _buttonStartGamePresenter = InitButtonStartGame(_levelsInfo);
            _buttonStartGame.Construct(_buttonStartGamePresenter);
            return _buttonStartGamePresenter;
        }
        
        private ButtonStartGamePresenter InitButtonStartGame(LevelsInfo levelsInfo) =>
            _buttonStartGamePresenter = new ButtonStartGamePresenter(_appCore.StateMachine, levelsInfo);
    }
}