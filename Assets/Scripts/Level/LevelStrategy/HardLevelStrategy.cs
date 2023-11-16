using System.Collections;
using Data;
using Infrastructure;
using Infrastructure.States.Scenes;
using Players;
using UI.MainMenu.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class HardLevelStrategy : LevelDifficultStrategy
    {
        private Player _player;
        private Vector3 _startPosition;
        private readonly GameBootstrap _gameBootstrap;
        private readonly LevelsInfo _levelsInfo;

        public HardLevelStrategy(Player player, Vector3 startPosition, GameBootstrap gameBootstrap, LevelsInfo levelsInfo)
        {
            _player = player;
            _startPosition = startPosition;
            _gameBootstrap = gameBootstrap;
            _levelsInfo = levelsInfo;

            _player.PlayerDied += OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            if (SceneManager.GetActiveScene().name == "Level0")
                _player.transform.position = _startPosition;
            else
            {
                _levelsInfo.SceneName = "Level0";
                _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
            }
        }

        public override void Execute()
        {

        }
    }
}