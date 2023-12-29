using System;
using Data;
using GameLeaderboard;
using Infrastructure;
using Players;
using UI.Level.EndGame;
using UnityEngine.SceneManagement;

namespace Level.LevelStrategy
{
    public abstract class LevelDifficultStrategy : IDisposable
    {
        private readonly Player _personage;
        private readonly Infrastructure.StateMachines.StateMachine _stateMachine;
        private readonly LevelsInfo _levelsInfo;
        private readonly AcceptLevelsDeterminator _acceptLevelsDeterminator;
        private readonly LevelLoader _levelLoader;
        private readonly PlayerCanvasDrawer _playerCanvasDrawer;
        private readonly LeaderboardAdder _leaderboardAdder;

        public LevelDifficultStrategy(
            Player player,
            Infrastructure.StateMachines.StateMachine stateMachine,
            LevelsInfo levelsInfo,
            AcceptLevelsDeterminator acceptLevelsDeterminator)
        {
            _leaderboardAdder = new LeaderboardAdder();
            _levelsInfo = levelsInfo;
            _acceptLevelsDeterminator = acceptLevelsDeterminator;
            _stateMachine = stateMachine;
            _personage = player;
            _playerCanvasDrawer = _personage.GetComponentInChildren<PlayerCanvasDrawer>();
            _levelLoader = new LevelLoader(_stateMachine, _levelsInfo);
        }

        public void Execute()
        {
            _playerCanvasDrawer.DefeatPanel.LevelRestarted += _levelLoader.RestartLevel;
            _playerCanvasDrawer.WinPanel.NextLevelLoader += _levelLoader.LoadNextLevel;
            _playerCanvasDrawer.FinishZoneAchieved += _acceptLevelsDeterminator.Determine;
            _playerCanvasDrawer.GratitudeZoneEntered += OnGratitudeZoneEntered;
            _personage.Desappeared += IncreaseAttemptsCount;

            OnExecute();
        }

        public void Dispose()
        {
            _playerCanvasDrawer.DefeatPanel.LevelRestarted -= _levelLoader.RestartLevel;
            _playerCanvasDrawer.WinPanel.NextLevelLoader -= _levelLoader.LoadNextLevel;
            _playerCanvasDrawer.FinishZoneAchieved -= _acceptLevelsDeterminator.Determine;
            _playerCanvasDrawer.GratitudeZoneEntered += OnGratitudeZoneEntered;
            _personage.Desappeared -= IncreaseAttemptsCount;

            OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

        protected virtual void OnExecute()
        {
        }

        private void IncreaseAttemptsCount()
        {
            LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult)
                .IncreaseCountTry(SceneManager.GetActiveScene().name);
        }

        private void OnGratitudeZoneEntered() =>
            _leaderboardAdder.SetCountTryByDifficult(_levelsInfo.CurrentDifficult);
    }
}