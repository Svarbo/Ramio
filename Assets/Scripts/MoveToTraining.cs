using System;
using Data;
using IJunior.TypedScenes;
using Infrastructure;
using Infrastructure.States.Scenes;
using UI.MainMenu.Models;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoveToTraining : MonoBehaviour
    {
        private GameBootstrap _gameBootstrap;

        private void Awake()
        {
            _gameBootstrap = FindObjectOfType<GameBootstrap>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            LevelsInfo levelsInfo = new LevelsInfo();
            levelsInfo.CurrentDifficult = typeof(LevelsProgress.Hard);
            levelsInfo.SceneName = "Training";
            _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState),levelsInfo);
        }
    }

}