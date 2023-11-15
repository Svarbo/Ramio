using System;
using Infrastructure.StateMachines;
using Infrastructure.States.Scenes;
using UI.MainMenu.Models;
using UnityEditorInternal;
using StateMachine = Infrastructure.StateMachines.StateMachine;

namespace UI.MainMenu.Presenters
{
    public class ButtonStartGamePresenter
    {
        private readonly StateMachine _stateMachine;
        private readonly LevelsInfo _levelsInfo;

        public ButtonStartGamePresenter(StateMachine stateMachine, LevelsInfo levelsInfo)
        {
            _stateMachine = stateMachine;
            _levelsInfo = levelsInfo;
        }

        public void StartGame() =>
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }
}