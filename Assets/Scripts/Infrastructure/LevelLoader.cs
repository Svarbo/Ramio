using Data;
using Data.Difficults;
using Infrastructure.StateMachines;
using Infrastructure.States.Scenes;
using System;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class LevelLoader
    {
		private StateMachine _stateMachine;
		private LevelsInfo _levelsInfo;

		public LevelLoader(StateMachine stateMachine, LevelsInfo levelsInfo)
		{
			_levelsInfo = levelsInfo;
			_stateMachine = stateMachine;
		}

		public void RestartLevel()
        {
            if (_levelsInfo.CurrentDifficult == typeof(Hard))
            {
                _levelsInfo.SceneName = Levels.Level0.ToString();
                _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
            }
            else
            {
                _levelsInfo.SceneName = SceneManager.GetActiveScene().name;
                _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
            }
        }

        public void LoadNextLevel()
        {
            string currentLevelName = SceneManager.GetActiveScene().name;
            string levelName = currentLevelName.Substring(currentLevelName.Length - 1);

            if (int.TryParse(levelName, out int number))
                number++;
            else
                throw new InvalidOperationException(levelName);

            currentLevelName = currentLevelName.Remove(currentLevelName.Length - 1);
            currentLevelName += number.ToString();

            _levelsInfo.SceneName = currentLevelName;
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
        }
    }
}